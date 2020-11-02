using System.Security.Claims;
using Jogoteca.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Jogoteca.Web.Controllers
{
    public class BaseController : Controller
    {
        protected string CurrentUserId => User.FindFirstValue(ClaimTypes.NameIdentifier);

    }
}