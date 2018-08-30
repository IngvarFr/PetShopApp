using PetShopApp.Core.ApplicationService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PetShopApp.Core.Entities;

namespace PetShopApp.UI
{
    class Printer : IPrinter
    {
        private IPetService _petService;

        public Printer(IPetService petService)
        {
            _petService = petService;
        }

        public void InitUI()
        {
            DoSelection();
        }

        public void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Pet Shop");
            Console.WriteLine("-----------------------");
            Console.WriteLine("1: Create a pet");
            Console.WriteLine("2: List all pets");
            Console.WriteLine("3: List all pets by price");
            Console.WriteLine("4: Search pets by type");
            Console.WriteLine("5: Update a pet");
            Console.WriteLine("6: Delete a pet");
            Console.WriteLine("7: Show the five cheapest pets");
            Console.WriteLine("8: Exit");
            Console.WriteLine("-----------------------");
            Console.WriteLine("What would you like to do?");
        }
        
        public void DoSelection()
        {
            bool exit = false;

            while (!exit)
            {
                PrintMenu();
                int sel;
                int.TryParse(Console.ReadLine(), out sel);

                switch (sel)
                {
                    case 1:
                        NewPet();
                        break;

                    case 2:
                        PrintAllPets();
                        break;

                    case 3:
                        PrintPets(_petService.GetPetsByPrice());
                        break;

                    case 4:
                        SearchPetsByType();
                        break;

                    case 5:
                        UpdatePet();
                        break;

                    case 6:
                        DeletePet();
                        break;

                    case 7:
                        PrintFiveCheapest();
                        break;

                    case 8:
                        exit = true;
                        Console.WriteLine("Good bye");
                        Console.ReadLine();
                        break;

                    default:
                        Console.WriteLine("Make a valid selection");
                        break;
                }
            }
        }

        private void PrintFiveCheapest()
        {
            PrintPets(_petService.GetFiveCheapest());
        }

        private void UpdatePet()
        {
            Console.Clear();
            Console.WriteLine("What is the id of the pet you want to update?");
            int id;
            int.TryParse(Console.ReadLine(), out id);
            var updatePet = _petService.GetPetById(id);
            if (updatePet != null)
            {
                Console.Clear();
                Console.WriteLine("What is the pet's new name?");
                var name = Console.ReadLine();
                Console.WriteLine("What is the pet's new type?");
                var type = Console.ReadLine();
                Console.WriteLine("What is the pet's new birthday? (Write in dd/MM/YYYY format)");
                var birthday = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("What is the pet's new color?");
                var color = Console.ReadLine();
                Console.WriteLine("What is the pet's new price?");
                int price;
                int.TryParse(Console.ReadLine(), out price);
                updatePet.Name = name;
                updatePet.Type = type;
                updatePet.Birthdate = birthday;
                updatePet.Color = color;
                updatePet.Price = price;
                _petService.UpdatePet(updatePet);
                Console.WriteLine("The pet was updated");
            }
            else
            {
                Console.WriteLine("There is no pet with that id");
            }
            Console.ReadLine();
        }

        private void DeletePet()
        {
            Console.Clear();
            Console.WriteLine("What is the id of the pet you want to delete?");
            int id;
            int.TryParse(Console.ReadLine(), out id);
            var deletedVideo = _petService.DeletePet(id);
            if (deletedVideo != null)
            {
                Console.WriteLine("The pet was deleted");
            }
            else
            {
                Console.WriteLine("There is no pet with that id");
            }
            Console.ReadLine();
        }

        private void NewPet()
        {
            Console.Clear();
            Console.WriteLine("What is the pet's name?");
            var name = Console.ReadLine();
            Console.WriteLine("What is the pet's type?");
            var type = Console.ReadLine();
            Console.WriteLine("What is the pet's birthday? (Write in dd/MM/YYYY format)");
            var birthday = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("What color is the pet?");
            var color = Console.ReadLine();
            Console.WriteLine("What is the price of the pet?");
            int price;
            int.TryParse(Console.ReadLine(), out price);
            var pet = new Pet() { Name = name, Type = type, Birthdate = birthday, Color = color, Price = price };
            _petService.NewPet(pet);
            Console.WriteLine("The pet has been added");
            Console.ReadLine();
        }

        private void SearchPetsByType()
        {
            Console.Clear();
            Console.WriteLine("Enter the type of animal you want to search for:");
            var type = Console.ReadLine().ToLower();
            var typeList = _petService.SearchByType(type);
            if (typeList.Count == 0)
            {
                Console.WriteLine("There were no animals of that type");
                Console.ReadLine();
            }
            else
            {
                PrintPets(typeList);
            }
        }

        public void PrintPets(List<Pet> pets)
        {
            Console.Clear();
            Console.WriteLine("------------------------------------------------------------------------------------");
            foreach(Pet pet in pets)
            {
                Console.WriteLine($"Id: {pet.Id}  Name: {pet.Name}  Type: {pet.Type}  Birthday: {pet.Birthdate.ToShortDateString()}  Price: {pet.Price}");
                Console.WriteLine("------------------------------------------------------------------------------------");
            }
            Console.ReadLine();
        }

        public void PrintAllPets()
        {
            PrintPets(_petService.GetPets());
        }
    }
}
