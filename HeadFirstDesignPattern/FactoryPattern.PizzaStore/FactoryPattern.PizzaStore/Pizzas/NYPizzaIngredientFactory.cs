using System.Collections.Generic;

namespace FactoryPattern.PizzaStore
{
    public class NYPizzaIngredientFactory : IPizzaIngredientFactory
    {
        public Dough CreateDough()
        {
            return new ThinCrustDough();
        }

        public Sauce CreateSauce()
        {
            return new MarinaraSauce();
        }

        public Cheese CreateCheese()
        {
            return new ReggianoCheese();
        }

        public List<Veggies> CreateVeggieses()
        {
            return new List<Veggies>() { new Garlic(), new Onion(), new Mushroom(), new Redpepper() };
        }

        public Pepperoni CreatePepperoni()
        {
            return new SlicedPepperoni();
        }

        public Clams CreateClam()
        {
            return new FreshClams();
        }
    }
}