namespace DecoratorPattern
{
    public class Decat : Beverage
    {
        public Decat()
        {
            Description = "Decat";
        }

        public override double Cost()
        {
            return 1.05;
        }
    }
}