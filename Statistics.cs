using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Statistics
{
    public static class Statistics
    {
        
        public static int[] source = JsonConvert.DeserializeObject<int[]>(File.ReadAllText("data.json"));

        
        public static dynamic DescriptiveStatistics()
        {
            
            Dictionary<string, dynamic> StatisticsList = new Dictionary<string, dynamic>()
            {
                { "Maximum", Maximum() },
                { "Minimum", Minimum() },
                { "Medelvärde", Mean() },
                { "Median", Median() },
                { "Typvärde", String.Join(", ", Mode()) },
                { "Variationsbredd", Range() },
                { "Standardavvikelse", StandardDeviation() }
            };

            
            string output =
                $"Maximum: {StatisticsList["Maximum"]}\n" +
                $"Minimum: {StatisticsList["Minimum"]}\n" +
                $"Medelvärde: {StatisticsList["Medelvärde"]}\n" +
                $"Median: {StatisticsList["Median"]}\n" +
                $"Typvärde: {StatisticsList["Typvärde"]}\n" +
                $"Variationsbredd: {StatisticsList["Variationsbredd"]}\n" +
                $"Standardavvikelse: {StatisticsList["Standardavvikelse"]}";

            return output;
        }

        
        public static int Maximum()
        {
            Array.Sort(source);
            Array.Reverse(source);
            int result = source[0];
            return result;
        }

        
        public static int Minimum()
        {
            Array.Sort(source);
            int result = source[0];
            return result;
        }

       
        public static double Mean()
        {
            double total = 0;

            for (int i = 0; i < source.Length; i++)
            {
                total += source[i];
            }
            return total / source.Length;
        }

       
        public static double Median()
        {
            Array.Sort(source);
            int size = source.Length;
            int mid = size / 2;

            if (size % 2 != 0)
            {
                return source[mid];
            }
            else
            {
                return (source[mid - 1] + source[mid]) / 2.0;
            }
        }

        // Beräknar typvärdet (moden) av datan
        public static int[] Mode()
        {
            // Skapar en dictionary för att lagra frekvensen av varje unikt värde i datan
            Dictionary<int, int> frequency = new Dictionary<int, int>();

            // Beräknar frekvensen av varje värde i datan
            foreach (int num in source)
            {
                if (!frequency.ContainsKey(num))
                {
                    frequency[num] = 0;
                }
                frequency[num]++;
            }

            // Hittar den högsta frekvensen bland alla värden
            int maxFrequency = frequency.Values.Max();

            // Skapar en lista för att lagra värdena i datan
            List<int> modes = new List<int>();

            // Lägger till värden med högsta frekvens till listan med värdena
            foreach (var pair in frequency)
            {
                if (pair.Value == maxFrequency)
                {
                    modes.Add(pair.Key);
                }
            }

            // Returnerar en array med värdena
            return modes.ToArray();
        }

        
        public static int Range()
        {
            Array.Sort(source);
            int min = source[0];
            int max = source[source.Length - 1];
            return max - min;
        }

        
        public static double StandardDeviation()
        {
            double average = Mean();
            double sumOfSquaresOfDifferences = source.Select(val => Math.Pow(val - average, 2)).Sum();
            double sd = Math.Sqrt(sumOfSquaresOfDifferences / source.Length);

            return Math.Round(sd, 1);
        }
    }
}


// 4. Vilka förkodade lösningar i ramverk och klassbibliotek används i uppgiften, vilka skulle du använda? Ge exempel.

// De förkodade lösningar i ramverk och klassbibliotek som används i uppgiften är Newtonsoft.Json som är till för att hantera JSON-data samt att den kan läsa ifrån en JSON-fil.
// De används System.IO och det är för att man kan komma åt filer samt att man kan läsa utifrån en fil. Som File.ReadAllText("data.json") som gör att den läser allt ifrån filen
// och sedan stänger den.
// De används System.Collections.Generic som gör att man kan komma åt interfaces och klasser så att man kan skapa samlingar för bättre säkerhet och prestanda. Generiska samlingar.
// Om jag hade fått ändra på något hade jag lagt till System.Collections.Immutable så att man kan skapa ImmutableDictionary för att förhindra ändringar inne i den.