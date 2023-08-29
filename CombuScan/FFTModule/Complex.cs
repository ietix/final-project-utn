using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFTModules
{
  internal class Complex
  {
    public Complex(float real, float imaginary)
    {
      Real = real;
      Imaginary = imaginary;
    }

    public double Real { get; set; }
    public double Imaginary { get; set; }

    public double Module 
    {
      get { return Math.Sqrt(Math.Pow(Real,2) + Math.Pow(Imaginary,2)); }
    }

    public double Phase
    {
      get { return Math.Atan(Imaginary / Real); }
    }
  }
}
