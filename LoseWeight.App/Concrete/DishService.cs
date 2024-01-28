using LoseWeight.App.Abstract;
using LoseWeight.App.Common;
using LoseWeight.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LoseWeight.App.Concrete
{
    public class DishService : BaseService<Dish>
    {
        private readonly MenuActionService _actionService;
        private IService<Dish> _itemService;
        public DishService(MenuActionService actionService, IService<Dish> itemService)
        {
            AddDishSeedData();
            _itemService = itemService;
            _actionService = actionService;
        }

         public void AddDishSeedData()
        {
            AddItem(new Dish(1, "swinia", 1234, 3));
            AddItem(new Dish(1, "kurczak", 234, 3));
            AddItem(new Dish(1, "chleb", 123, 2));
            AddItem(new Dish(1, "bułka", 34, 2));
        }
        public int AddDish()
        {
            int dishTypeId;
            int caloriesValue;

            var addNewDishItemMenu = _actionService.GetMenuActionsByName("Dish");
            for (int i = 0; i < addNewDishItemMenu.Count; i++)
            {
                Console.WriteLine($"{addNewDishItemMenu[i].Id} {addNewDishItemMenu[i].Name}");
            }

            var operation = Console.ReadKey();
            Int32.TryParse(operation.KeyChar.ToString(), out dishTypeId);

            Console.WriteLine("Please enter name for new dish: ");
            var name = Console.ReadLine();

            Console.WriteLine("Please enter the amount of calories per 100 grams of the dish: ");
            var calories = Console.ReadLine();
            
            Int32.TryParse(calories, out caloriesValue);
            var lastId = _itemService.GetLastId();

            Dish dish = new Dish(lastId + 1, name, caloriesValue, dishTypeId);
            _itemService.AddItem(dish);

            return dish.Id;
        }

        public void RemoveDish(int id)
        {
            var dish = _itemService.GetItemById(id);
            _itemService.DeleteItem(dish);
        }

        

        public List<Dish> ShowAlldishes()
        {

            var dishes = _itemService.GetAllItems();
            return dishes;
        }

        public double CountDishCalorificPerOneGram(Dish dish, int quantity)
        {
            
            double calorific = (double)(dish.Calories / 100.00) * quantity;
            return calorific;
        }

        public Dish GetDishForCount()
        {
            Console.WriteLine("Enter product name for count calorific:");
            var dishName = Console.ReadLine();
            var dishForCount = _itemService.GetItemByName(dishName);
            return dishForCount;

        }

        public void CountDishCalorific() 
        {
            Dish dish = GetDishForCount();
            Console.WriteLine("Enter product grams:");
            var grams = Console.ReadLine();
            int dishGrams;
            Int32.TryParse(grams, out dishGrams);
            double calorific = CountDishCalorificPerOneGram(dish, dishGrams);
            Console.WriteLine($"Caloric content is equal: {calorific}");

        }

    }
}
