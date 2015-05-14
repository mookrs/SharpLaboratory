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
            Pizza pizza = null;
            var ingredientFactory = new ChicagoPizzaIngredientFactory();

            if (type == "cheese")
            {
                pizza = new CheesePizza(ingredientFactory)
                {
                    Name = "Chicago Style Cheese Pizza"
                };
            }
            else if (type == "pepperoni")
            {
                pizza = new PepperoniPizza(ingredientFactory)
                {
                    Name = "Chicago Style Pepperoni Pizza"
                };
            }
            else if (type == "clam")
            {
                pizza = new ClamPizza(ingredientFactory)
                {
                    Name = "Chicago Style Clam Pizza"
                };
            }
            else if (type == "veggie")
            {
                pizza = new VeggiePizza(ingredientFactory)
                {
                    Name = "Chicago Style Veggie Pizza"
                };
            }
            return pizza;
        }
    }
}
