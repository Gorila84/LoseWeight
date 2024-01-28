using LoseWeight.App.Common;
using LoseWeight.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoseWeight.App.Concrete
{
    public class MenuActionService : BaseService<MenuActions>
    {

        //public void AddAction(int id, string actionName, string menuName)
        //{
        //    MenuActions menuAction = new MenuActions() { Id = id, ActionName = actionName, MenuName = menuName };
        //    menuActions.Add(menuAction);
        //}
        public MenuActionService()
        {
            Initialize();
        }

        public List<MenuActions> GetMenuActionsByName(string name)
        {
            List<MenuActions> result = new List<MenuActions>();

            foreach (var menuAction in Items)
            {
                if (menuAction.MenuName == name)
                {
                    result.Add(menuAction);
                }
            }

            return result;
        }

        public List<MenuActions> GetMenuActionsByDishType(string name)
        {
            List<MenuActions> result = new List<MenuActions>();

            foreach (var menuAction in Items)
            {
                if (menuAction.Name == name)
                {
                    result.Add(menuAction);
                }
            }

            return result;
        }
        public double CountBMI()
        {
            Console.WriteLine("\n Get weight in KG (Separator should be a point)");
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
            Console.WriteLine("\nPlease anter yor sex M/F:");
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

        private void Initialize()
        {
            AddItem(new MenuActions(1, "Count BMI", "Main"));
            AddItem(new MenuActions(2, "Count BMR", "Main"));
            AddItem(new MenuActions(3, "Add dish to list", "Main"));
            AddItem(new MenuActions(4, "Remove dish from list", "Main"));
            AddItem(new MenuActions(5, "Show dish List", "Main"));
            AddItem(new MenuActions(6, "Count calorific value", "Main"));

            AddItem(new MenuActions(1, "Dairy", "Dish"));
            AddItem(new MenuActions(2, "Bread", "Dish"));
            AddItem(new MenuActions(3, "Meat", "Dish"));
            AddItem(new MenuActions(4, "All", "Dish"));
           


        }
    }

   

}
