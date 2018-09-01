using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text;

namespace RepositoryWebAPI {
    public class GuestWebAPI : IGuestR {
        string _ApiUrl;

        public GuestWebAPI(IRepoConnection aRepoConnection) {
            _ApiUrl = aRepoConnection.ConnectionString;
        }

        public void Add(Guest aGuest) {
            Task.Run(() => {
                List<Guest> vResult = new List<Guest>();

                using (var vHttp = new HttpClient()) {
                    vHttp.BaseAddress = new Uri(_ApiUrl);

                    //HTTP POST
                    var responseTask = vHttp.PostAsync("Guests", aGuest.ToStringContent()); //should await be used?
                    responseTask.Wait();
                    var vResponseTask = responseTask.Result;

                    if (vResponseTask.IsSuccessStatusCode) {

                        var readTask = vResponseTask.Content.ReadAsStringAsync();
                        readTask.Wait();

                        string vJson = readTask.Result;
                        return vResult.FromJson(vJson);
                    } else //web api sent error response 
                      {
                        return null;
                    }
                }
            });
        }

        public Task<int> CountAsync() {
            return Task.Run(() => {
                int vResult = 0;

                using (var vHttp = new HttpClient()) {
                    vHttp.BaseAddress = new Uri(_ApiUrl);

                    //HTTP GET
                    var responseTask = vHttp.GetAsync("count");
                    responseTask.Wait();
                    var vResponseTask = responseTask.Result;

                    if (vResponseTask.IsSuccessStatusCode) {

                        var readTask = vResponseTask.Content.ReadAsStringAsync();
                        readTask.Wait();

                        vResult = Convert.ToInt32(readTask.Result);
                        return vResult;
                    } else //web api sent error response 
                      {
                        return 0;
                    }
                }
            });

        }
        public void Delete(int aGuestId) {
             Task.Run( () => {
                List<Guest> vResult = new List<Guest>();

                using (var vHttp = new HttpClient()) {
                    vHttp.BaseAddress = new Uri(_ApiUrl);

                    //HTTP GET
                    var responseTask =  vHttp.DeleteAsync("Guests/" + aGuestId); //should await be used?
                    responseTask.Wait();  
                    var vResponseTask = responseTask.Result;

                    if (vResponseTask.IsSuccessStatusCode) {

                        var readTask = vResponseTask.Content.ReadAsStringAsync();
                        readTask.Wait();

                        string vJson = readTask.Result;
                        return vResult.FromJson(vJson);
                    } else //web api sent error response 
                      {
                        return null;
                    }
                }
            });
        }

        public Task<List<Guest>> GetAllAsync() {
            return Task.Run(() => {
                List<Guest> vResult = new List<Guest>();

                using (var vHttp = new HttpClient()) {
                    vHttp.BaseAddress = new Uri(_ApiUrl);

                    //HTTP GET
                    var responseTask = vHttp.GetAsync("Guests");
                    responseTask.Wait();
                    var vResponseTask = responseTask.Result;

                    if (vResponseTask.IsSuccessStatusCode) {

                        var readTask = vResponseTask.Content.ReadAsStringAsync();
                        readTask.Wait();

                        string vJson = readTask.Result;
                        return vResult.FromJson(vJson);
                    } else //web api sent error response 
                      {
                        return vResult;
                    }
                }
            });
        }

        public Task<Guest> GetAsync(int aGuestId) {
            return Task.Run(() => {
                Guest vResult = new Guest();

                using (var vHttp = new HttpClient()) {
                    vHttp.BaseAddress = new Uri(_ApiUrl);

                    //HTTP GET
                    var responseTask = vHttp.GetAsync("Guests/" + aGuestId);
                    responseTask.Wait();
                    var vResponseTask = responseTask.Result;

                    if (vResponseTask.IsSuccessStatusCode) {

                        var readTask = vResponseTask.Content.ReadAsStringAsync();
                        readTask.Wait();

                        string vJson = readTask.Result;
                        return vResult.FromJson(vJson);
                    } else //web api sent error response 
                      {
                        return null;
                    }
                }
            });
        }

        public void Update(Guest aGuest) {
            Task.Run(() => {
                List<Guest> vResult = new List<Guest>();

                using (var vHttp = new HttpClient()) {
                    vHttp.BaseAddress = new Uri(_ApiUrl);

                    //HTTP PUT
                    var responseTask = vHttp.PutAsync("Guests", aGuest.ToStringContent()); //should await be used?
                    responseTask.Wait();
                    var vResponseTask = responseTask.Result;

                    if (vResponseTask.IsSuccessStatusCode) {

                        var readTask = vResponseTask.Content.ReadAsStringAsync();
                        readTask.Wait();

                        string vJson = readTask.Result;
                        return vResult.FromJson(vJson);
                    } else //web api sent error response 
                      {
                        return null;
                    }
                }
            });
        }

    }
}



