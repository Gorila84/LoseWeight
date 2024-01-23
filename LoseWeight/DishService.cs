using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LoseWeight
{
    public class DishService
    {
        public List<Dish> Dishes {  get; set; }
        public DishService()
        {
            Dishes = new List<Dish>();
        }

        public ConsoleKeyInfo AddNewDishView(MenuActionService menuActionService)
        {
            var addNewDishItemMenu = menuActionService.GetMenuActionsByName("Dish");
            for (int i = 0; i < addNewDishItemMenu.Count; i++)
            {
                Console.WriteLine($"{addNewDishItemMenu[i].Id} {addNewDishItemMenu[i].ActionName}");
            }

            var operation = Console.ReadKey();
            return operation;
        }

        public void AddDishSeedData(Dish dish)
        {
            Dishes.Add(dish);
        }
        public void AddDish(char dishType)
        {
            int dishTypeId;
            Int32.TryParse(dishType.ToString(), out dishTypeId);
            Dish dish = new Dish();
            dish.Id = dishTypeId;
            Console.WriteLine("Please enter id for new dish: ");
            var id = Console.ReadLine();
            int dishId;
            Int32.TryParse(id, out dishId);
            Console.WriteLine("Please enter name for new dish: ");
            var name = Console.ReadLine();
            Console.WriteLine("Please enter the amount of calories per 100 grams of the dish: ");
            var calories = Console.ReadLine();
            int caloriesValue;
            Int32.TryParse(calories, out caloriesValue);


            dish.Id = dishId;
            dish.Name = name;
            dish.Calories = caloriesValue;
            dish.Dishtype = dishTypeId;

           Dishes.Add(dish);

        }

        public int RemoveDishView()
        {
            Console.WriteLine("Please enter dish id for remove: ");
            var dishId = Console.ReadKey();
            int id;
            Int32.TryParse(dishId.KeyChar.ToString(), out id);

            return id;
        }

        public void RemoveDish(int dishId)
        {
            Dish dishForRemove = new Dish();

            foreach (var dish in Dishes) 
            {
                if(dish.Id == dishId)
                {
                    dishForRemove = dish;
                    break;
                }
            }
            Dishes.Remove(dishForRemove);
        }

        public void ShowAlldishes(char dishType)
        {
            int dishTypeNumber;
            Int32.TryParse(dishType.ToString(), out dishTypeNumber);
            foreach (var dish in Dishes)
            {
                if(dish.Dishtype == dishTypeNumber)
                {
                    Console.WriteLine($"\n{dish.Name} | {dish.Calories} | {dish.Dishtype}");
                }
                else if(dishTypeNumber == 4)
                {
                    Console.WriteLine($"\n{dish.Name} | {dish.Calories} | {dish.Dishtype}");
                }
            }

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
            Dish dishForCount = new Dish();
            foreach (var dish in Dishes)
            {
                if(dish.Name.ToLower() == dishName.ToLower())
                {
                    dishForCount = dish;
                }
            }
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
