using System;
using System.Collections.Generic;

namespace PokedexMVC.Models
{
    public partial class Tipo
    {
        public Tipo()
        {
            Pokemons = new HashSet<Pokemon>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Pokemon> Pokemons { get; set; }
    }
}
