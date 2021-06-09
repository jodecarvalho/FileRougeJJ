using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace FR_TeamJJ_VersionACDC
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new FilRougeJJ())
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
