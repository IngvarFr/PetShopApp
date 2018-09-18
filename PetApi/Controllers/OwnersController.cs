using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [HttpGet]
        public IEnumerable<Owner> Get()
        {
            return _ownerService.GetOwners();
        }

        // GET: api/Owners/5
        [HttpGet("{id}", Name = "Get")]
        public Owner Get(int id)
        {
            return _ownerService.GetOwnerById(id);
        }

        // POST: api/Owners
        [HttpPost]
        public Owner Post([FromBody] Owner owner)
        {
            return _ownerService.NewOwner(owner);
        }

        // PUT: api/Owners/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Owner owner)
        {
            var ownerToUpdate = _ownerService.GetOwnerById(id);
            owner.Id = ownerToUpdate.Id;
            _ownerService.UpdateOwner(owner);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _ownerService.DeleteOwner(id);
        }
    }
}
