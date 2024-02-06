using FluentAssertions;
using LoseWeight.App.Abstract;
using LoseWeight.App.Concrete;
using LoseWeight.App.Managers;
using LoseWeight.Domain.Entity;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoseWeight.Test
{
    public class CountMangerTest
    {
        [Fact]
        public void CanCountDishCalorificPerOneGram()
        {
            Dish dish = new Dish(1, "kurczak", 239, 3);
            var mock = new Mock<IService<Dish>>();

            mock.Setup(m => m.GetItemByName(dish.Name)).Returns(dish);
            var manager = new CountManager(mock.Object);

            var countCaloryfic = manager.CountDishCalorificPerOneGram(dish, 200);

            
            countCaloryfic.Should().BeOfType(typeof(double));
            countCaloryfic.Should().BeGreaterThanOrEqualTo(478);
        }

        [Fact]
        public void CanGetDishForCount()
        {
            Dish dish = new Dish(1, "kurczak", 239, 3);
            var mock = new Mock<IService<Dish>>();

            mock.Setup(m => m.GetItemByName(dish.Name)).Returns(dish);
            var manager = new CountManager(mock.Object);

            var returnedDish = manager.GetDishForCount();

            returnedDish.Should().BeOfType(typeof(Dish));

        }



    }
}
