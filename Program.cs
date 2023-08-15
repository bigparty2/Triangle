using System;
using Triangle.Triangle;

namespace Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var triangle = new TriangleType(5, 6, 7);

            var result = triangle.GetTriangleTypes();

            foreach( var t in result ) 
            {
                Console.WriteLine(t);
            }
            
            Console.Read();
        }
    }
}
