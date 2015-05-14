using System.Collections.Generic;

namespace FactoryPattern.PizzaStore
{
    public class ChicagoPizzaIngredientFactory : IPizzaIngredientFactory
    {
        public Dough CreateDough()
        {
            return new ThickCrustDough();
        }

        public Sauce CreateSauce()
        {
            return new PlumTomatoSauce();
        }

        public Cheese CreateCheese()
        {
            return new MozzarellaCheese();
        }

        public List<Veggies> CreateVeggieses()
        {
            return new List<Veggies>() { new Onion(), new Redpepper() };
        }

        public Pepperoni CreatePepperoni()
        {
            return new SlicedPepperoni();
        }

        public Clams CreateClam()
        {
            return new FrozenClams();
        }
    }
}