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
            Pizza pizza = null;
            var ingredientFactory = new NYPizzaIngredientFactory();

            if (type == "cheese")
            {
                pizza = new CheesePizza(ingredientFactory)
                {
                    Name = "New York Style Cheese Pizza"
                };
            }
            else if (type == "pepperoni")
            {
                pizza = new PepperoniPizza(ingredientFactory)
                {
                    Name = "New York Style Pepperoni Pizza"
                };
            }
            else if (type == "clam")
            {
                pizza = new ClamPizza(ingredientFactory)
                {
                    Name = "New York Style Clam Pizza"
                };
            }
            else if (type == "veggie")
            {
                pizza = new VeggiePizza(ingredientFactory)
                {
                    Name = "New York Style Veggie Pizza"
                };
            }
            return pizza;
        }
    }
}
