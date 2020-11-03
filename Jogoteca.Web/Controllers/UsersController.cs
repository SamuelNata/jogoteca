using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Jogoteca.DbContexts;
using Jogoteca.Models.Entities;
using Jogoteca.Service.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Jogoteca.Web.Controllers
{
    public class UsersController : Controller
    {
        
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;

        public UsersController(
            UserManager<User> userManager,
            IUserService userService)
        {
            _userManager = userManager;
            _userService = userService;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _userService.GetAll());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userService.GetById(id.Value);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id")] User user)
        {
            if (ModelState.IsValid)
            {
                user.Id = Guid.NewGuid();
                user.UserName = user.Email;
                var result = await _userManager.CreateAsync(user, "altere_essa_senha");
                TempData["successMessage"] = "Agora seu amigo pode acessar o sistema usando email e a senha 'altere_essa_senha'";
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userService.GetById(id.Value);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Email,Id")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var dbUser = await _userService.GetById(id);
                    dbUser.Email = user.Email;
                    dbUser.Name = user.Name;
                    await _userService.Update(dbUser);
                }
                catch (DbUpdateConcurrencyException e)
                {
                    if (!await UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        private async Task<bool> UserExists(Guid id)
        {
            var user = await _userService.GetById(id);
            return user != null;
        }
    }
}
