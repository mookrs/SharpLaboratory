using System;

namespace FactoryPattern.PizzaStore
{
    public class PepperoniPizza : Pizza
    {
        private IPizzaIngredientFactory _ingredientFactory;

        public PepperoniPizza(IPizzaIngredientFactory ingredientFactory)
        {
            _ingredientFactory = ingredientFactory;
        }

        public override void Prepare()
        {
            Console.WriteLine("Preparing " + Name);
            Dough = _ingredientFactory.CreateDough();
            Sauce = _ingredientFactory.CreateSauce();
            Pepperoni = _ingredientFactory.CreatePepperoni();
        }
    }
}