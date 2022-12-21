using System;
using System.Linq;
using System.IO;

namespace Distances
{
    class Program
    {
        static void Main(string[] args)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var matrizPath = new FileInfo(Path.Combine(desktopPath, "matriz.txt"));
            var caminhoPath = new FileInfo(Path.Combine(desktopPath, "caminho.txt"));
            if (!matrizPath.Exists || !caminhoPath.Exists) {
                return;
            }
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

            /*for (int i = 0; i < getMatriz.Length; i++)
            {
                for (int j = 0; j < getMatriz.Length; j++)
                {
                    Console.WriteLine($"Distância entre as cidades {i + 1} e {j + 1}: {newMatriz[i, j]}");
                }
            }*/

            int somaDist = 0;
            int[] arrPercurso = Array.ConvertAll(getCaminho, int.Parse);
            for (int i = 1; i < arrPercurso.Length; i++)
            {
                somaDist += newMatriz[arrPercurso[i - 1] - 1, arrPercurso[i] - 1].ToInt();
            }

            Console.WriteLine($"Distância percorrida: {somaDist} km");

        }
    }
}