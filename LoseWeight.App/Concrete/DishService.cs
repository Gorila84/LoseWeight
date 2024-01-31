using LoseWeight.App.Abstract;
using LoseWeight.App.Common;
using LoseWeight.Domain.Entity;

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
            var addNewDishItemMenu = _actionService.GetMenuActionsByName("Dish");
            for (int i = 0; i < addNewDishItemMenu.Count; i++)
            {
                Console.WriteLine($"{addNewDishItemMenu[i].Id} {addNewDishItemMenu[i].Name}");
            }

            var operation = Console.ReadKey();
            Int32.TryParse(operation.KeyChar.ToString(), out int dishTypeId);

            Console.WriteLine("Please enter name for new dish: ");
            var name = Console.ReadLine();

            Console.WriteLine("Please enter the amount of calories per 100 grams of the dish: ");
            var calories = Console.ReadLine();
            
            Int32.TryParse(calories, out int caloriesValue);
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

        

        public List<Dish> GetAlldishes()
        {

            var dishes = _itemService.GetAllItems();
            return dishes;
            
            
        }

      

    }
}
