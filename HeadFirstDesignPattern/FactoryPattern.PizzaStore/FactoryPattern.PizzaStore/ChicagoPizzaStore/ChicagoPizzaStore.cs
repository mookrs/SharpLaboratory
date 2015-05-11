using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.PizzaStore
{
    public class ChicagoPizzaStore : PizzaStore
    {
        public override Pizza CreatePizza(string type)
        {
            if (type == "cheese")
            {
                return new ChicagoStyleCheesePizza();
            }
            else if (type == "pepperoni")
            {
                return new ChicagoStylePepperoniPizza();
            }
            else if (type == "clam")
            {
                return new ChicagoStyleClamPizza();
            }
            else if (type == "veggie")
            {
                return new ChicagoStyleVeggiePizza();
            }
            else
            {
                return null;
            }
        }
    }
}
