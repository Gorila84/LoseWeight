using LoseWeight.App.Abstract;
using LoseWeight.App.Managers;
using LoseWeight.Domain.Entity;

namespace LoseWeight.App.Concrete
{
    public class CountService
    {
        private readonly CountManager _countManager;

        public CountService()
        {
           
        }
        public double CountBMI(Person person)
        {
          
            person.HeightValue = person.HeightValue / 100;
            double result = person.WeightValue / Math.Pow(person.HeightValue, 2);
            double bmi = Math.Truncate(result * 100) / 100;
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

        public double CountBmrFemale(Person person)
        {
             
            double femaleBmr = 655 + (9.6 * person.WeightValue) + (1.8 * person.HeightValue) - (4.7 * person.AgeValue);
            double result = Math.Truncate(femaleBmr * 100) / 100;
            Console.WriteLine($"Your BMR is equal: {result} kcal");
            return result; 
        }

        public double CountDishCalorificPerOneGram(Dish dish, int quantity)
        {
            double calorific = (double)(dish.Calories / 100.00) * quantity;
            return calorific;
        }


        public double CountBmrMale(Person person)
        {
            double maleBmr = 66 + (13.7 * person.WeightValue) + (5 * person.HeightValue) - (6.8 * person.AgeValue);
            double result =  Math.Truncate(maleBmr * 100) / 100;
            Console.WriteLine($"Your BMR is equal: {result} kcal");
            return result;
        }

        public double CountBMR(Person person)
        {
            
            if (person.Sex == "M")
            {
               var bmr =  CountBmrMale(person);
                return bmr;
            }
            else if (person.Sex == "F")
            {
                var bmr = CountBmrFemale(person);
                return bmr;
            }
            else
            {
                Console.WriteLine("Action you entered does not exist");
                return 0.0;
            }

        }
    }
}
