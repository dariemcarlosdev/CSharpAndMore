using System;
using System.IO;

namespace ErrorHandlingExceptions
{
    public class Calculator
    {
        public int Devide(int numerator, int denominator)
        {
            return numerator / denominator;
        }
    }

    

    internal class Program
    {
        private static void Main(string[] args)
        {
            // StreamReader streamReader = null;

            try
            {
                //Example how to use Finally block and Disposal() method.
                //streamReader = new StreamReader(@"c:\log.rar");

                using (StreamReader streamReader = new StreamReader(@"c:\log.rar"))
                {
                    var content = streamReader.ReadToEnd(); //if anything was wrong reading the file, you wanna make sure that the stream get closed.
                }

                Calculator calculator = new Calculator();
                var result = calculator.Devide(5, 0);
                throw new Exception("Opps!!");
            }

            //With handling exceptions you can have multiples Catch blocks, and they have to be from most specific to most generic one.

            //catch (Exception ex) ---> This theow an error due the hierarchy violiation between clasess.

            //{
            //    Console.WriteLine("There was an error (Generic Exception) {0}", ex.Message);
            //}
            catch (DivideByZeroException ex) //more especific exception
            {
                Console.WriteLine("You can not devide by 0 {0}\n", ex.Message);
            }
            catch (ArithmeticException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //here in the catch block we just have a type, and Exception is the parent of all exception in .NET.
            //Is good to have an argument here, so we can access the actual axception.
            catch (Exception ex)

            {
                Console.WriteLine(ex.Message);
            }

            //finally
            //{
            //    //more reliable code is to say:
            //    if (streamReader!=null)
            //    {
            //        //make sure when your handler unmanaged resources dispose them here, in this Finally Block.
            //        streamReader.Dispose();
            //    }
            //}
        }
    }
}