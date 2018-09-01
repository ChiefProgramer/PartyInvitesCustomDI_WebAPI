using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;



namespace ExtensionMethoids {
    public static class Extensions {

        public static string ToJson(this List<string> aFrom) {
            return Newtonsoft.Json.JsonConvert.SerializeObject(aFrom);
        }

        public static List<string> FromJson(this List<string> aTo, string aFrom) {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(aFrom);
        }




    }

}