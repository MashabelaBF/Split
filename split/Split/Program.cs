using System;
using System.IO;

namespace Split
{
    class Program
    {
        static void Main(string[] args)
        {
            String line;
            int size = 0;
            int maxSize=0;
            //= 541618632;
            int count = 1;
            string path="";
            

            
            try
            {
                path=CheckPath();
                maxSize = CheckMaxSize();
                
                //D:/Users/Bran.mashabela/Desktop/projects/dsp/#121.DSP

                //Pass the file path and file name to the StreamReader constructor
                StreamReader file = new StreamReader(path);

                //Read the first line of text
                line = file.ReadLine();

                //using (StreamWriter f = File.AppendText(@"d:/users/bran.mashabela/desktop/csharp/testfile" + count + ".dsp"))
                StreamWriter OurStream = File.CreateText("d:/desktop/split/testfile" + count + ".dsp");

                Console.WriteLine("Spliting Files...");
                //Continue to read until you reach end of file
                while (line != null)
                {

                    //write line to a file
                    OurStream.WriteLine(line);

                    //get the size of the file
                    size += line.Length;

                    //create a new file when it hits the file size and its end of file
                    if (size >= maxSize && line.Contains("MOVED TO PURGE LIST"))
                    {
                        OurStream.Close();
                        Console.WriteLine("File " + count.ToString()+" Created succesfuly");
                       
                        size = 0;
                        count += 1;
                        OurStream = File.CreateText("d:/desktop/split/testfile" + count + ".dsp");
                    }
                    //Read the next line
                    try
                    {
                        line = file.ReadLine();
                    }
                    catch(Exception)
                    {
                        Console.WriteLine("file finished");
                    }
                     
                }

                OurStream.Close();
                Console.WriteLine("Spliting files Complete");
                
                //close the file
                file.Close();
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
               
            }
            finally
            {
                Console.WriteLine("Executing finally block.");

            }
            //keep the console running
            Console.ReadLine();

        }
        public static int CheckMaxSize()
        {
            int maxSize = 0;


            try
            {
                Console.Write("Please enter the size of each split file: ");
                maxSize = Convert.ToInt32(Console.ReadLine());

                //Console.WriteLine(maxSize.GetType() != typeof(int));
                //Console.WriteLine(maxSize);


                if (maxSize <= 0)
                {
                    Console.WriteLine("Value cannot be less than zero");
                    //Console.WriteLine(maxSize);
                    CheckMaxSize();
                }
                else
                {
                    //CheckMaxSize();
                    Console.WriteLine("else");
                    //Console.WriteLine(maxSize);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                CheckMaxSize();
            }
            return maxSize;
        }


        public static string CheckPath()
        {
            string path;

            Console.Write("Please enter the file path: ");
            path = Console.ReadLine();
            

            if (!File.Exists(path) == true )
                {
                    // Try to create the directory.
                    Console.WriteLine("Path does not exist");
                    CheckPath();
                }
                else
                {
                Console.WriteLine("File Found ");
                   
                }
           
            
            return path;
        }
    }
}
