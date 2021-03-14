using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SnippetManagerData.Models
{
    public class OSModel
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "The OS name field is required!")]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(128)]
        public string UserID { get; set; }
    }
}
