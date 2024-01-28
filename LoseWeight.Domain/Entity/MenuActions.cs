using LoseWeight.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
