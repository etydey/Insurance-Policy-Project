using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsurancePolicyApplication.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Category")]
        public string Name { get; set; }
        public virtual List<ContentInsurance> ContentInsurances { get; set; }
    }
}
