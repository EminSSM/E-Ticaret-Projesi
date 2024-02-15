using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Order
	{
		public int ID { get; set; }
		[Column(TypeName = "Varchar(20)"), StringLength(20), Display(Name = "Sipariş Numarası")]
		public string OrderNumber { get; set; }


		[Display(Name = "Ödeme Seçeneği")]
		public EPaymentOption PaymentOption { get; set; }

		[Display(Name = "Sipariş Durumu")]
		public EOrderStatus OrderStatus { get; set; }

		[Display(Name = "Sipariş Tarihi")]
		public DateTime RecDate { get; set; }

		[Column(TypeName = "Varchar(150)"), StringLength(150), Display(Name = "Teslimat Adresi")]
		public string Address { get; set; }

		[Column(TypeName = "Varchar(50)"), StringLength(50), Display(Name = "Teslimat Şehri")]
		public string City { get; set; }

		[Column(TypeName = "Varchar(50)"), StringLength(50), Display(Name = "Teslimat İlçe")]
		public string District { get; set; }

		[Column(TypeName = "Varchar(50)"), StringLength(50), Display(Name = "Teslimat Ülke")]
		public string Country { get; set; }

		[Column(TypeName = "Varchar(10)"), StringLength(10), Display(Name = "Posta kodu")]
		public string ZipCode { get; set; }

		[Column(TypeName = "Varchar(20)"), StringLength(20), Display(Name = "Telefon Numarası")]
		public string Phone { get; set; }
		[Column(TypeName = "Varchar(80)"), StringLength(80), Display(Name = "Mail Adresi")]
		public string MailAdress { get; set; }

		[Column(TypeName = "Varchar(100)"), StringLength(100), Display(Name = "Adı Soyadı")]
		public string NameSurname { get; set; }

		[Column(TypeName = "decimal(18,2)"), Display(Name = "Kargo Ücreti")]
		public decimal ShippedFee { get; set; }

		public ICollection<OrderDetail> OrderDetail { get; set; }

		[NotMapped]
		public string CartNumber { get; set; }
		[NotMapped]
		public string CartMonth { get; set; }
		[NotMapped]
		public string CartYear { get; set; }
		[NotMapped]
		public string CartCV2 { get; set; }
	}
}
