using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static ParkyAPI.Models.Trail;

namespace ParkyAPI.Models.Dtos.Trail
{
    public class TrailUpdateDto
    {
        
        public int Id { get; set; }

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
