using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Content
    {
        [Key]
        public int ContentID { get; set; }


        [StringLength(1000)]
        public string ContentValue { get; set; }


        public DateTime ContentDate { get; set; }


        //Yazar - İçerik İlişkisi
        public int? WriterID { get; set; } // nullable type
        public virtual Writer Writer { get; set; }

        //Başlık - İçerik İlişkisi
        public int HeadingID { get; set; }
        public virtual Heading Heading { get; set; }




    }
}
