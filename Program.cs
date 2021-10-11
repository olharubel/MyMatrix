using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix m = new Matrix(4, 3);
            m.InitArray();
           Console.WriteLine(m.ToString());

            foreach (int elem in m)
            {        
                Console.Write(elem + " ");
            }
            Console.ReadLine();
        }
    }
}
