using System.ComponentModel.DataAnnotations;

namespace ParkyDiHon_API.Models.Dtos
{
    public class NationalParkDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string State { get; set; }
        public DateTime Created { get; set; }
        public DateTime Establised { get; set; }
    }
}
