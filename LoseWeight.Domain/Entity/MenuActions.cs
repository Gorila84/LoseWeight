using LoseWeight.Domain.Common;

namespace LoseWeight.Domain.Entity
{
    public class MenuActions : BaseEntity
    {
       
        public string Name { get; set; }
        public string MenuName { get; set; }
        public MenuActions(int id, string name, string menuName)
        {
            Id = id;
            Name = name;
            MenuName = menuName;
        }


    }
}
