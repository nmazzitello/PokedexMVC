using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokedexMVC.Models;

namespace PokedexMVC.Controllers
{
    public class TipoController : Controller
    {
        private readonly pokedexContext _context;

        public TipoController(pokedexContext context)
        {
            _context = context;
        }

        public async Task <IActionResult> Index()
        {
            return View(await _context.Tipos.ToListAsync());
        }
    }
}
