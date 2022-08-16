using System;
using System.Collections.Generic;

namespace PokedexMVC.Models
{
    public partial class Pokemon
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public int IdTipo { get; set; }

        public virtual Tipo IdTipoNavigation { get; set; } = null!;
    }
}
