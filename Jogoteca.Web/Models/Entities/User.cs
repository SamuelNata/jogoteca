using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Jogoteca.Web.Models;
using Microsoft.AspNetCore.Identity;

namespace Jogoteca.Models.Entities
{
    public class User : IdentityUser<Guid>, IBaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
