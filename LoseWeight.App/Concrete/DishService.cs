using LoseWeight.App.Abstract;
using LoseWeight.App.Common;
using LoseWeight.Domain.Entity;

namespace LoseWeight.App.Concrete
{
    public class DishService : BaseService<Dish>
    {
       
        public List<Dish> GetDishesFromCSV()
        {
            string MAIN_MENU_PATH = @"E:\SzkolaDoneta\LoseWeight\LoseWeight.App\Datas\dishes.csv";

            List<Dish> dishes = File.ReadLines(MAIN_MENU_PATH)
                                .Skip(1)
                                .Select(d => DishFromCSV(d))
                                .ToList();
            return dishes;
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
    }
}
