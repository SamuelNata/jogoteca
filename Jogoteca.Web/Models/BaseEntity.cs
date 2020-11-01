using System;
using System.ComponentModel.DataAnnotations;

namespace Jogoteca.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public BaseEntity WithId(){
            if(this.Id == null){
                this.Id = Guid.NewGuid();
                return this;
            }
            return this;
        }
    }
}
