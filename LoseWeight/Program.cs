

using LoseWeight;

public class Program
{
    public static void Main(string[] args)
    {
        MenuActionService menuActionService = new MenuActionService();
        DishService dishService = new DishService();
        menuActionService = Initialize(menuActionService, dishService);
        var mainMenu = menuActionService.GetMenuActionsByName("Main");
        
        Dish dish = new Dish();

        while (true)
        {
            Console.WriteLine("Hello in calorific value counter.");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Please select action");
            for (int i = 0; i < mainMenu.Count; i++)
            {
                Console.WriteLine($"{mainMenu[i].Id} {mainMenu[i].ActionName}");
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
                    var keyInfo = dishService.AddNewDishView(menuActionService);
                    dishService.AddDish(keyInfo.KeyChar);
                    break;
                case '4':
                    var dishId = dishService.RemoveDishView();
                    dishService.RemoveDish(dishId);
                    break;
                case '5':
                    menuActionService.AddAction(4, "All", "Dish");
                    var typeOfFood = dishService.AddNewDishView(menuActionService);
                    dishService.ShowAlldishes(typeOfFood.KeyChar);
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
        
    private static MenuActionService Initialize(MenuActionService menuActionService, DishService dishService)
    {
        menuActionService.AddAction(1, "Count BMI", "Main");
        menuActionService.AddAction(2, "Count BMR", "Main");
        menuActionService.AddAction(3, "Add dish to list", "Main");
        menuActionService.AddAction(4, "Remove dish from list", "Main");
        menuActionService.AddAction(5, "Show dish List", "Main");
        menuActionService.AddAction(6, "Count calorific value", "Main");

        menuActionService.AddAction(1, "Dairy", "Dish");
        menuActionService.AddAction(2, "Bread", "Dish");
        menuActionService.AddAction(3, "Meat", "Dish");
        Dish dish = new Dish() { Id = 1, Name = "swinia", Calories = 1234, Dishtype = 3 };
        Dish dish1 = new Dish() { Id = 2, Name = "kurczak", Calories = 234, Dishtype = 3 };
        Dish dish2 = new Dish() { Id = 3, Name = "chleb", Calories = 123, Dishtype = 2 };
        Dish dish3 = new Dish() { Id = 4, Name = "bułka", Calories = 34, Dishtype = 2 };
        
        dishService.AddDishSeedData(dish);
        dishService.AddDishSeedData(dish1);
        dishService.AddDishSeedData(dish2);
        dishService.AddDishSeedData(dish3);
        return menuActionService;

        

    }
    //static void Initialize()
    //{
    //    Console.WriteLine("1 Count BMI");
    //    Console.WriteLine("2 Count BMR");
    //    Console.WriteLine("3 Add dish to list");
    //    Console.WriteLine("4 Remove dish from list");
    //    Console.WriteLine("5 Edit dish");
    //    Console.WriteLine("6 Show dish List");
    //    Console.WriteLine("7 Count calorific value");
    //}
}

