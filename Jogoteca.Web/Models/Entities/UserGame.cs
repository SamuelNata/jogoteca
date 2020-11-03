using System;
using System.Collections.Generic;

namespace Jogoteca.Models.Entities
{
    public class UserGame : BaseEntity
    {
        public Guid UserId { get; set; }

        public Guid GameId { get; set; }

        public virtual User User { get; set; }
        
        public virtual Game Game { get; set; }

        public virtual ICollection<GameBorrowing> GameBorrowings { get; set; }
    }
}
