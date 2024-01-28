

using LoseWeight.App.Concrete;
using LoseWeight.Domain.Entity;

public class Program
{
    public static void Main(string[] args)
    {
        MenuActionService menuActionService = new MenuActionService();
        ItemService itemService = new ItemService();
        DishService dishService = new DishService(menuActionService, itemService);
       

        while (true)
        {
            Console.WriteLine("Hello in calorific value counter.");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Please select action");
            var mainMenu = menuActionService.GetMenuActionsByName("Main");
            for (int i = 0; i < mainMenu.Count; i++)
            {
                Console.WriteLine($"{mainMenu[i].Id} {mainMenu[i].Name}");
            }

            var operation = Console.ReadKey();
            
            switch (operation.KeyChar)
            {
                case '1':
                    menuActionService.CountBMI();
                    break;
                case '2':
                    menuActionService.CountBMR();
                    break;
                case '3':
                    var newId = dishService.AddDish();
                    break;
                case '4':
                    var dishId = dishService.RemoveDishView();
                    dishService.RemoveDish(dishId);
                    break;
                case '5':
                    var dishes = dishService.GetAllItems();
                    //menuActionService.AddAction(4, "All", "Dish");
                    //var typeOfFood = dishService.AddNewDishView(menuActionService);
                    //dishService.ShowAlldishes(typeOfFood.KeyChar);
                    break;
                case '6':
                    dishService.CountDishCalorific();
                    break;
                default:
                    Console.WriteLine("Action you entered does not exist");
                    break;
            }

        }
        

    }
        
    
  
}

