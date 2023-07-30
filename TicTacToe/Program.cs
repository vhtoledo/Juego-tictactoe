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
            bool terminado = false;

            // Dibujar el tablero inicial 
            DibujarTablero();
            Console.WriteLine("Jugador 1 = O\nJugador 2 = X");

            do /* Usamos un ciclo do-while porque desconocemos el numero de veces quye se tiene que llevar a cabo*/
            {
                // Turno Jugador 1
                PreguntarPosicion(1); //Envia el valor de  1 a la funcion preguntarposicion

                // Dibujar la casilla del jugador 1
                DibujarTablero();

                // Comprobar si ha ganado la partida el jugador 1
                terminado = ComprobarGanador();

                if(terminado == true)
                {
                    Console.WriteLine("¡El jugador 1 ha ganado!");
                }
                else // De lo contrario comprobamos si hubo un empate
                {
                    terminado = ComprobarEmpate();
                    if(terminado == true)
                    {
                        Console.WriteLine("¡Esto es un empate!");
                    }

                    // Si jugador 1 no gano, ni hubo empate, entonces es turno del jugador 2
                    else
                    {
                        // Turno del jugador 2
                        PreguntarPosicion(2);
                        // Dibujar la casilla del jugador 2
                        DibujarTablero();
                        // Comprobar si ha ganado la partida el jugador 2
                        terminado= ComprobarGanador();

                        if (terminado == true)
                        {
                            Console.WriteLine("¡El jugador 2 ha ganado!");
                        }
                    }
                }

              // Repetir hasta 3 en linea o empate (tablero lleno)
            } while (terminado == false);/*Mientras el juego no haya terminado, es decir, mientras la variable sea igual afalse, se seguira                                repitiendo el ciclo*/

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

        // Devuelve true si hay empate
        static bool ComprobarEmpate()
        {
            bool hayEspacio = false;
            int fila = 0;
            int columna = 0;

            for(fila = 0; fila <3; fila ++)
            {
                for(columna = 0; columna < 3; columna ++) 
                {
                    if (tablero[fila, columna] == 0)
                    {
                        if (tablero[fila,columna] == 0)/*Si encuentra una sola casilla vacia, quiere decir que se puede seguir jugando*/

                        {
                            hayEspacio = true;
                        }
                        
                    }
                }
            }

            return !hayEspacio; /*Si el ciclo anterior nos regresa un true, indicandonos que si hay espacios, entonces tiene que regresar una                     negacion de true para que la condicion de empate no se cumpla en la funcion de main()*/
        }
    }
}
