using System;

namespace Jogoteca.Models.Entities
{
    public class UserGame : BaseEntity
    {
        public virtual User User { get; set; }
        
        public virtual Game Game { get; set; }
    }
}
