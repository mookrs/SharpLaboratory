using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.PizzaStore
{
    public abstract class Pizza
    {
        public string Name { get; set; }
        public Dough Dough { get; set; }
        public Sauce Sauce { get; set; }
        public List<Veggies> Veggieses;
        public Cheese Cheese { get; set; }
        public Pepperoni Pepperoni { get; set; }
        public Clams Clam { get; set; }
        public List<string> Toppings = new List<string>();

        public abstract void Prepare();

        public void Bake()
        {
            Console.WriteLine("Bake for 25 minutes at 350");
        }

        public virtual void Cut()
        {
            Console.WriteLine("Cutting the pizza into diagonal slices");
        }

        public void Box()
        {
            Console.WriteLine("Place pizza in official PizzaStore box");
        }
    }
}
