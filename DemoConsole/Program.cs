using System;
using System.Threading.Tasks;

namespace DemoConsole
{
    class Program
    {
        static void Main(string[] args)
        {



            //3 Pattern matching
            //type matching
            var area_Square = ComputeAreaModernIs(new Square(12));






            //const matching with null
       var     area_Square_null = ComputeAreaModernIs(null);






            //swich with when
            var area_Circle = ComputeArea_Switch(new Circle(0));







            //switch with data
            area_Circle = ComputeArea_Switch(new Circle(20));





            //var pattern

            var varPattern = 15;
            if (varPattern is var x)
            {
                Console.WriteLine($"It's a var pattern with the type { x}");
            }
           



        }


       

        public static double ComputeAreaModernIs(object shape)
        {
            if (shape is Square s)
                return s.Side * s.Side;
            else if (shape is Circle c)
                return c.Radius * c.Radius * Math.PI;
            else if (shape is Rectangle r)
                return r.Height * r.Length;
            else if (shape is null)
            {
               Console.WriteLine("Null parameter passed in");
            }
            // elided
            throw new ArgumentException(
                message: "shape is not a recognized shape",
                paramName: nameof(shape));
        }





        public static double ComputeArea_Switch(object shape)
        {
            switch (shape)
            {
                case Square s when s.Side == 0:
                case Circle c when c.Radius == 0:
                case Triangle t when t.Base == 0 || t.Height == 0:
                case Rectangle r when r.Length == 0 || r.Height == 0:
                    return 0;

                case Square s:
                    return s.Side * s.Side;
                case Circle c:
                    return c.Radius * c.Radius * Math.PI;
                case Triangle t:
                    return t.Base * t.Height * 2;
                case Rectangle r:
                    return r.Length * r.Height;
               //Const Pattern
                case null:
                    throw new ArgumentNullException(paramName: nameof(shape), message: "Shape must not be null");
                default:
                    throw new ArgumentException(
                        message: "shape is not a recognized shape",
                        paramName: nameof(shape));
            }
        }
    }
}
