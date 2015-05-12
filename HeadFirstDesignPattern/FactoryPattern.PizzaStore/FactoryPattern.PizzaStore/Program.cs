using System;

namespace FactoryPattern.PizzaStore
{
    public class Program
    {
        private static void Main(string[] args)
        {
            PizzaStore nyPizzaStore = new NYPizzaStore();
            PizzaStore chicagoStore = new ChicagoPizzaStore();

            Pizza pizza = nyPizzaStore.OrderPizza("cheese");
            Console.WriteLine("Ethan ordered a " + pizza.Name + Environment.NewLine);

            pizza = chicagoStore.OrderPizza("cheese");
            Console.WriteLine("Joel ordered a " + pizza.Name + Environment.NewLine);

            Console.ReadKey();
        }
    }
}