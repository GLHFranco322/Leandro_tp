using System;

class Program
{
    static string[,] matriz;
    static int playerRow = 0, playerCol = 0;
    static string player = "P";
    static string void_ = "V";
    static string door = "D";
    static int keys = 0;

    static void Main()
    {
        InicializarMatriz();
        Game();
    }

    static void InicializarMatriz()
    {
        string cheat = "C";
        string key = "K";
        string troll = "T";

        matriz = new string[6, 6];

        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                matriz[i, j] = void_;
            }
        }

        matriz[playerRow, playerCol] = player;
        matriz[2, 4] = key;
        matriz[5, 0] = troll;
        matriz[1, 4] = cheat;
        matriz[4, 2] = cheat;
        matriz[5, 5] = door;

        seeMatriz();
    }

    static void seeMatriz()
    {
        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                Console.Write(matriz[i, j] + "  ");
            }
            Console.WriteLine();
        }
    }

    static void Game()
    {
        int vida = 1;

        while (vida == 1)
        {
            Console.Clear();
            seeMatriz();
            
            Console.WriteLine("Mueve el jugador con WASD: ");
            string movimiento = Console.ReadLine().ToLower();

            matriz[playerRow, playerCol] = void_;

            if (movimiento == "w" && playerRow > 0) playerRow--;
            else if (movimiento == "s" && playerRow < matriz.GetLength(0) - 1) playerRow++;
            else if (movimiento == "a" && playerCol > 0) playerCol--;
            else if (movimiento == "d" && playerCol < matriz.GetLength(1) - 1) playerCol++;

            if (matriz[playerRow, playerCol] == "C" || matriz[playerRow, playerCol] == "T")
            {
                Console.Clear();
                matriz[playerRow, playerCol] = player;
                seeMatriz();
                Console.WriteLine("El jugador ha perdido.");
                vida = 0;
            }
            else if(matriz[playerRow,playerCol] == "K")
            {
                if(keys == 0){
                    keys++;
                }
            }
            else
            {
                matriz[playerRow, playerCol] = player;
            }
        }

        Console.WriteLine("Juego terminado. Gracias por jugar.");
    }
}
