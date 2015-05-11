using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.PizzaStore
{
    public class NYPizzaStore : PizzaStore
    {
        public override Pizza CreatePizza(string type)
        {
            if (type == "cheese")
            {
                return new NYStyleCheesePizza();
            }
            else if (type == "pepperoni")
            {
                return new NYStylePepperoniPizza();
            }
            else if (type == "clam")
            {
                return new NYStyleClamPizza();
            }
            else if (type == "veggie")
            {
                return new NYStyleVeggiePizza();
            }
            else
            {
                return null;
            }
        }
    }
}
