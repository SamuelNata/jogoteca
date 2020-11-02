using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Jogoteca.Models.Entities;
using Jogoteca.Service.Interfaces;
using Jogoteca.Models.ViewModels;
using Jogoteca.Models.Exceptions;

namespace Jogoteca.Web.Controllers
{
    public class BorrowingController : BaseController
    {
        private readonly IGameBorrowingService _gameBorrowingService;
        private readonly IUserGameService _userGameService;
        private readonly IUserService _userService;

        public BorrowingController(
            IGameBorrowingService gameBorrowingService,
            IUserGameService userGameService,
            IUserService userService)
        {
            _gameBorrowingService = gameBorrowingService;
            _userGameService = userGameService;
            _userService = userService;
        }

        // GET: Borrowing
        public async Task<IActionResult> Index()
        {
            return View(await _gameBorrowingService.GetHistoryBorrowedByOwner(new Guid(CurrentUserId)));
        }

        // GET: Borrowing/Create
        public async Task<IActionResult> Create(Guid? gameId)
        {
            await AddGamesListToViewData();
            await AddUsersListToViewData();
            return View();
        }

        // POST: Borrowing/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BorrowGameVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _gameBorrowingService.BorrowGame(
                    model.GameOwnershipId.Value,
                    model.UserGetingBorrowedId,
                    model.PredictedDevolution
                );
                if(result > 0){
                    return RedirectToAction(nameof(Index));
                }
            }

            await AddGamesListToViewData();
            await AddUsersListToViewData();
            return View(model);
        }

        [HttpPost]
        public async Task<JsonResult> MarkAsReturned(Guid id)
        {
            try
            {
                var result = await _gameBorrowingService.MarkAsReturned(id);
                if(result > 0){
                    return Json(new { success = true, message = "Jogo devolvido" });
                }
                else
                {
                    return Json(new { success = false, message = "Não foi possível devolver o jogo" });
                }
            }
            catch(UserFriendlyException e)
            {
                return Json(new { success = false, message = e.Message });
            }
            catch(Exception e)
            {
                return Json(new { success = false, message = "Não foi possível devolver o jogo" });
            }
            
        }

        private async Task<bool> GameBorrowingExists(Guid id)
        {
            var result = await _gameBorrowingService.GetById(id);
            return result == null;
        }

        private async Task AddGamesListToViewData(Guid? gameId = null){
            var borrowableGames = await _userGameService.SearchByGameAndOwner(new Guid(CurrentUserId), gameId, true);
            ViewBag.gamesList = borrowableGames.Select(go => new SelectListItem()
                {
                    Text = $"{go.Game.Name} {go.Game.Year} ({go.User.Name})",
                    Value = go.Id.ToString()
                }
            ).ToList();
        }

        private async Task AddUsersListToViewData(){
            var allUsers = await _userService.GetAll();
            var curentUserId = new Guid(CurrentUserId);
            ViewBag.Users = allUsers.Where(u => u.Id != curentUserId).Select(u => new SelectListItem()
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }
            ).ToList();
        }
    }
}
