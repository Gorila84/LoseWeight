using FluentAssertions;
using LoseWeight.App.Concrete;
using LoseWeight.Domain.Entity;

namespace LoseWeight.Test
{
    public class CountServiceTest
    {
        //[Fact]
        //public void CanCountDishCalorificPerOneGram()
        //{
        //    Dish dish = new Dish(1, "Kurczak", 345, 3);
        //    int quantity = 200;
        //    double result = 690;
        //    CountService countService = new CountService();

        //    var countCalorific = countService.CountDishCalorificPerOneGram(dish, quantity);

        //    countCalorific.Should().BeOfType(typeof(double));
        //    countCalorific.Should().Be(result);
        //}

        [Fact]
        public void CanGetDishForCount()
        {
           


        }

        [Fact]
        public void CountBMITest()
        {
            Person person = new Person()
            {
                WeightValue = 94,
                HeightValue = 176
            };

            double result = 30.34;

            CountService countService = new CountService();
            var countingResult = countService.CountBMI(person);

            
            countingResult.Should().BeOfType(typeof(double));
            countingResult.Should().Be(result);
        }

        [Fact]
        public void CountBMRMaleTest()
        {
            Person person = new Person()
            {
                WeightValue = 94,
                HeightValue = 176,
                AgeValue = 40,
                Sex = "M"
            };
            //1961,80
            double result = 1961.80;

            CountService countService = new CountService();
            var countingResult = countService.CountBMR(person);


            countingResult.Should().BeOfType(typeof(double));
            countingResult.Should().Be(result);
        }


        [Fact]
        public void CountBMRFemaleTest()
        {
            Person person = new Person()
            {
                WeightValue = 70,
                HeightValue = 160,
                AgeValue = 38,
                Sex = "F"
            };
            
            double result = 1436.40;

            CountService countService = new CountService();
            var countingResult = countService.CountBMR(person);


            countingResult.Should().BeOfType(typeof(double));
            countingResult.Should().Be(result);
        }


    }
}
