using System;
using System.Threading.Tasks;

namespace DemoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Out variable
            //WriteNumericResult("180");
            //2. Tuples
            //TuplesDemo();


            //3 Pattern matching
            //type matching
            //var area_Square = ComputeAreaModernIs(new Square(12));

            //const matching with null
            //area_Square = ComputeAreaModernIs(null);

            //swich with when
            //var area_Circle = ComputeArea_Switch(new Circle(0));

            //switch with data
          var  area_Circle = ComputeArea_Switch(new Circle(20));

            var varPattern = 15;
            if (varPattern is var x)
            {
                Console.WriteLine($"It's a var pattern with the type { x}");
            }
            //4. Local functions
            //var fib = SqRt(13);



        }


        #region Out Variable
        private static void WriteNumericResult(string input)
        {
            #region Prior to C#7
            //int numericResult;
            //if (int.TryParse(input, out numericResult))
            //    Console.WriteLine(numericResult);

            //else
            //    Console.WriteLine("Could not parse input");
            //Console.ReadLine();
            #endregion

            #region c# 7
            if (int.TryParse(input, out int result))
                Console.WriteLine(result);
            else
                Console.WriteLine("Could not parse input");
            Console.ReadLine();
            #endregion
        } 
        #endregion

        #region Tuples
        private static void TuplesDemo()
        {
            #region Assign
            //Assign variable
            var tupleLetters = ("a", "b");

            #endregion


            #region Assign named tuple
            //named variables
            var namedTupleLetters = (First: "a", Second: "b");
            #endregion

            #region Access or deconstruct UnNamed Tuple
            //Access unnamed variables
            var unNamedCoordinates = GetCoordinates();
            var unX = unNamedCoordinates.Item1;
            var unY = unNamedCoordinates.Item2;
            #endregion


            #region Accessing  or deconstruct  Named tuples
            //Accessing Named Variables
            var namedCoordinates = GetNamedCoordinates();
            var namX = namedCoordinates.X;
            var namY = namedCoordinates.Y;
            #endregion

            #region Deconstructing and assigning

            (var firstItem, var SecondItem) = GetNamedCoordinates(); 
            #endregion
        }

        //Named variables
        private static (double X, double Y) GetNamedCoordinates()
        {
            //2 ways to returned named
            //return (X: 78.01, Y: 102.52);
            return (X: 78.01, Y: 102.52);
        }

        //unNamed
        private static (double, double) GetCoordinates()
        {
            return (78.01, 102.52);
        }
        #endregion

        #region Local function
        private static double SqRt(int x)
        {
            if (x < 0)
            {
                throw new ArgumentException("Less negativity please---", nameof(x));

            }
            //call local function
            return SquareRoot(x);
            

            double SquareRoot(int y)
            {
                return Math.Sqrt(y);
            }

        }
        #endregion


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
                throw new ArgumentException(
                    message: "shape is null",
                    paramName: nameof(shape));
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
