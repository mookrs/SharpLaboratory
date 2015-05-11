using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.PizzaStore
{
    public abstract class PizzaStore
    {
        public Pizza OrderPizza(string type)
        {
            var pizza = CreatePizza(type);

            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();
            return pizza;
        }

        public abstract Pizza CreatePizza(string type);
    }
}
