using System.ComponentModel.DataAnnotations;

namespace PokedexMVC.Models.Dto_ViewModel_
{
    public class PokemonDto
    {
        [Required]
        public string Nombre {get; set;}

        [Required]
        [Display(Name ="Tipo")]
        public int TipoId { get; set;}
    }
}
