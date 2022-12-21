using System;
using System.Linq;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Distances
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var matrizPath = Path.Combine(desktopPath, "matriz.txt");
            var caminhoPath = Path.Combine(desktopPath, "caminho.txt");

            using var readerMatriz = new StreamReader(matrizPath);
            using var csvMatriz = new CsvParser(readerMatriz, config);

            if (!csvMatriz.Read())
                return;

            var numColunas = csvMatriz.Record.Length;
            int[,] distancias = new int[numColunas, numColunas];

            for (int i = 0; i < numColunas; i++)
            {
                var linha = csvMatriz.Record;

                for (int j = 0; j < numColunas; j++)
                {
                    distancias[i, j] = int.Parse(linha[j]);
                }

                csvMatriz.Read();
            }

            using var readerCaminho = new StreamReader(caminhoPath);
            using var csvCaminho = new CsvParser(readerCaminho, config);
            if (!csvCaminho.Read())
                return;

            var vCaminho = csvCaminho.Record;
            int somaDist = 0;
            int[] arrCaminho = Array.ConvertAll(vCaminho, int.Parse);

            for (int i = 1; i < arrCaminho.Length; i++)
            {
                somaDist += distancias[arrCaminho[i - 1] - 1, arrCaminho[i] - 1];
            }

            Console.WriteLine($"Distância percorrida: {somaDist} km");
        }
    }
}