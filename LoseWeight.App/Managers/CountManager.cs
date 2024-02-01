using LoseWeight.App.Abstract;
using LoseWeight.App.Concrete;
using LoseWeight.Domain.Entity;

namespace LoseWeight.App.Managers
{
    public class CountManager
    {
        
        private readonly IService<Dish> _itemService;

        public CountManager(IService<Dish> itemService)
        {
            _itemService = itemService;
        }

        public double CountDishCalorificPerOneGram(Dish dish, int quantity)
        {

            double calorific = (double)(dish.Calories / 100.00) * quantity;
            return calorific;
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
            double calorific = CountDishCalorificPerOneGram(dish, dishGrams);
            Console.WriteLine($"Caloric content is equal: {calorific}");

        }

        public double CountBMI()
        {
            Console.WriteLine("Get weight in KG (Separator should be a point)");
            var weight = Console.ReadLine();
            int weightValue;
            Int32.TryParse(weight, out weightValue);
            Console.WriteLine("Get height in cm");
            var height = Console.ReadLine();
            double heightValue;
            double.TryParse(height, out heightValue);
            heightValue = heightValue / 100;
            double bmi = weightValue / Math.Pow(heightValue, 2);

            if (bmi >= 18.5 && bmi <= 24.99)
            {
                Console.WriteLine($"Your BMI is {bmi}. You heave correct weight \n");
            }
            else if (bmi >= 25.00 && bmi <= 29.99)
            {
                Console.WriteLine($"Your BMI is {bmi}. You are overweight \n");
            }
            else if (bmi >= 30.00 && bmi <= 34.99)
            {
                Console.WriteLine($"Your BMI is {bmi}. You have stage 1 obesity \n");
            }
            else if (bmi >= 35.00 && bmi <= 39.99)
            {
                Console.WriteLine($"Your BMI is {bmi}. You have stage 2 obesity \n");
            }
            return bmi;
        }

        public void CountBmrFemale()
        {
            var person = GetDataForCounting();
            double femaleBmr = 655 + (9.6 * person.WeightValue) + (1.8 * person.HeightValue) - (4.7 * person.AgeValue);
            Console.WriteLine($"Your BMR is equal: {femaleBmr} kcal");
        }

        public Person GetDataForCounting()
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

            person.AgeValue = ageValue;
            person.WeightValue = weightValue;
            person.HeightValue = heightValue;

            return person;
        }

        public void CountBmrMale()
        {

            var person = GetDataForCounting();
            double maleBmr = 66 + (13.7 * person.WeightValue) + (5 * person.HeightValue) - (6.8 * person.AgeValue);
            Console.WriteLine($"Your BMR is equal: {maleBmr} kcal");

        }

        public void CountBMR()
        {
            Console.WriteLine("Please anter yor sex M/F:");
            var sex = Console.ReadLine();
            if (sex.ToUpper() == "M")
            {
                CountBmrMale();
            }
            else if (sex.ToUpper() == "F")
            {
                CountBmrFemale();
            }
            else
            {
                Console.WriteLine("Action you entered does not exist");
            }
        }
    }
}
