using System;
using System.IO;

namespace ExceptionHandeling
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader aStreamReader = null;
            try
            {
                try
                {
                    aStreamReader = new StreamReader(@"C:\Users\md-sh\OneDrive\Desktop\RiseUp\Day-8\ReadMe.txt");
                    Console.WriteLine(aStreamReader.ReadToEnd());
                }
                catch (FileNotFoundException e)
                {
                    string writePath = @"C:\Users\md-sh\OneDrive\Desktop\RiseUp\Day-8\log2.txt";
                    if (File.Exists(writePath))
                    {
                        StreamWriter aStreamWriter = new StreamWriter(writePath);
                        aStreamWriter.Write(e.GetType().FullName);
                        aStreamWriter.WriteLine();
                        aStreamWriter.Write(e.Message);
                        aStreamWriter.Close();
                    }
                    else
                    {
                        throw new FileNotFoundException(writePath + " is not present");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    if (aStreamReader != null)
                    {
                        aStreamReader.Close();
                    }
                    Console.WriteLine("Finally Block");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Current Exception-{0}", e.GetType().FullName);
                Console.WriteLine("Current Exception Message-{0}", e.Message);

                if (e.InnerException != null)
                {
                    Console.WriteLine("Inner Exception-{0}", e.InnerException.GetType().Name);
                    Console.WriteLine("Inner Exception Message-{0}", e.InnerException.Message);
                }
            }

            Console.ReadLine();
        }
    }
}