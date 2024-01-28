using LoseWeight.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoseWeight.Domain.Entity
{
    public class Dish : BaseEntity
    {
        
        public int Calories { get; set; }
        public int Dishtype { get; set; }

        public Dish(int id, string name, int calories, int dishtype)
        {
            Id = id;
            Name = name;
            Calories = calories;
            Dishtype = dishtype;

        }
    }
}
