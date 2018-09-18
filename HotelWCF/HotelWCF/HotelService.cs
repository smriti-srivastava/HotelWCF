using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace HotelWCF
{
    [DataContract]
    public class Hotel
    {
        [DataMember]
        public int HotelId;
        [DataMember]
        public string HotelName;
        [DataMember]
        public string HotelAddress;
        [DataMember]
        public string HotelRating;
    }

    [ServiceContract]
    public interface IHotelService
    {
        [OperationContract]
        Hotel GetHotelById(int id);
        [OperationContract]
        List<Hotel> GetAllHotels();

    }


    class HotelService : IHotelService
    {
        public List<Hotel> GetAllHotels()
        {
            using (StreamReader reader = new StreamReader(@"C:\Users\ssrivastava\source\repos\HotelWCF\HotelWCF\HotelList.json"))
            {
                var json = reader.ReadToEnd();
                List<Hotel> hotels = JsonConvert.DeserializeObject<List<Hotel>>(json);
                return hotels;
            }
        }

        public Hotel GetHotelById(int id)
        {
            List<Hotel> hotels = GetAllHotels();
            return hotels.Find(hotel => hotel.HotelId == id);
        }
    }
}
