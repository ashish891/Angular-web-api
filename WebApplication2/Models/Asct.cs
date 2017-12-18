using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    [Table("dbo.ADetails")]
    public class ADetail
    {
        [Key]
        public int Id { set; get; }

        [Display(Name = "Customer Name")]
        public string Name { set; get; }

        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { set; get; }

        [Display(Name = "Address Details")]
        public string Address { set; get; }
        
        [Display(Name = "Specialization")]
        public string Spec { set; get; }
    }

    [Table("dbo.Specl")]
    public class ASpecl
    {
        [Key]
        public int SrNo { set; get; }

        public int DID { set; get; }

        [Display(Name = "Specialization")]
        public string Spec { set; get; }

      
    }



    public class ViewData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { set; get; }

        [Display(Name = "Customer Name")]
        public string Name { set; get; }

        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { set; get; }

        [Display(Name = "Address Details")]
        public string Address { set; get; }

        [Display(Name = "Specialization")]
        public string Spec { set; get; }

        public int SrNo { set; get; }


    }

}