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
            Console.WriteLine(getMatriz.Length);

            if(getMatriz.Length < 2)
            {
                Console.WriteLine("Não é possível calcular distância");
                return;
            }

            int[,] newMatriz = new int[getMatriz.Length, getMatriz.Length];

            for (int i = 0; i < getMatriz.Length; i++)
            {
                int[] auxArray = getMatriz[i].Split(",").ToInt();
                for (int j = 0; j < getMatriz.Length; j++)
                {
                    newMatriz[i, j] = auxArray[j];
                }
            }

            /*if(qteCidades < 2)
            {
                Console.WriteLine("Não é possível calcular distância");
                return;
            }

            for (int i = 0; i < qteCidades; i++)
            {
                for (int j = i+1; j < qteCidades; j++)
                {
                    Console.WriteLine($"Distância entre as cidades {i+1} e {j+1}: ");
                    rDist = Console.ReadLine().ToInt();
                    distancias[i, j] = rDist;
                    distancias[j, i] = rDist;  
                }
            }

            Console.WriteLine("Entre com um percurso (separado por vírgulas)");
            string[] strPercurso = Console.ReadLine().Split(",");
            int[] arrPercurso = Array.ConvertAll(strPercurso, int.Parse);
            
            

            for(int i = 1; i < arrPercurso.Length; i++)
            {
                somaDist += distancias[arrPercurso[i-1]-1, arrPercurso[i]-1]; 
            }

            Console.WriteLine($"Distância percorrida: {somaDist} km");*/


        }
    }
}