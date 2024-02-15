/* =================================
------------------------------------
	Divisima | eCommerce Template
	Version: 1.0
 ------------------------------------
 ====================================*/


'use strict';


$(window).on('load', function() {
	/*------------------
		Preloder
	--------------------*/
	$(".loader").fadeOut();
	$("#preloder").delay(400).fadeOut("slow");

});

(function($) {
	/*------------------
		Navigation
	--------------------*/
	$('.main-menu').slicknav({
		prependTo:'.main-navbar .container',
		closedSymbol: '<i class="flaticon-right-arrow"></i>',
		openedSymbol: '<i class="flaticon-down-arrow"></i>'
	});


	/*------------------
		ScrollBar
	--------------------*/
	$(".cart-table-warp, .product-thumbs").niceScroll({
		cursorborder:"",
		cursorcolor:"#afafaf",
		boxzoom:false
	});


	/*------------------
		Category menu
	--------------------*/
	$('.category-menu > li').hover( function(e) {
		$(this).addClass('active');
		e.preventDefault();
	});
	$('.category-menu').mouseleave( function(e) {
		$('.category-menu li').removeClass('active');
		e.preventDefault();
	});


	/*------------------
		Background Set
	--------------------*/
	$('.set-bg').each(function() {
		var bg = $(this).data('setbg');
		$(this).css('background-image', 'url(' + bg + ')');
	});



	/*------------------
		Hero Slider
	--------------------*/
	var hero_s = $(".hero-slider");
    hero_s.owlCarousel({
        loop: true,
        margin: 0,
        nav: true,
        items: 1,
        dots: true,
        animateOut: 'fadeOut',
    	animateIn: 'fadeIn',
        navText: ['<i class="flaticon-left-arrow-1"></i>', '<i class="flaticon-right-arrow-1"></i>'],
        smartSpeed: 1200,
        autoHeight: false,
        autoplay: true,
        onInitialized: function() {
        	var a = this.items().length;
            $("#snh-1").html("<span>1</span><span>" + a + "</span>");
        }
    }).on("changed.owl.carousel", function(a) {
        var b = --a.item.index, a = a.item.count;
    	$("#snh-1").html("<span> "+ (1 > b ? b + a : b > a ? b - a : b) + "</span><span>" + a + "</span>");

    });

	hero_s.append('<div class="slider-nav-warp"><div class="slider-nav"></div></div>');
	$(".hero-slider .owl-nav, .hero-slider .owl-dots").appendTo('.slider-nav');



	/*------------------
		Brands Slider
	--------------------*/
	$('.product-slider').owlCarousel({
		loop: true,
		nav: true,
		dots: false,
		margin : 30,
		autoplay: true,
		navText: ['<i class="flaticon-left-arrow-1"></i>', '<i class="flaticon-right-arrow-1"></i>'],
		responsive : {
			0 : {
				items: 1,
			},
			480 : {
				items: 2,
			},
			768 : {
				items: 3,
			},
			1200 : {
				items: 4,
			}
		}
	});


	/*------------------
		Popular Services
	--------------------*/
	$('.popular-services-slider').owlCarousel({
		loop: true,
		dots: false,
		margin : 40,
		autoplay: true,
		nav:true,
		navText:['<i class="fa fa-angle-left"></i>','<i class="fa fa-angle-right"></i>'],
		responsive : {
			0 : {
				items: 1,
			},
			768 : {
				items: 2,
			},
			991: {
				items: 3
			}
		}
	});


	/*------------------
		Accordions
	--------------------*/
	$('.panel-link').on('click', function (e) {
		$('.panel-link').removeClass('active');
		var $this = $(this);
		if (!$this.hasClass('active')) {
			$this.addClass('active');
		}
		e.preventDefault();
	});


	/*-------------------
		Range Slider
	--------------------- */
	var rangeSlider = $(".price-range"),
		minamount = $("#minamount"),
		maxamount = $("#maxamount"),
		minPrice = rangeSlider.data('min'),
		maxPrice = rangeSlider.data('max');
	rangeSlider.slider({
		range: true,
		min: minPrice,
		max: maxPrice,
		values: [minPrice, maxPrice],
		slide: function (event, ui) {
			minamount.val('$' + ui.values[0]);
			maxamount.val('$' + ui.values[1]);
		}
	});
	minamount.val('$' + rangeSlider.slider("values", 0));
	maxamount.val('$' + rangeSlider.slider("values", 1));


	/*-------------------
		Quantity change
	--------------------- */
	var proQty = $('.pro-qty');

	proQty.prepend('<span  class="dec qtybtn">-</span>');
	proQty.append('<span class="inc qtybtn">+</span>');


	proQty.on('click', '.qtybtn', function () {
		var $button = $(this);
		var $input = $button.siblings('.inputQuantity');
		var oldValue = parseFloat($input.val());

		if ($button.hasClass('inc')) {
			var newVal = oldValue + 1;
		} else {
			if (oldValue > 1) {
				var newVal = oldValue - 1;
			} else {
				newVal = 1;
			}
		}

		$input.val(newVal);
	});

	$("#pquantity").click(function () {
		var $button = $(this);
		var oldValue = $button.parent().find('input').val();
		if ($button.hasClass('inc')) {
			var newVal = parseFloat(oldValue) + 1;
		} else {
			// Don't allow decrementing below zero
			if (oldValue > 1) {
				var newVal = parseFloat(oldValue) - 1;
			} else {
				newVal = 1;
			}
			
		}
		$button.parent().find('input').val(newVal);
		console.log(newVal)
	})
	
	proQty.on('click', '.qtybtn', function () {
		var $button = $(this);
		var $row = $button.closest('tr');
		var $input = $row.find('input#prqty');
		var $priceInput = $row.find('input#ProductPrice');
		var $calculateH4 = $row.find('#Calculate h4');

		var oldValue = parseFloat($input.val());
		var productPrice = parseFloat($priceInput.val());

		if ($button.hasClass('inc')) {
			var newVal = oldValue + 1;
		} else {
			if (oldValue > 1) {
				var newVal = oldValue - 1;
			} else {
				newVal = 1;
			}
		}

		$input.val(newVal);

		var total = (newVal * productPrice).toFixed(2);
		$calculateH4.text(total);

		updateTotalCost();

		var $ProductId = $.row.find("input#ProductId");
		var ProdId = parseFloat($ProductId.val());

		$.ajax({
			type: "POST",
			url: "/Cart/UpdateBasket",
			data: { "productId": ProdId, "quantity": newVal },
			success: function (data) {
				
			},
			error: function (e) {
				alert(e.responseText);
			}
		});
	});

	function updateTotalCost() {
		var totalCost = 0;
		$('.total-col h4').each(function () {
			totalCost += parseFloat($(this).text());
		});

		// Format the total cost as Turkish Lira currency
		var formattedTotalCost = totalCost.toLocaleString('tr-TR', {
			style: 'currency',
			currency: 'TRY',
			minimumFractionDigits: 2,
		});

		$('.total-cost span').text(formattedTotalCost).toFixed(2);
		$('#totalCartSpan').text(formattedTotalCost);




	}

	/*------------------
		Single Product
	--------------------*/
	$('.product-thumbs-track > .pt').on('click', function(){
		$('.product-thumbs-track .pt').removeClass('active');
		$(this).addClass('active');
		var imgurl = $(this).data('imgbigurl');
		var bigImg = $('.product-big-img').attr('src');
		if(imgurl != bigImg) {
			$('.product-big-img').attr({src: imgurl});
			$('.zoomImg').attr({src: imgurl});
		}
	});


	$('.product-pic-zoom').zoom();


	getCartCount();
})(jQuery);

