using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message
    {
        public int ID { get; set; }
        [Column(TypeName = "Varchar(50)"), Display(Name = "Adı Soyadı"), StringLength(50)]
        public string FullName { get; set; }//---------------------------
        [Column(TypeName = "Varchar(80)"), Display(Name = "Mail Adresi"), StringLength(80)]
        public string Email { get; set; }//---------------------------
        [Column(TypeName = "Varchar(100)"), Display(Name = "Konu"), StringLength(100)]
        public string Subject { get; set; }//---------------------------
        [Column(TypeName = "Varchar(500)"), Display(Name = "Mesaj"), StringLength(500)]
        public string Messages { get; set; }//---------------------------

        [Display(Name = "Kayıt Tarihi")]
        public DateTime RecDate { get; set; }


    }
}
