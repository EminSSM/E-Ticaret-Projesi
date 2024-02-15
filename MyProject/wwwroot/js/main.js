(function ($) {
    "use strict";

    // Sticky Navbar
    $(window).scroll(function () {
        if ($(this).scrollTop() > 40) {
            $('.navbar').addClass('sticky-top');
        } else {
            $('.navbar').removeClass('sticky-top');
        }
    });
    $(document).ready(function () {
        $('.nav-item .nav-link').click(function (event) {
            event.preventDefault(); // Sayfanýn yenilenmesini engellemek için bu satýrý ekliyoruz.

            // Tüm linklerden "active" sýnýfýný kaldýrýn
            $('.nav-item .nav-link').removeClass('active');

            // Týklanan öðeye "active" sýnýfýný ekleyin
            $(this).addClass('active');
        });
    });
    
    // Dropdown on mouse hover
    //$(document).ready(function () {
    //    function toggleNavbarMethod() {
    //        if ($(window).width() > 992) {
    //            $('.navbar .dropdown').on('mouseover', function () {
    //                $('.dropdown-toggle', this).trigger('click');
    //            }).on('mouseout', function () {
    //                $('.dropdown-toggle', this).trigger('click').blur();
    //            });
    //        } else {
    //            $('.navbar .dropdown').off('mouseover').off('mouseout');
    //        }
    //    }
    //    toggleNavbarMethod();
    //    $(window).resize(toggleNavbarMethod);
    //});


    // Modal Video
    $(document).ready(function () {
        var $videoSrc;
        $('.btn-play').click(function () {
            $videoSrc = $(this).data("src");
        });
        console.log($videoSrc);

        $('#videoModal').on('shown.bs.modal', function (e) {
            $("#video").attr('src', $videoSrc + "?autoplay=1&amp;modestbranding=1&amp;showinfo=0");
        })

        $('#videoModal').on('hide.bs.modal', function (e) {
            $("#video").attr('src', $videoSrc);
        })
    });
    function addIframe() {
        var iframeContainer = document.getElementById("iframeContainer");
        var iframe = document.createElement("iframe");
        iframe.src = "https://www.youtube.com/embed/lMkNKhCSkxs"; // Ýframe içeriði için URL belirleyin
        iframe.width = "600";
        iframe.height = "400";
        iframeContainer.appendChild(iframe);
    }
   
    // Back to top button
    $(window).scroll(function () {
        if ($(this).scrollTop() > 100) {
            $('.back-to-top').fadeIn('slow');
        } else {
            $('.back-to-top').fadeOut('slow');
        }
    });
    $('.back-to-top').click(function () {
        $('html, body').animate({scrollTop: 0}, 1500, 'easeInOutExpo');
        return false;
    });


    // Product carousel
    $(".product-carousel").owlCarousel({
        autoplay: true,
        smartSpeed: 1000,
        margin: 45,
        dots: false,
        loop: true,
        nav : true,
        navText : [
            '<i class="bi bi-arrow-left"></i>',
            '<i class="bi bi-arrow-right"></i>'
        ],
        responsive: {
            0:{
                items:1
            },
            768:{
                items:2
            },
            992:{
                items:3
            },
            1200:{
                items:4
            }
        }
    });


    // Team carousel
    $(".team-carousel").owlCarousel({
        autoplay: true,
        smartSpeed: 1000,
        margin: 45,
        dots: false,
        loop: true,
        nav : true,
        navText : [
            '<i class="bi bi-arrow-left"></i>',
            '<i class="bi bi-arrow-right"></i>'
        ],
        responsive: {
            0:{
                items:1
            },
            768:{
                items:2
            },
            992:{
                items:3
            },
            1200:{
                items:4
            }
        }
    });


    // Testimonials carousel
    $(".testimonial-carousel").owlCarousel({
        autoplay: true,
        smartSpeed: 1000,
        items: 1,
        dots: false,
        loop: true,
        nav : true,
        navText : [
            '<i class="bi bi-arrow-left"></i>',
            '<i class="bi bi-arrow-right"></i>'
        ],
    });
    
})(jQuery);

// SEPETE EKLEME KODLARI
function AddCart(productid, stock) {
    var istenilenMiktar = $(".inputQuantity").val();
    if (istenilenMiktar <= 0) alert("NOT: Ürün Eklemediniz")
    else if (istenilenMiktar <= stock) {
        $.ajax({
            type: "POST",
            url: "/sepet/sepeteekle",
            data: { "productid": productid, "quantity": istenilenMiktar },
            success: function (data) {
                if (data.indexOf("~") == -1) {
                    $('#modelSepet .modal-body').text(data + " ürününden " + istenilenMiktar + " adet sepete baþarýyla eklendi...")
                    $('#modelSepet').modal('show');
                    getCartCount();
                }
            },
            error: function (e) {
                alert(e.responseText)
            }
        });

    } else alert("Bu üründen maksimum " + stock + " adet sipariþ verebilirsiniz.")
}
