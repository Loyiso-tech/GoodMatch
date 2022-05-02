using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Collections.Generic;
using LumenWorks.Framework.IO.Csv;
using CsvHelper;
using CsvHelper.Configuration;

public class StringRW
{
    StringBuilder sb = new StringBuilder();
    public StringRW()
    {
        //Call the Writer Method
        Writer();

        

    }

    public static void Main()
    {
        //creating a stringwriter object
        StringRW srw = new StringRW();

        //declaring a variable that will enable the Streamreader to access the .csv file
        using (var reader = new StreamReader(@"C:\Users\Loyis\Documents\test11.csv"))
        {
            //creating lists that will access the rows and columns of the csv file 
            List<string> listA = new List<string>();
            List<string> listB = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                listA.Add(values[0]);
                listB.Add(values[1]);
            }
        }


    }

    //Writer Method
    private void Writer()

    {

        //creating my stringwriter object
        StringWriter sw = new StringWriter(sb);
        
        //getting my user's input
        Console.WriteLine("Welcome to Good Match!");
        Console.Write("Enter player 1's name :");

        //storing the user's input
        string name1 = Console.ReadLine();
        while (String.IsNullOrEmpty(name1))
        {
            Console.WriteLine("Enter a valid name!");
            name1 = Console.ReadLine();
        }
        //Write to StringBuilder
        Console.WriteLine("Name :" + name1);
        Console.Write("Enter player 2's name :");
        string name2 = Console.ReadLine();

        //while loop that will throw in an error that doesnt accept blank values
        while (String.IsNullOrEmpty(name2))
        {
            Console.WriteLine("Enter a valid name!");
            name2 = Console.ReadLine();
        }
        Console.WriteLine($"{name1} matches {name2}");
       
        //Write to StringBuilder
        sw.WriteLine($"{name1} matches {name2}");
        String result = sw.ToString();
        
        result = result.Replace(" ", string.Empty);

        
        
        while (result.Length> 0)
        {
            Console.Write(result[0] + "= ");
            int count = 0;
            for (int j = 0; j < result.Length; j++)
            {
                if (result[0] == result[j])
                {
                     count++;
                }
            }
            Console.WriteLine(count);
            

            result = result.Replace(result[0].ToString(), string.Empty);


            //folder wherer .txt file is created
            string folder = @"C:\Users\Loyis\Documents\";

            //name of .txt file
            string fileName = "Results.txt";

           //variable that combines the file name and its folder
            string fullPath = folder + fileName;

            //this will create the file, write to it and close it.
            File.WriteAllText(fullPath, result);

            //reading the file
            string readText = File.ReadAllText(fullPath);
            Console.WriteLine(readText);








        }



        

             

            


        //Close the stream
        sw.Flush();
        sw.Close();
        Console.ReadLine();
    }

    
}