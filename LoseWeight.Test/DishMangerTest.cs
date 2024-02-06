using FluentAssertions;
using LoseWeight.App.Abstract;
using LoseWeight.App.Concrete;
using LoseWeight.App.Managers;
using LoseWeight.Domain.Entity;
using Moq;

namespace LoseWeight.Test
{
    public class DishMangerTest
    {
        [Fact]
        public void CanAddItemToList()
        {
            Dish dish = new Dish(1, "Kurczak", 234, 2);
            var mock = new Mock<IService<Dish>>();

            mock.Setup(s => s.AddItem(dish));
            mock.Setup(m => m.GetItemById(1)).Returns(dish);
            var manager = new DishManager(new MenuActionService(), mock.Object);
            
            //mock.Verify(m => m.AddItem(dish));

            var returnedDish = manager.GetDishById(dish.Id);

            returnedDish.Should().BeOfType(typeof(Dish));
            returnedDish.Should().BeSameAs(dish);
            returnedDish.Should().NotBeNull();

        }

        [Fact]
        public void CanGetAllItems() 
        {

            List<Dish> dishes = new List<Dish>();
            dishes.Add(new Dish(1, "Kurczak", 345, 3));
            dishes.Add(new Dish(2, "Chleb", 234, 2));
            dishes.Add(new Dish(3, "Wieprzowina", 456, 3));
            var mock = new Mock<IService<Dish>>();
            
            mock.Setup(m => m.GetAllItems()).Returns(dishes);
            var manager = new DishManager(new MenuActionService(), mock.Object);

            var returnedDishList = manager.GetAlldishes();

            returnedDishList.Should().BeOfType(typeof(List<Dish>));
            returnedDishList.Should().NotBeNull().And.HaveCount(3);
            returnedDishList.Should().BeSameAs(dishes);
        }

        [Fact]
        public void CanDeleteItem()
        {
            Dish dish = new Dish(1, "Kurczak", 345, 3);
           
            var mock = new Mock<IService<Dish>>();

            mock.Setup(m => m.GetItemById(dish.Id)).Returns(dish);
            mock.Setup(m => m.DeleteItem(It.IsAny<Dish>()));
            var manager = new DishManager(new MenuActionService(), mock.Object);

            manager.RemoveDish(dish.Id);

            mock.Verify(m => m.DeleteItem(dish));

        }
        [Fact]
        public void CanGetDishById()
        {
            Dish dish = new Dish(1, "Kurczak", 345, 3);

            var mock = new Mock<IService<Dish>>();

            mock.Setup(m => m.GetItemById(dish.Id)).Returns(dish);

            var manager = new DishManager(new MenuActionService(), mock.Object);

            var returnedDish = manager.GetDishById(dish.Id);

            returnedDish.Should().BeOfType(typeof(Dish));
            returnedDish.Should().NotBeNull();
            returnedDish.Should().BeSameAs(dish);
        }
    }
}