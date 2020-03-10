using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsurancePolicyApplication.Models
{
    public class ContentInsurance
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="varchar(100)")]
        [Required(ErrorMessage ="Name is Required")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Column(TypeName = "decimal(12, 2)")]
        public decimal Value { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [Display(Name = "Category")]
        public virtual Category category { get; set; }


    }
}
