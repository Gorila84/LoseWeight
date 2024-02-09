using LoseWeight.Domain.Common;

namespace LoseWeight.Domain.Entity
{
    public class Dish : BaseEntity
    {
        
        public int Calories { get; set; }
        public double Carbohydrates { get; set; }
        public double Protein { get; set; }
        public double Fat { get; set; }
        public int Dishtype { get; set; }

        public Dish(int id, 
                    string name, 
                    int calories, 
                    double carbohydrates, 
                    double protein, 
                    double fat, 
                    int dishtype)
        {
            Id = id;
            Name = name;
            Calories = calories;
            Dishtype = dishtype;
            Carbohydrates = carbohydrates;
            Protein = protein;
            Fat = fat;

        }

    }
}
