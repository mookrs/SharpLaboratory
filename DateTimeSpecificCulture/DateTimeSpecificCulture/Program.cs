using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeSpecificCulture
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date = DateTime.Now;
            // See: https://msdn.microsoft.com/en-us/library/8kb3ddd4 
            Console.WriteLine(date.ToString("yyyy-mm-dd tt hh:mm:ss", CultureInfo.CreateSpecificCulture("zh-CN")));
            Console.ReadKey();
        }
    }
}
