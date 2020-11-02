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
using Jogoteca.Web.Models.ViewModels;
using Jogoteca.Models.ViewModels;

namespace Jogoteca.Web.Controllers
{
    public class UserGamesController : BaseController
    {
        private readonly IUserGameService _userGameService;
        private readonly IGameService _gameService;

        public UserGamesController(
            IUserGameService userGameService,
            IGameService gameService)
        {
            _userGameService = userGameService;
            _gameService = gameService;
        }

        // GET: UserGames
        public async Task<IActionResult> Index()
        {
            return View("MyGames", await _userGameService.SearshGamesByUser(new Guid(CurrentUserId)));
        }

        // GET: UserGames/Details/5
        // public async Task<IActionResult> Details(Guid? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var userGame = await _userGameService.GetById(id.Value);
        //     if (userGame == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(userGame);
        // }

        // GET: UserGames/Create
        public async Task<IActionResult> Create()
        {
            var allGames = await _gameService.GetAll();
            ViewBag.gamesList = allGames.Select(g => new SelectListItem{
                Text = $"{g.Name} - {g.Year}",
                Value = g.Id.ToString()
            }).ToList();
            return View();
        }

        // POST: UserGames/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserGameVM model)
        {
            if (ModelState.IsValid)
            {
                var userGame = new UserGame {
                    UserId = new Guid(CurrentUserId),
                    GameId = model.GameId
                };
                await _userGameService.Save(userGame);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: UserGames/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userGames = await _userGameService.SearchByGameAndOwner(new Guid(CurrentUserId), id.Value);
            if (!userGames.Any())
            {
                return NotFound();
            }

            return View(userGames.First());
        }

        // POST: UserGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var result = await _userGameService.RemoveGameFromUser(id, new Guid(CurrentUserId));
            return RedirectToAction(nameof(Index));
        }
    }
}
