﻿using System.ComponentModel.DataAnnotations;

namespace SnippetManagerData.Models
{
    public class EnvironmentModel
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(128)]
        public string UserID { get; set; }
    }
}
