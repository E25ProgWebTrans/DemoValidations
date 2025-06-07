using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class MonModel
    {
        public int Id { get; set; }
        
        [Range(3, 10, ErrorMessage = "Le champ {0} doit être entre {1} et {2}")]
        public int Valeur { get; set;}
        
        [Required(ErrorMessage = "Un message spécifique pour dire que c'est requis!")]
        public string Requis { get; set; }
        
        [StringLength(30, MinimumLength = 5)]
        public string? Optionnel { get; set; }
    }
}
