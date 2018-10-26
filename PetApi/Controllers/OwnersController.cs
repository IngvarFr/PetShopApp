using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.Entities;

namespace PetShopApp.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        IOwnerService _ownerService;

        public OwnersController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        // GET: api/Owners
        [Authorize]
        [HttpGet]
        public IEnumerable<Owner> Get()
        {
            return _ownerService.GetOwners();
        }

        // GET: api/Owners/5
        [Authorize(Roles = "Administrator")]
        [HttpGet("{id}", Name = "Get")]
        public Owner Get(int id)
        {
            return _ownerService.GetOwnerById(id);
        }

        // POST: api/Owners
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public Owner Post([FromBody] Owner owner)
        {
            return _ownerService.NewOwner(owner);
        }

        // PUT: api/Owners/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            if (_ownerService.GetOwnerById(id) != null)
            {
                owner.Id = id;
                return _ownerService.UpdateOwner(owner);

            }
            else
            {
                return BadRequest("No owner with that id");
            }
            
        }

        // DELETE: api/ApiWithActions/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _ownerService.DeleteOwner(id);
        }
    }
}
