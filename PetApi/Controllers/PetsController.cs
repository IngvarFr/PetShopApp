﻿using System;
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
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return _petService.GetPets();
        }

        // GET api/pets/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            return _petService.GetPetById(id);
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