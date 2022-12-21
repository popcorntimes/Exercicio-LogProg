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
            var distancias = new int[numColunas, numColunas];

            for (int i = 0; i < numColunas; i++)
            {
                var linha = csvMatriz.Record;

                for (int j = 0; j < numColunas; j++)
                {
                    distancias[i, j] = int.Parse(linha[j]);
                }

                csvMatriz.Read();
            }

            PrintMatriz(distancias);

            using var readerCaminho = new StreamReader(caminhoPath);
            using var csvCaminho = new CsvParser(readerCaminho, config);
            var vCaminho = csvCaminho.Record;
            
            for (int i = 0; i < csvCaminho.Record.Length; i++)
            {
                Console.WriteLine(vCaminho[i]);
            }


            /*
            string readMatriz = File.ReadAllText(matrizPath.ToString());
            string readCaminho = File.ReadAllText(caminhoPath.ToString());





            string[] getMatriz = readMatriz.Split("\n");
            string[] getCaminho = readCaminho.Split(",");

            if(getMatriz.Length < 2)
            {
                Console.WriteLine("Não é possível calcular distância");
                return;
            }

            string[,] newMatriz = new string[getMatriz.Length, getMatriz.Length];

            for (int i = 0; i < getMatriz.Length; i++)
            {
                
                string[] auxArray = getMatriz[i].Split(",");
                for (int j = 0; j < getMatriz.Length; j++)
                {
                    newMatriz[i, j] = auxArray[j];
                }
            }

            for (int i = 0; i < getMatriz.Length; i++)
            {
                for (int j = 0; j < getMatriz.Length; j++)
                {
                    Console.WriteLine($"Distância entre as cidades {i + 1} e {j + 1}: {newMatriz[i, j]}");
                }
            }

            int somaDist = 0;
            int[] arrPercurso = Array.ConvertAll(getCaminho, int.Parse);
            for (int i = 1; i < arrPercurso.Length; i++)
            {
                somaDist += newMatriz[arrPercurso[i - 1] - 1, arrPercurso[i] - 1].ToInt();
            }

            Console.WriteLine($"Distância percorrida: {somaDist} km"); */

        }
        private static void PrintMatriz(int[,] cities)
        {
            var strBuilder = new StringBuilder();

            for (int i = 0; i < cities.GetLength(0); i++)
            {
                for (int j = 0; j < cities.GetLength(0); j++)
                {
                    strBuilder.Append($"{cities[i, j]} ");
                }

                strBuilder.AppendLine();
            }

            Console.WriteLine(strBuilder.ToString());
        }

    }
}