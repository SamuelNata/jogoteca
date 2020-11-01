using System;
using System.ComponentModel.DataAnnotations;

namespace Jogoteca.Models.Entities
{
    public class GameBorrowing : BaseEntity
    {
        [Required]
        public DateTime StartDate { get; set; }
        
        [Required]
        public DateTime PredictedEndDate { get; set; }
        
        public DateTime? RealEndDate { get; set; }


        [Required]
        public virtual User GameOwner { get; set; }
        
        [Required]
        public virtual User GameBorrower { get; set; }
        
        [Required]
        public virtual Game BorrowedGame { get; set; }
    }
}
