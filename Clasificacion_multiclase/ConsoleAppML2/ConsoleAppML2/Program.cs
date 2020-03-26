using System;
using ConsoleAppML2ML.Model;

namespace ConsoleAppML2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string opcion = "1";

            while (opcion != "0")
            {
                Console.WriteLine("Tiempo de anticipacion: ");
                string leadTime = Console.ReadLine();
                Console.WriteLine("Cuarto reservado: ");
                string cuartoReservado = Console.ReadLine();
                Console.WriteLine("Precio promedio: ");
                string adr = Console.ReadLine();
                Console.WriteLine("Country: ");
                string country = Console.ReadLine();
                Console.WriteLine("Cambios previos: ");
                string cambiosPrevios = Console.ReadLine();


                ModelInput bookingData = CreateBookingData(leadTime, cuartoReservado, cambiosPrevios, adr, country);

                ModelOutput bookingPredict = PredecirCambioReserva(bookingData);

                Console.WriteLine($"\n\nActual Reservation_status: {bookingData.Reservation_status} \nPredicted Reservation_status value {bookingPredict.Prediction} \nPredicted Reservation_status scores: [{String.Join(",", bookingPredict.Score)}]\n\n");

                opcion = Console.ReadLine();
            }
        }

        private static ModelInput CreateBookingData(string leadTime, string cuartoReservado, string cambiosPrevios, string adr, string country)
        {
            return new ModelInput()
            {
                Lead_time = (float)Convert.ToDecimal(leadTime),
                Reserved_room_type = cuartoReservado,
                Assigned_room_type = cuartoReservado,
                Booking_changes = (float)Convert.ToDecimal(cambiosPrevios),
                Adr = (float)Convert.ToDecimal(adr),
                Country = country,

                Hotel = "Resort Hotel",
                Arrival_date_month = "July",
                Arrival_date_week_number = 27,
                Arrival_date_day_of_month = 1,
                Stays_in_weekend_nights = 0,
                Stays_in_week_nights = 4,
                Children = 0,
                Babies = 0,
                Meal = "BB",
                Market_segment = "Online TA",
                Distribution_channel = "TA/TO",
                Is_repeated_guest = 0,
                Previous_bookings_not_canceled = 0,
                Previous_cancellations = 0,
                Adults = 2,
                Deposit_type = "No Deposit",
                Agent = "240",
                Days_in_waiting_list = 0,
                Customer_type = "Transient",
                Required_car_parking_spaces = 0,
                Total_of_special_requests = 0,
                Reservation_status = ""

            };
        }

        private static ModelOutput PredecirCambioReserva(ModelInput bookingData)
        {
            return ConsumeModel.Predict(bookingData);
        }
    }
}
