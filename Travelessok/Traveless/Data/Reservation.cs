using System.ComponentModel.DataAnnotations;

namespace Traveless.Data
{
    public class Reservation
    {
        public int Id { get; set; }
        [Required]
        public string? FlightCode { get; set; }
        [Required]
        public string? Airline { get; set; }
        [Required]
        public string? From { get; set; }
        [Required]
        public string? To { get; set; }
        [Required]
        public string? Day { get; set; }
        [Required]
        public string? Time { get; set; }
        [Required]
        public string? ReservationCode { get; set; }
        [Required]
        public string? Cost { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Citizenship { get; set; }
        public string? Status { get; set; }
    }
}
