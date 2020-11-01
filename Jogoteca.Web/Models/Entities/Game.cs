using System;
using System.ComponentModel.DataAnnotations;

namespace Jogoteca.Models.Entities
{
    public class Game : BaseEntity
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        public short? Year { get; set; }
    }
}
