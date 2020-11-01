using System;
using System.ComponentModel.DataAnnotations;

namespace Jogoteca.Models.Entities
{
    public class User : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(150)]
        public string Email { get; set; }
    }
}
