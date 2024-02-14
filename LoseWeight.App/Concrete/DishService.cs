using LoseWeight.App.Abstract;
using LoseWeight.App.Common;
using LoseWeight.Domain.Entity;
using System.Xml.Linq;

namespace LoseWeight.App.Concrete
{
    public class DishService : BaseService<Dish>
    {
        string DISH_PATH = @"E:\SzkolaDoneta\LoseWeight\LoseWeight.App\Datas\dishes.csv";
        private readonly ItemService _itemService;

        public DishService(ItemService itemService)
        {
            _itemService = itemService;
        }
        public List<Dish> GetDishesFromCSV()
        {
            if(File.Exists(DISH_PATH))
            {
                List<Dish> dishes = File.ReadLines(DISH_PATH)
                               .Select(d => DishFromCSV(d))
                               .ToList();
                return dishes;
            }else { return new List<Dish>(); }
           

           
        }

        public Dish DishFromCSV(string csvLine)
        {
            string[] values = csvLine.Split(';');
            int id = Int32.Parse(values[0]);
            string name = values[1];
            int kal = Int32.Parse(values[2]);
            double wegel = double.Parse(values[3]);
            double bialko = double.Parse(values[4]);
            double tluszcz = double.Parse(values[5]);
            int kat = Int32.Parse(values[6]);
            Dish dish = new Dish(
                Int32.Parse(values[0]),
                values[1],
                Int32.Parse(values[2]),
                double.Parse(values[3]),
                double.Parse(values[4]),
                double.Parse(values[5]),
                Int32.Parse(values[6])
                );
            return dish;
        }

        public int AddDish(Dish dish)
        {
            List<Dish> dishes = GetDishesFromCSV();
            if (!File.Exists(DISH_PATH))
            {
                var myFile = File.Create(DISH_PATH);
                myFile.Close();
            }
            int lastId;
            if (dishes.Any())
            {
                lastId = dishes.OrderBy(p => p.Id).LastOrDefault().Id;
            }
            else
            {
                lastId = 0;
            }

            using StreamWriter sw = File.AppendText(DISH_PATH);
            string lineForAdd = (lastId + 1) + ";" + dish.Name + ";" + dish.Calories + ";" + dish.Carbohydrates + ";" + dish.Protein + ";" + dish.Fat + ";" + dish.Dishtype;
            sw.WriteLine(lineForAdd);

            return dish.Id;
        }

        public void RemoveDish(int id)
        {
            List<Dish> dishes = GetDishesFromCSV();
            string[] dishesForAdd;
            using StreamWriter sw = File.AppendText(DISH_PATH);

            var dishForRemove = dishes.FirstOrDefault(y => y.Id == id);
            if (dishForRemove != null)
            {
                dishes.Remove(dishForRemove);
                
            }
            sw.Close();
            File.Delete(DISH_PATH);
           
            foreach (var dish in dishes)
            {
                AddDish(dish);
               
            }

        }

        public Dish GetDisghById(int  id)
        {            
            Dish dish = File.ReadLines(DISH_PATH)
                            .Select(d => DishFromCSV(d))
                            .FirstOrDefault(y => y.Id == id);
            return dish;
           
        }

      
    }
}