function getCartCount() {
    $.ajax({
        type: "GET",
        url: "/sepet/sepetsayisi",
        success: function (data) {
			$('.shopping-card span').text(data)
        },
        error: function (e) {
            alert(e.responseText)
        }
    });
}
// SEPETE EKLEME KODLARI
function AddCart(productId, stock) {
	var istenilenMiktar = $(".inputQuantity").val();
	if (istenilenMiktar <= 0) alert("NOT: Ürün Eklemediniz")
	else if (istenilenMiktar <= stock) {
		$.ajax({
			type: "POST",
			url: "/sepet/sepeteekle",
			data: { "productId": productId, "quantity": istenilenMiktar },
			success: function (data) {
				if (data.indexOf("~") == -1) {
					$('#modelSepet .modal-body').text(data + " ürününden " + istenilenMiktar + " adet sepete başarıyla eklendi...")
					$('#modelSepet').modal('show');
					getCartCount();
				}
			},
			error: function (e) {
				alert(e.responseText)
			}
		});

	} else alert("Bu üründen maksimum " + stock + " adet sipariş verebilirsiniz.")
}
function CartAdd(productId, stock) {
	var stock = 1;
	$.ajax({
		type: "POST",
		url: "/sepet/sepeteekle",
		data: { "productId": productId, "quantity": stock },
		success: function (data) {
			if (data.indexOf("~") == -1) {
				$('#modelSepet .modal-body').html(data + " ürününden " + stock + " adet ürün sepete başarıyla eklendi...");
				$('#modelSepet').modal('show');
				getCartCount();
				
			}
		},
		error: function (e) {
			alert(e.responseText);
		}
	});
}


function removecart(productid) {
	$.ajax({
		type: "POST",
		url: "sepet/sepettensil",
		data: { "productID": productid },
		success: function (data) {
			if (data == "OK")
				location.href = "/sepet";

		},
		error: function (e) {
			alert(e.responseText)
		}
	});
}



function functSelectPaymentOption(_obje) {
	var seciliOption = $(_obje).val();
	if (seciliOption != "") {
		$(".divPaymentOption").slideUp();
		switch (seciliOption) {
			case "1":
				$(".creditCard").slideDown();
				break;
			case "2":
				$(".bank").slideDown();
				break;
			case "3":
				$(".door").slideDown();
				break;

		}
	}
}

