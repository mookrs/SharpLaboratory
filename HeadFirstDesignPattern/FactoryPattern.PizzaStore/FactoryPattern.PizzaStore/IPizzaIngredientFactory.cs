﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.PizzaStore
{
    public interface IPizzaIngredientFactory
    {
        Dough CreateDough();
        Sauce CreateSauce();
        Cheese CreatteCheese();
        List<Veggies> CreateVeggieses();
        Pepperoni CreatePepperoni();
        Clams CreateClams();
    }
}
