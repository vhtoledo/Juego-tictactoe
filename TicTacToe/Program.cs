using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Program
    {
        // Creamos un arreglo bidimensional para el tablero del juego 
        static int[,] tablero = new int[3, 3]; // 3 Filas y 3 Columnas
        // Creamos un arreglo para los cimbolos detl tablero: Espacio en blanco, jug.1, jug.2
        static char[] simbolo = { ' ', 'O', 'X' };
        static void Main(string[] args)
        {

            // Dibujar el tablero inicial 
            DibujarTablero();
            Console.WriteLine("Jugador 1 = O\nJugador 2 = X");

        }//Cierre de Main

        static void DibujarTablero()
        {
            //Variables de conteo del ciclo
            int fila = 0;
            int columna = 0;

            Console.WriteLine(); // Espacio antes de dibujar el tablero
            Console.WriteLine("-------------"); // Dibujar la primera linea horinzontal
            for(fila = 0; fila < 3; fila ++) 
            {
                Console.Write("|"); // Dibujar la segunda linea vertical
                for(columna = 0; columna < 3; columna ++)
                {
                    // Asigna un: Espacio, 0, X, segun corresponda
                    Console.Write(" {0} |", simbolo[tablero[fila, columna]]);
                }
                Console.WriteLine();
                Console.WriteLine("-------------"); // Dibujar lineas horizontales
            }
        }
    }
}
