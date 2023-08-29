using System.Numerics;

namespace FFTModule
{
  public class FFTClass
  {
    public static double[] CalculateFFT(double[] samples)
    {



      return new double[] { samples[0] };
    }

    public static Complex[] ReverseBit(Complex[] samples)
    {
      List<Complex> result = new List<Complex>();

      foreach (Complex value in samples)
      {
        var revReal = BitConverter.GetBytes(value.Real).Reverse().ToArray();
        var output = BitConverter.ToDouble(revReal);

        var revImaginary = BitConverter.GetBytes(value.Imaginary).Reverse().ToArray();
        var output2 = BitConverter.ToDouble(revImaginary);

        result.Add(new Complex(output, output2));
      }

      return result.ToArray();
    }
  }
}