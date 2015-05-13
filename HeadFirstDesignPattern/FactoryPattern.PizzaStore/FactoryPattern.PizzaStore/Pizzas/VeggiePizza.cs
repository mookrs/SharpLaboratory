using System;

namespace FactoryPattern.PizzaStore
{
    public class VeggiePizza : Pizza
    {
        private IPizzaIngredientFactory _ingredientFactory;

        public VeggiePizza(IPizzaIngredientFactory ingredientFactory)
        {
            _ingredientFactory = ingredientFactory;
        }

        public override void Prepare()
        {
            Console.WriteLine("Preparing " + Name);
            Veggieses = _ingredientFactory.CreateVeggieses();
        }
    }
}