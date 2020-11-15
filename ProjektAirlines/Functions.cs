using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektAirlines
{
    /// <summary>
    /// Klasa posiada 2 metody, , FlightPrice oblicza cene lotu
    /// </summary>
    public class Functions
    {
        /// <summary>
        /// Metoda Distance oblicza odleglosc lotu poprzez zamieniania pirwszej litery na liczbe calkowita z ASCII
        /// </summary>
        /// <param name="a">String miejscowosci do ktorej leci lot</param>
        /// <param name="b">String miejscowosci od ktorej leci lot</param>
        /// <returns>Liczba calkowita odleglosci dwoch miejscowosci</returns>
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

        /// <summary>
        /// Metoda FlightPrice oblicz cene lotu
        /// </summary>
        /// <param name="distance">Calkowita liczba obliczona przez metode Distance</param>
        /// <param name="seats">Ilosc siedzen wybranych na lot</param>
        /// <param name="b">Indeks wybranej klasy lotu</param>
        /// <returns>Calkowita cena za lot</returns>
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
