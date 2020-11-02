using System;
using System.ComponentModel.DataAnnotations;

namespace Jogoteca.Models.ViewModels
{
    public class CreateUserGameVM
    {
        [Required]
        [Display(Name="Jogo")]
        public Guid GameId { get; set; }

        public Guid UserId { get; set; }
    }
}