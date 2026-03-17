using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace lab3_mvvm
 {
     public class Line 
     {
         private double a { get; set; }
         private double b { get; set; }

         public Line(double a, double b)
         {
             this.a = a;
             this.b = b;
         }

         public string PrintForm() => $"y = {a}x + {b}";

         public double? GetX() => a == 0 ? null : -b / a;

         public double GetY() => b;

         public bool IsPerpendicular(Line other)
         {
             if (other == null) throw new ArgumentNullException(nameof(other));
             return Math.Abs(a * other.a + 1) < 1e-9;
         }

         public double GetAngleBetween(Line other)
         {
             if (other == null) throw new ArgumentNullException(nameof(other));

             double chisl = Math.Abs(other.a - a);
             double znam = 1 + a * other.a;

             if (Math.Abs(znam) < 1e-9)
                 return 90.0; 

             double tan = chisl / znam;
             return Math.Atan(tan) * (180 / Math.PI);
         }
     }
 }

