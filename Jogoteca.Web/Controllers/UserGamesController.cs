using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Jogoteca.DbContexts;
using Jogoteca.Models.Entities;
using Jogoteca.Service.Interfaces;

namespace Jogoteca.Web.Controllers
{
    public class UserGamesController : Controller
    {
        private readonly JogotecaDbContext _context;
        private readonly IUserGameService _userGameService;

        public UserGamesController(JogotecaDbContext context, IUserGameService userGameService)
        {
            _context = context;
            _userGameService = userGameService;
        }

        // GET: UserGames
        public async Task<IActionResult> Index()
        {
            return View(await _userGameService.GetAll());
        }

        // GET: UserGames/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userGame = await _userGameService.GetById(id.Value);
            if (userGame == null)
            {
                return NotFound();
            }

            return View(userGame);
        }

        // GET: UserGames/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserGames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] UserGame userGame)
        {
            if (ModelState.IsValid)
            {
                userGame.Id = Guid.NewGuid();
                await _userGameService.Save(userGame);
                return RedirectToAction(nameof(Index));
            }
            return View(userGame);
        }

        // GET: UserGames/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userGame = await _userGameService.GetById(id.Value);
            if (userGame == null)
            {
                return NotFound();
            }
            return View(userGame);
        }

        // POST: UserGames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id")] UserGame userGame)
        {
            if (id != userGame.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _userGameService.Update(userGame);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await UserGameExists(userGame.Id))
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
            return View(userGame);
        }

        // GET: UserGames/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userGame = await _userGameService.GetById(id.Value);
            if (userGame == null)
            {
                return NotFound();
            }

            return View(userGame);
        }

        // POST: UserGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var userGame = await _userGameService.GetById(id);
            await _userGameService.Remove(userGame);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> UserGameExists(Guid id)
        {
            var userGame = await _userGameService.GetById(id);
            return userGame != null;
        }
    }
}
