using LoseWeight.App.Abstract;
using LoseWeight.App.Concrete;
using LoseWeight.Domain.Entity;
using System.Collections.Generic;

namespace LoseWeight.App.Managers
{
    public class DishManager
    {
        private readonly MenuActionService _actionService;
        private IService<Dish> _itemService;
        private readonly DishService _dishService;

        
        public DishManager(MenuActionService actionService, IService<Dish> itemService)
        {
            
            _itemService = itemService;
            _actionService = actionService;


        }


        public Dish GetDataForAddDish()
        {
            var addNewDishItemMenu = _actionService.GetDishMenu();
            for (int i = 0; i < addNewDishItemMenu.Count; i++)
            {
                Console.WriteLine($"{addNewDishItemMenu[i].Id} {addNewDishItemMenu[i].Name}");
            }

            var operation = Console.ReadKey();
            Int32.TryParse(operation.KeyChar.ToString(), out int dishTypeId);
            Console.WriteLine("\n");
            Console.WriteLine("Please enter name for new dish: ");
            var name = Console.ReadLine();

            Console.WriteLine("Please enter the amount of calories per 100 grams of the dish: ");
            var calories = Console.ReadLine();
            Int32.TryParse(calories, out int caloriesValue);

            Console.WriteLine("Please enter the amount of carbohydrates per 100 grams of the dish: ");
            var carbohydrates = Console.ReadLine();
            double.TryParse(carbohydrates, out double carbohydratesValue);

            Console.WriteLine("Please enter the amount of protein per 100 grams of the dish: ");
            var protein = Console.ReadLine();
            double.TryParse(carbohydrates, out double proteinValue);

            Console.WriteLine("Please enter the amount of fat per 100 grams of the dish: ");
            var fat = Console.ReadLine();
            double.TryParse(fat, out double fatValue);
           

            Dish dish = new Dish(0, name,  caloriesValue, carbohydratesValue, proteinValue, fatValue, dishTypeId);

            return dish;
        }

        public void RemoveDish(int id)
        {
            var dish = _itemService.GetItemById(id);
            _itemService.DeleteItem(dish);
        }

        public List<Dish> GetAlldishes()
        {
            
            var dishes = _itemService.GetAllItems();


            return dishes;


        }

        

        public Dish GetDishById(int id)
        {
            var dish = _itemService.GetItemById(id);
            return dish;
        }
    }
}
