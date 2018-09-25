using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.Entities;

namespace PetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        // GET api/pets
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get([FromQuery] Filter filter)
        {
            if (filter.CurrentPage <= 0 || filter.ItemsPerPage <= 0)
            {
                return _petService.GetPetsIncludeOwner();
            }
            return _petService.GetFilteredPets(filter);
        }

        // GET api/pets/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            var pet = _petService.GetPetByIdIncludeOwner(id);
            if (pet != null)
            {
                return pet;
            }
            else
            {
                return BadRequest($"There is no pet with Id: {id} in the database"); 
            }
          
        }

        // POST api/pets
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            pet.Id = 0;
            return _petService.NewPet(pet);
        }

        // PUT api/pets/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Pet pet)
        {
            var petToUpdate = _petService.GetPetById(id);
            pet.Id = petToUpdate.Id;
            _petService.UpdatePet(pet);
        }

        // DELETE api/pets/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _petService.DeletePet(id);
        }
    }
}
