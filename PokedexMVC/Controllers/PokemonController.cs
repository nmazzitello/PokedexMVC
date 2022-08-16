using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PokedexMVC.Models;
using PokedexMVC.Models.Dto_ViewModel_;

namespace PokedexMVC.Controllers
{
    public class PokemonController : Controller
    {
        private readonly pokedexContext _context;

        public PokemonController (pokedexContext context)
        {
            _context = context;
        }

        async public Task<IActionResult> Index()
        {
            var pokemons = _context.Pokemons.Include(m => m.IdTipoNavigation);
            return View(await pokemons.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["nuevoPokemon"] = new SelectList(_context.Tipos, "Id", "Descripcion");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PokemonDto model)
        {
            if (ModelState.IsValid)
            {
                var pokemon = new Pokemon()
                {
                    Descripcion = model.Nombre,
                    IdTipo = model.TipoId
                };

                _context.Pokemons.Add(pokemon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["nuevoPokemon"] = new SelectList(_context.Tipos, "Id", "Descripcion");
            return View();
        }
    }
}
