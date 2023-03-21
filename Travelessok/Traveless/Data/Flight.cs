namespace Traveless.Data
{
    public class Flight
    {
        public int Id { get; set; }
        public string? FlightCode { get; set; }
        public string? Airline { get; set; }
        public string? From { get; set; }
        public string? To { get; set; }
        public string? Day { get; set; }
        public string? Time { get; set; }
        public string? ReservationCode { get; set; }
        public string? Cost { get; set; }
    }
}
