using Client.HotelServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            HotelServiceClient client = new HotelServiceClient("BasicHttpBinding_IHotelService");
            List<Hotel> hotels = new List<Hotel>(client.GetAllHotels());
            Console.WriteLine("--------------------------Available List of Hotels------------------------");
            foreach(Hotel hotel in hotels)
                Console.WriteLine("\n{0}. {1}", hotel.HotelId, hotel.HotelName);
            Console.WriteLine("\n\nEnter Hotel ID To Get Details : ");
            int id = int.Parse(Console.ReadLine());
            Hotel searchedHotel = client.GetHotelById(id);
            if (searchedHotel != null)
            {
                Console.WriteLine("\n-----------------------------Hotel Details---------------------------------");
                Console.WriteLine("Name : {0}\nAddress : {1}\nRating : {2}", searchedHotel.HotelName, searchedHotel.HotelAddress, searchedHotel.HotelRating);
            }
            else
                Console.WriteLine("\n\n----------------Hotel Not Found With Id {0}------------------------------", id);
            Console.ReadLine();
        }
    }
}
