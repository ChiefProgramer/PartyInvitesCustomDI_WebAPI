using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PartyInvitesAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Count")]
    public class CountController : Controller
    {

        private readonly IGuestR _Repository; //Its a Singleton, so this is just reference to a single instance

        public CountController(IGuestR aGuestR) {           
            _Repository =
                aGuestR
                    ?? throw new ArgumentNullException(nameof(aGuestR));
        }

        [HttpGet]
        public int Get() {
            return _Repository.CountAsync().Result;
        }

    }
}