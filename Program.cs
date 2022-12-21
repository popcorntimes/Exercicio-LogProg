using System;
using System.Linq;

namespace Distances
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Quantidade de cidades: ");
            int rDist;
            int somaDist = 0;
            var qteCidades = Console.ReadLine().ToInt();
            int[,] distancias = new int[qteCidades, qteCidades];

            if(qteCidades < 2)
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

            Console.WriteLine($"Distância percorrida: {somaDist} km");


        }
    }
}