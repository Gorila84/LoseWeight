using LoseWeight.App.Abstract;
using LoseWeight.App.Concrete;
using LoseWeight.Domain.Entity;

namespace LoseWeight.App.Managers
{
    public class DishManager
    {
        private readonly MenuActionService _actionService;
        private IService<Dish> _itemService;
        public DishManager(MenuActionService actionService, IService<Dish> itemService)
        {
            
            _itemService = itemService;
            _actionService = actionService;
        }

        public int AddDish()
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
            var lastId = _itemService.GetLastId();

            Dish dish = new Dish(lastId + 1, name,  caloriesValue, 1.1, 2.2, 3.3, dishTypeId);
            _itemService.AddItem(dish);

            return dish.Id;
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
