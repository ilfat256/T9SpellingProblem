using MessageLibrary;
using System;
using System.Collections.Generic;
using T9Library;

namespace T9SpellingProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            var messageConverter = new MessageConverter(Dictionary);
            int casesCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < casesCount; i++)
            {
                var message = Console.ReadLine();
                Console.WriteLine($"Case #{i + 1}: {messageConverter.Translate(message)}");
            }

            Console.ReadKey();
        }

        private static T9Dictionary Dictionary = T9Dictionary.CreateFrom(new Dictionary<char, int[]>
        {
            { 'a', new int[] { 2 }},
            { 'b', new int[] { 2, 2 }},
            { 'c', new int[] { 2, 2, 2 }},
            { 'd', new int[] { 3 }},
            { 'e', new int[] { 3, 3 }},
            { 'f', new int[] { 3, 3, 3 }},
            { 'g', new int[] { 4 }},
            { 'h', new int[] { 4, 4 }},
            { 'i', new int[] { 4, 4, 4 }},
            { 'j', new int[] { 5 }},
            { 'k', new int[] { 5, 5 }},
            { 'l', new int[] { 5, 5, 5 }},
            { 'm', new int[] { 6 }},
            { 'n', new int[] { 6, 6 }},
            { 'o', new int[] { 6, 6, 6 }},
            { 'p', new int[] { 7 }},
            { 'q', new int[] { 7, 7 }},
            { 'r', new int[] { 7, 7, 7 }},
            { 's', new int[] { 7, 7, 7, 7 }},
            { 't', new int[] { 8 }},
            { 'u', new int[] { 8, 8 }},
            { 'v', new int[] { 8, 8, 8 }},
            { 'w', new int[] { 9 }},
            { 'x', new int[] { 9, 9 }},
            { 'y', new int[] { 9, 9, 9 }},
            { 'z', new int[] { 9, 9, 9, 9 }},
            { ' ', new int[] { 0 }},
        });
    }
}
