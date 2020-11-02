using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Jogoteca.Models.Entities
{
    public class Game : BaseEntity
    {
        [Required]
        [MaxLength(150)]
        [BindRequired]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Ano de lançamento")]
        public short? Year { get; set; }
    }
}
