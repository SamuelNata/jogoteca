using System;
using System.ComponentModel.DataAnnotations;
using Jogoteca.Web.Models;

namespace Jogoteca.Models
{
    public abstract class BaseEntity : IBaseEntity
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
