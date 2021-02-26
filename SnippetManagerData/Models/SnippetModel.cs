using System.ComponentModel.DataAnnotations;

namespace SnippetManagerData.Models
{
    public class SnippetModel
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public EnvironmentModel Environment { get; set; }
        [MaxLength(128)]
        public string UserID { get; set; }
    }
}
