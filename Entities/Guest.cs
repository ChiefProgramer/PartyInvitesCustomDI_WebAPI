using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Entities
{

	public class Guest { //could call this PartyGuest

		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public bool? WillAttend { get; set; }

		public override string ToString() {
			return "'" + Name + "','" + Email + "','" + Phone + "','" + System.Convert.ToInt32(WillAttend) +  "'";

		}


    }


    public static class Ext {
        public static string ToJson(this List<Guest> aFrom) {
            return Newtonsoft.Json.JsonConvert.SerializeObject(aFrom);
        }

        public static List<Guest> FromJson(this List<Guest> aTo, string aFrom) {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Guest>>(aFrom);
        }

        public static string ToJson(this Guest aFrom) {
            return Newtonsoft.Json.JsonConvert.SerializeObject(aFrom);
        }

        public static Guest FromJson(this Guest aTo, string aFrom) {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Guest>(aFrom);
        }

        public static StringContent ToStringContent(this Guest aFrom) {
            return new StringContent(aFrom.ToJson(), Encoding.UTF8, "application/json");
        }


    }
}