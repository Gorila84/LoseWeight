using LoseWeight.App.Abstract;
using LoseWeight.App.Managers;
using LoseWeight.Domain.Entity;

namespace LoseWeight.App.Concrete
{
    public class CountService
    {
        private readonly CountManager _countManager;

        public CountService(CountManager countManager)
        {
            _countManager = countManager;
        }
        public double CountBMI()
        {
            var person = _countManager.GetDataForCountingBMI();
            person.HeightValue = person.HeightValue / 100;
            double bmi = person.WeightValue / Math.Pow(person.HeightValue, 2);

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
            var person = _countManager.GetDataForCountingBMR();
            double femaleBmr = 655 + (9.6 * person.WeightValue) + (1.8 * person.HeightValue) - (4.7 * person.AgeValue);
            Console.WriteLine($"Your BMR is equal: {femaleBmr} kcal");
        }

       

        public void CountBmrMale()
        {

            var person = _countManager.GetDataForCountingBMR();
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
