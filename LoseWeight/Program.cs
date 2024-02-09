using LoseWeight.App.Concrete;
using LoseWeight.App.Managers;

public class Program
{
    public static void Main(string[] args)
    {
        MenuActionService menuActionService = new MenuActionService();
        ItemService itemService = new ItemService();
        DishManager dishManager = new DishManager(menuActionService, itemService);
        CountService countService = new CountService();
        CountManager countManager = new CountManager(itemService, countService);
        

        while (true)
        {
            Console.WriteLine("Hello in calorific value counter.");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Please select action");
            var mainMenu = menuActionService.GetMainMenu();
            for (int i = 0; i < mainMenu.Count; i++)
            {
                Console.WriteLine($"{mainMenu[i].Id} {mainMenu[i].Name}");
            }

            var operation = Console.ReadKey();
            
            switch (operation.KeyChar)
            {
                case '1':
                    Console.WriteLine("\n");
                    var personDataForBMI = countManager.GetDataForCountingBMI();
                    countService.CountBMI(personDataForBMI);
                    break;
                case '2':
                    Console.WriteLine("\n");
                    var personDataForBMR = countManager.GetDataForCountingBMR();
                    countService.CountBMR(personDataForBMR);
                    break;
                case '3':
                    Console.WriteLine("\n");
                    var newId = dishManager.AddDish();
                    break;
                case '4':
                    Console.WriteLine("\nPodaj Id dania do usunięcia: ");
                    var idForRemove = Console.ReadLine();
                    Int32.TryParse(idForRemove, out int id);
                    dishManager.RemoveDish(id);
                    break;
                case '5':
                    Console.WriteLine("\n");
                    var dishes = dishManager.GetAlldishes();
                    Console.WriteLine("\nID | Nazwa | Kalorie | Węglowodany | Białko | Tłuszcze | Kategoria");
                    foreach (var dish in dishes)
                    {
                        Console.WriteLine(dish.Id + " | " 
                                        + dish.Name + " | "
                                        + dish.Calories + " | "
                                        + dish.Carbohydrates + " | "
                                        + dish.Protein + " | "
                                        + dish.Fat + " | "
                                        + dish.Dishtype);
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

