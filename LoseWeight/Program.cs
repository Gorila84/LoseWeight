using LoseWeight.App.Concrete;
using LoseWeight.App.Managers;

public class Program
{
    public static void Main(string[] args)
    {
        MenuActionService menuActionService = new MenuActionService();
        ItemService itemService = new ItemService();
        DishManager dishManager = new DishManager(menuActionService, itemService);
        CountManager countManager = new CountManager(itemService);
       

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
                    Console.WriteLine("\n");
                    countManager.CountBMI();
                    break;
                case '2':
                    Console.WriteLine("\n");
                    countManager.CountBMR();
                    break;
                case '3':
                    Console.WriteLine("\n");
                    var newId = dishManager.AddDish();
                    break;
                case '4':
                    Console.WriteLine("\n");
                    dishManager.RemoveDish();
                    break;
                case '5':
                    Console.WriteLine("\n");
                    var dishes = dishManager.GetAlldishes();
                    Console.WriteLine("\nID|Name|Calories|Dish type");
                    foreach (var dish in dishes)
                    {
                        Console.WriteLine(dish.Id + "|" + dish.Name + "|" + dish.Calories + "|" + dish.Dishtype);
                    }
                    break;
                case '6':
                    Console.WriteLine("\n");
                    countManager.CountDishCalorific();
                    break;
                default:
                    Console.WriteLine("Action you entered does not exist");
                    break;
            }

        }
        

    }
        
    
  
}

