using LoseWeight.App.Concrete;

public class Program
{
    public static void Main(string[] args)
    {
        MenuActionService menuActionService = new MenuActionService();
        ItemService itemService = new ItemService();
        DishService dishService = new DishService(menuActionService, itemService);
        CountService countService = new CountService(menuActionService, itemService);
       

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
                    countService.CountBMI();
                    break;
                case '2':
                    countService.CountBMR();
                    break;
                case '3':
                    var newId = dishService.AddDish();
                    break;
                case '4':
                    Console.WriteLine("Podaj Id dania do usunięcia: ");
                    var idForRemove = Console.ReadLine();
                    Int32.TryParse(idForRemove, out int id);
                    dishService.RemoveDish(id);
                    break;
                case '5':
                    var dishes = dishService.GetAlldishes();
                    Console.WriteLine("\nID|Name|Calories|Dish type");
                    foreach (var dish in dishes)
                    {
                        Console.WriteLine(dish.Id + "|" + dish.Name + "|" + dish.Calories + "|" + dish.Dishtype);
                    }
                    break;
                case '6':
                    countService.CountDishCalorific();
                    break;
                default:
                    Console.WriteLine("Action you entered does not exist");
                    break;
            }

        }
        

    }
        
    
  
}

