using System.Security.Claims;
using Jogoteca.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jogoteca.Web.Controllers
{
    /// <summary>
    /// BaseController require a autenticated user to work properly
    /// </summary>
    [Authorize]
    [TypeFilter(typeof(ExceptionHandlerFilter))]
    public abstract class BaseController : Controller
    {
        protected string CurrentUserId => User.FindFirstValue(ClaimTypes.NameIdentifier);

    }
}