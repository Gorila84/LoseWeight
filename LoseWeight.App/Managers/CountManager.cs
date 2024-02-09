using LoseWeight.App.Abstract;
using LoseWeight.App.Concrete;
using LoseWeight.Domain.Entity;

namespace LoseWeight.App.Managers
{
    public class CountManager
    {
        
        private readonly IService<Dish> _itemService;
        private readonly CountService _countService;

        public CountManager(IService<Dish> itemService, CountService countService)
        {
            _itemService = itemService;
            _countService = countService;
        }

    

        public Dish GetDishForCount()
        {
            Console.WriteLine("Enter product name for count calorific:");
            var dishName = Console.ReadLine();
            var dishForCount = _itemService.GetItemByName(dishName);
            return dishForCount;

        }

        public void CountDishCalorific()
        {
            Dish dish = GetDishForCount();
            Console.WriteLine("Enter product grams:");
            var grams = Console.ReadLine();
            int dishGrams;
            Int32.TryParse(grams, out dishGrams);
            double calorific = _countService.CountDishCalorificPerOneGram(dish, dishGrams);
            Console.WriteLine($"Caloric content is equal: {calorific}");

        }

        public Person GetDataForCountingBMI()
        {
            Console.WriteLine("Get weight in KG (Separator should be a point)");
            var weight = Console.ReadLine();
            double.TryParse(weight, out double weightValue);
            Console.WriteLine("Get height in cm");
            var height = Console.ReadLine();
            Int32.TryParse(height, out int heightValue);

            Person person = new Person()
            {
                HeightValue = heightValue,
                WeightValue = weightValue,
            };

            return person;
        }

        public Person GetDataForCountingBMR()
        {
            Person person = new Person();

            double weightValue;
            double heightValue;
            int ageValue;
            Console.WriteLine("Get weight in KG (Separator should be a point)");
            var weight = Console.ReadLine();
            double.TryParse(weight, out weightValue);
            Console.WriteLine("Get height in cm");
            var height = Console.ReadLine();
            double.TryParse(height, out heightValue);
            //heightValue = heightValue / 100;
            Console.WriteLine("Get your age");
            var age = Console.ReadLine();
            Int32.TryParse(age, out ageValue);
            Console.WriteLine("Please anter yor sex M/F:");
            var sex = Console.ReadKey();

            person.AgeValue = ageValue;
            person.WeightValue = weightValue;
            person.HeightValue = heightValue;
            person.Sex = sex.KeyChar.ToString().ToUpper();

            return person;
        }

       
    }
}
