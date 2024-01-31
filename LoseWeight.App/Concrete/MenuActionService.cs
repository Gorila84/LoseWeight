using LoseWeight.App.Common;
using LoseWeight.Domain.Entity;

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
