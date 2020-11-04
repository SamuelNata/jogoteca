using System.Threading.Tasks;
using Jogoteca.Models.Entities;
using Jogoteca.Web.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Jogoteca.Web.Controllers
{
    [AllowAnonymous]
    public class PagesController : Controller
    {
        
        public PagesController() { }

        public IActionResult Error()
        {
            return View();
        }
    }
}
