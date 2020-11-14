using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektAirlines
{
    public class Functions
    {
        //Oblicza "odleglosc" lotu
        public int Distance(string a, string b)
        {
            int arrival = 0, destination = 0, distance = 0;

            char[] charArra = a.ToCharArray();
            char[] charArrb = b.ToCharArray();

            arrival = Convert.ToInt32(charArra[0]);
            destination = Convert.ToInt32(charArrb[0]);

            distance = (arrival + destination);

            return distance;
        }

        //Oblicza cene lotu
        public int FlightPrice(int distance, decimal seats, int b)
        {
            int nrSeats = 0, fullPrice = 0, fuelPrice = 2;

            nrSeats = Convert.ToInt32(seats);

            if (b == 0)
                fullPrice = (distance * fuelPrice * nrSeats);
            else if (b == 1)
                fullPrice = (distance * fuelPrice * nrSeats) + 500;
            else if (b == 2)
                fullPrice = (distance * fuelPrice * nrSeats) + 1500;

            return fullPrice;
        }

    }
}
