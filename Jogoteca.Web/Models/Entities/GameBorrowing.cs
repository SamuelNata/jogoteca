using System;
using System.ComponentModel.DataAnnotations;

namespace Jogoteca.Models.Entities
{
    public class GameBorrowing : BaseEntity
    {
        [Required]
        [Display(Name = "Emprestado em")]
        public DateTime StartDate { get; set; }
        
        [Required]
        [Display(Name = "Devolução prevista")]
        public DateTime PredictedEndDate { get; set; }
        
        [Display(Name = "Devolução real")]
        public DateTime? RealEndDate { get; set; }

        [Required]
        [Display(Name = "Jogo")]
        public Guid GameOwnershipId { get; set; }

        [Required]
        [Display(Name = "Empretado a")]
        public Guid GameBorrowerId { get; set; }


        public virtual UserGame GameOwnership { get; set; }
        
        public virtual User GameBorrower { get; set; }
    }
}
