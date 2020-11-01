using System.Threading.Tasks;
using Jogoteca.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Jogoteca.Web.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService) : base()
        {
            _gameService = gameService;
        }
        

        public async Task<IActionResult> Index(){
            var result = await _gameService.GetAll();
            return View(result);
        }
    }
}