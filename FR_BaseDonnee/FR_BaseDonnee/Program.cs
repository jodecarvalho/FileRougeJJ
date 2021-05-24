using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FR_BaseDonnee
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new FR_JJ())
            {
                if (context.Database.Exists())
                {
                    context.Database.Delete();
                }
                context.Database.Create();
            }
        }
    }
}
