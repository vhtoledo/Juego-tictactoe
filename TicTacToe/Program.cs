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
            for (fila = 0; fila < 3; fila++)
            {
                Console.Write("|"); // Dibujar la segunda linea vertical
                for (columna = 0; columna < 3; columna++)
                {
                    // Asigna un: Espacio, 0, X, segun corresponda
                    Console.Write(" {0} |", simbolo[tablero[fila, columna]]);
                }
                Console.WriteLine();
                Console.WriteLine("-------------"); // Dibujar lineas horizontales
            }
        }

        // Pregunta donde escribir y lo dibuja en el tablero
        static void PreguntarPosicion(int jugador) //1= Jugador1; 2=Jugador2
        {
            int fila, columna;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Turno del jugador: {0}", jugador);
                //Pedimos el numero de fila
                do
                {
                    Console.WriteLine("Selecciona la fila (1 a 3): ");
                    fila = Convert.ToInt32(Console.ReadLine());

                } while ((fila < 1) || (fila > 3)); // Ejecutar mientras fila sea menor que 1 o mayor que 3

                // Pedimos le numero de columnas
                do
                {
                    Console.WriteLine("Selecciona la columna (1 a 3): ");
                    columna = Convert.ToInt32(Console.ReadLine());

                } while ((fila < 1) || (fila > 3));

                if (tablero[fila - 1, columna - 1] != 0)
                    Console.WriteLine("Casilla ocupada!");


            } while (tablero[fila - 1, columna - 1] != 0);

            // Si todo es correcto, se le asigna al jugador correspondiente
            tablero[fila - 1, columna - 1] = jugador;
        }

        // Devuelve un valor de true si hay tres en linea
        static bool ComprobarGanador()
        {
            int fila = 0;
            int columna = 0;
            bool ticTacToe = false;

            // Si en alguna fila todas las casillas son iguales y no estan vacias
            for (fila = 0; fila < 3; fila++)
            {
                if ((tablero[fila, 0] == tablero[fila, 1])
                    && (tablero[fila, 0] == tablero[fila, 2])
                    && (tablero[fila, 0] != 0))
                {
                    ticTacToe = true;
                }
            }

            // Si en alguna columna todas las casillas son iguales y no estan vacias 
            for (columna = 0; columna < 3; columna++)
            {
                if ((tablero[0, columna] == tablero[1, columna])
                    && (tablero[0, columna] == tablero[1, columna])
                    && (tablero[0, columna] != 0))
                {
                    ticTacToe = true;
                }
            }

            // Si en alguna diagonal todas las casillas son iguales y no estan vacias 
            if(    (tablero[0, 0] == tablero[1,1])
                && (tablero[0, 0] == tablero[2, 2])
                && (tablero[0, 0] != 0           ))
            {
                ticTacToe = true;
            }
            if (   (tablero[0, 2] == tablero[1, 1])
                && (tablero[0, 2] == tablero[2, 0])
                && (tablero[0, 2] != 0           ))
            {
                ticTacToe = true;
            }

            return ticTacToe;
        }
    }
}
