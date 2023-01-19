using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static ParkyAPI.Models.Trail;

namespace ParkyAPI.Models.Dtos.Trail
{
    public class TrailCreateDto
    {
        
       

        [Required]
        public string Name { get; set; }

        [Required]
        public double Distance { get; set; }
        [Required]
        public double Elevation { get; set; }

        [Required]
        public DifficultyType Difficulty { get; set; }

        [Required]
        public int NationalParkId { get; set; }


    }
}
