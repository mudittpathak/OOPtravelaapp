using Microsoft.VisualBasic.FileIO;

namespace Traveless.Data
{
    public class ReservationManager
    {
        public async Task<List<Flight>> GetFlightAsync()
        {
            
            string filePath = Path.Combine(Directory.GetCurrentDirectory()+"\\Assets\\"+"flights.csv");
            string flightBinPath = Path.Combine(Directory.GetCurrentDirectory()+"\\Assets\\"+ "Flight.bin");
            
            int linesNumber = File.ReadAllLines(filePath).Length;

            FlightCsvToBinary(filePath, flightBinPath);

            var result = CreateFlight(flightBinPath, linesNumber);

            return result;

        }

        public async Task<List<Reservation>> GetReservationAsync()
        {
            List<Reservation> reservations = new List<Reservation>();   
            string reservationBinPath = Path.Combine(Directory.GetCurrentDirectory() + "\\Assets\\" + "Reservation.bin");
            int binFileLinesNumber = File.ReadAllLines(reservationBinPath).Length;
            FileStream fs = new FileStream(reservationBinPath, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);


            for (int i = 0; i < binFileLinesNumber; i++)
            {
                reservations.Add(new Reservation()
                {
                    FlightCode = br.ReadString(),
                    Airline = br.ReadString(),
                    From = br.ReadString(),
                    To = br.ReadString(),
                    Day = br.ReadString(),
                    Time = br.ReadString(),
                    Cost = br.ReadString(),
                    Name = br.ReadString(),
                    Citizenship = br.ReadString(),
                    ReservationCode = br.ReadString(),
                    Status = br.ReadString()
                });
            }
            br.Close();
            fs.Close();
            return reservations;
      }

        public async Task<Reservation> GetReservationSingleAsync()
        {
            Reservation reservation = new Reservation();
            string reservationBinPath = Path.Combine(Directory.GetCurrentDirectory() + "\\Assets\\" + "Reservation.bin");
            int binFileLinesNumber = File.ReadAllLines(reservationBinPath).Length;
            FileStream fs = new FileStream(reservationBinPath, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
           
                reservation = new Reservation()
                {
                    FlightCode = br.ReadString(),
                    Airline = br.ReadString(),
                    From = br.ReadString(),
                    To = br.ReadString(),
                    Day = br.ReadString(),
                    Time = br.ReadString(),
                    Cost = br.ReadString(),
                    Name = br.ReadString(),
                    Citizenship = br.ReadString(),
                    ReservationCode = br.ReadString(),
                    Status = br.ReadString()
                };

            br.Close();
            fs.Close();
            return reservation;
        }



        public async Task CreateReservation(Reservation reservation)
        {
            string reservationBinPath = Path.Combine(Directory.GetCurrentDirectory() +"\\Assets\\"+"Reservation.bin");
            FileStream fs = new FileStream(reservationBinPath, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);

            bw.Write(reservation.FlightCode!);
            bw.Write(reservation.Airline!);
            bw.Write(reservation.From!);
            bw.Write(reservation.To!);
            bw.Write(reservation.Day!);
            bw.Write(reservation.Time!);
            bw.Write(reservation.Cost!);
            bw.Write(reservation.Name!);
            bw.Write(reservation.Citizenship!);
            bw.Write(reservation.ReservationCode!);
            bw.Write(reservation.Status!);

            bw.Close();
            fs.Close();
        }
        

        
        public List<Flight> CreateFlight(string binFilePath, int linesNumber)
        {
            List<Flight> flights = new List<Flight>();
            FileStream fs = new FileStream(binFilePath, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);

            for (int i = 0; i < linesNumber; i++)
            {
                flights.Add(new Flight()
                {
                    FlightCode = br.ReadString(),
                    Airline = br.ReadString(),
                    From = br.ReadString(),
                    To = br.ReadString(),
                    Day = br.ReadString(),
                    Time = br.ReadString(),
                    ReservationCode = br.ReadString(),
                    Cost = br.ReadString(),

                });

            }

            return flights;
        }


        public void FlightCsvToBinary(string filePath, string binFilePath)
        {
            
            FileStream fs = new FileStream(binFilePath, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);

            using (var parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                parser.HasFieldsEnclosedInQuotes = true;


                while (!parser.EndOfData)
                {
                    var fields = parser.ReadFields();
                    bw.Write(fields![0]);
                    bw.Write(fields![1]);
                    bw.Write(fields![2]);
                    bw.Write(fields![3]);
                    bw.Write(fields![4]);
                    bw.Write(fields![5]);
                    bw.Write(fields![6]);
                    bw.Write(fields![7]);

                }

               

            }
            bw.Close();
            fs.Close();
        }


    }
}
