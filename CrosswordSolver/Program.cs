using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CrosswordSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            // The main method creates an instance of the PuzzleSolver Class, takes input from the user
            // and handles the result accordingly.
            PuzzleSolver puzzleOne = new PuzzleSolver();



            // Take user input, convert it to an array of strings and then use PuzzleSolver's "findWords" method to search the input
            // matrix for any occurences of the words in the given dictionary.
            string line;
            while (!String.IsNullOrWhiteSpace(line = Console.ReadLine()))
            {
                if (!(line == ""))
                {
                    PuzzleSolver.input.Add(line);
                }
            }
            string[] stringArray = PuzzleSolver.input.ToArray();
            string[] myArray = stringArray;
            // Put into 2D array.
            int height = myArray.Length;
            int width = myArray[0].Length;
            char[,] array = new char[height, width];
            for (int i = 0; i < width; i++)
            {
                for (int a = 0; a < height; a++)
                {
                    array[a, i] = myArray[a][i];
                }
            }
            PuzzleSolver.FindWords(array);

            // Count the number of individual T's in the input matrix.
            //string inputstring;
            //int count = 0;
            int total = 0;
            /*for (int i = 0; i < stringArray.Length; i++)
            { 
                    inputstring = stringArray[i].ToString();
                    count = count + inputstring.Split('T').Length - 1;
            }*/

            // check to see if each word was found. If it was found, print results and add up my running total of words
            /*if (PuzzleSolver._found.ContainsKey("OX"))
            {
                total = total + PuzzleSolver._found["OX"];
                Console.WriteLine("OX was found {0} times", PuzzleSolver._found["OX"]);
            }
            if (PuzzleSolver._found.ContainsKey("CAT"))
            { 
                total = total + PuzzleSolver._found["CAT"];
                Console.WriteLine("CAT was found {0} times", PuzzleSolver._found["CAT"]);
            }
            if (PuzzleSolver._found.ContainsKey("TOY"))
            {
                total = total + PuzzleSolver._found["TOY"];
                Console.WriteLine("TOY was found {0} times", PuzzleSolver._found["TOY"]);
            }
            if (PuzzleSolver._found.ContainsKey("AT"))
            {
                total = total + PuzzleSolver._found["AT"];
                Console.WriteLine("AT was found {0} times", PuzzleSolver._found["AT"]);
            }
            if (PuzzleSolver._found.ContainsKey("DOG"))
            {
                total = total + PuzzleSolver._found["DOG"];
                Console.WriteLine("DOG was found {0} times", PuzzleSolver._found["DOG"]);
            }
            if (PuzzleSolver._found.ContainsKey("CATAPULT"))
            {
                total = total + PuzzleSolver._found["CATAPULT"];
                Console.WriteLine("CATAPULT was found {0} times", PuzzleSolver._found["CATAPULT"]);
            }

            // Since T was a single character, it was simpler to find them and total them separately.
            // The multicharacter word search function returns duplicates with single character searches.
            

            // print the final total of all words found in the input matrix
            Console.WriteLine("A total of {0} words were found.", PuzzleSolver.FindWords(array));

            // easter egg, if the word trebuchet happens to be found in the input matrix,
            // "A superior seige weapon was found." will be printed to a new line in the console.
            // note: the word trebuchet will no contribute to the word total printed on the
            // previous line.*/
            if (PuzzleSolver._found.ContainsKey("TREBUCHET"))
            {
                Console.WriteLine("\nA superior seige weapon was found.");
            }
            Console.ReadKey();
        }
    }

}
