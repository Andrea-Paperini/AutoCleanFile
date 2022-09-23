using System;
using System.IO;
using System.Reflection;

namespace AutoCleanFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto!");
            string percorsoExe = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            int numero = 0;
            if (!File.Exists(percorsoExe + @"\FileEliminati.txt"))
            {
                File.Create(percorsoExe + @"\FileEliminati.txt").Dispose();

            }
            string[] dischi = { @"y:\", @"z:\", @"u:\", @"v:\", @"w:\", @"x:\" };
            foreach (var discocorrente in dischi)
            {
            foreach (var CurrentFile in
            Directory.EnumerateFiles(discocorrente, "*", SearchOption.AllDirectories))
            {
                //your code
                // Get the information about a file
                const double BytesInGB = 1073741824;

                FileInfo fi = new FileInfo(CurrentFile);
                // Print the file size to console
                //Console.WriteLine($"File size: {fi.Length} bytes");
                double GigaByte = Math.Round(fi.Length / BytesInGB, 3);
                if (GigaByte < 0.01)
                {
                    Console.WriteLine("File corrente: "+CurrentFile+ " GigaByte: " + GigaByte);
                    File.Delete(CurrentFile);
                    File.AppendAllText(percorsoExe + @"\FileEliminati.txt", CurrentFile + Environment.NewLine);
                    numero++;

                }
            }
            Console.WriteLine("Disco corrente -> "+discocorrente+ " Ho eliminato "+numero+" File sotto i 10 MegaByte");
                numero = 0;
            }
            Console.ReadKey();

        }
    }
}
