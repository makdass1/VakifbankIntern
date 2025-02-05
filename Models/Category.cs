using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace VakifbankIntern.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(30)]
        [MinLength(1)]
        [DisplayName("Category Name")]
        public string Name { get; set; } = "";
        
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Girilen deger istenilen aralıkta değil")]
        
        
        public int DisplayOrder { get; set; }

    }
}
