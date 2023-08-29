// See https://aka.ms/new-console-template for more information
using System.Numerics;

var myarr = new Complex[] { new Complex(3, 4) };
var result = FFTModule.FFTClass.ReverseBit(myarr);

Console.WriteLine(result[0].Real);
Console.WriteLine(result[0].Imaginary);

var rev = FFTModule.FFTClass.ReverseBit(result);

Console.WriteLine(rev[0].Real);
Console.WriteLine(rev[0].Imaginary);
Console.WriteLine(rev[0].Imaginary);