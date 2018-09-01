using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Microsoft.AspNetCore.Mvc;


namespace PartyInvitesAPI.Controllers {

    [Route("api/Guests")]
    public class PartyInvitesController : Controller {
        private readonly IGuestR _Repository; //Its a Singleton, so this is just reference to a single instance

        public PartyInvitesController(IGuestR aGuestR) {

            _Repository =
                aGuestR
                    ?? throw new ArgumentNullException(nameof(aGuestR));
        }

  
        [HttpGet]
        public IList<Guest> Get() {
            return _Repository.GetAllAsync().Result;
        }



        [HttpGet("{id}")]
        public Guest Get(int id) {
            return _Repository.GetAsync(id).Result;
        }

        [HttpPost]
        public void Post([FromBody]Guest aGuest) {
            if (ModelState.IsValid)
                _Repository.Add(aGuest);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Guest aGuest) {
            aGuest.Id = id;
            if (ModelState.IsValid)
                _Repository.Update(aGuest);
        }

        [HttpDelete("{id}")]
        public void Delete(int id) {
            _Repository.Delete(id);
        }
    }
}
