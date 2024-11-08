using System;

class Program
{
    static string[,] matriz = new string[6, 6]; // Inicializar la matriz aquí
    static int playerRow = 0, playerCol = 0;
    static int trollRow = 5, trollCol = 0;
    static string player = "P";
    static string void_ = "V";
    static string door = "D";
    static string troll = "T"; // Definir troll en el ámbito correcto
    static int keys = 0;
    static string trollDirection = "right";

    static void Main()
    {
        InicializarMatriz();
        Game();
    }

    static void InicializarMatriz()
    {
        string cheat = "C";
        string key = "K";

        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                matriz[i, j] = void_;
            }
        }

        matriz[playerRow, playerCol] = player;
        matriz[2, 4] = key;
        matriz[trollRow, trollCol] = troll;
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
        Console.WriteLine($"Llaves: {keys}");
    }

    static void MoveTroll()
    {
        matriz[trollRow, trollCol] = void_;

        if (trollDirection == "right")
        {
            if (trollCol < matriz.GetLength(1) - 1) trollCol++;
            else trollDirection = "up";
        }
        else if (trollDirection == "up")
        {
            if (trollRow > 0) trollRow--;
            else trollDirection = "left";
        }
        else if (trollDirection == "left")
        {
            if (trollCol > 0) trollCol--;
            else trollDirection = "down";
        }
        else if (trollDirection == "down")
        {
            if (trollRow < matriz.GetLength(0) - 1) trollRow++;
            else trollDirection = "right";
        }

        matriz[trollRow, trollCol] = troll;
    }

    static void Game()
    {
        int vida = 1;
        int doorRow = 5, doorCol = 5;

        while (vida == 1)
        {
            Console.Clear();
            seeMatriz();

            Console.WriteLine("Mueve el jugador con WASD: ");
            string movimiento = Console.ReadLine().ToLower();

            if (playerRow == doorRow && playerCol == doorCol)
            {
                matriz[playerRow, playerCol] = door;
            }
            else
            {
                matriz[playerRow, playerCol] = void_;
            }

            if (movimiento == "w" && playerRow > 0) playerRow--;
            else if (movimiento == "s" && playerRow < matriz.GetLength(0) - 1) playerRow++;
            else if (movimiento == "a" && playerCol > 0) playerCol--;
            else if (movimiento == "d" && playerCol < matriz.GetLength(1) - 1) playerCol++;

            if (matriz[playerRow, playerCol] == "C" || matriz[playerRow, playerCol] == "T")
            {
                Console.Clear();
                seeMatriz();
                Console.WriteLine("El jugador ha perdido.");
                vida = 0;
            }
            else if (matriz[playerRow, playerCol] == "K")
            {
                keys++;
                matriz[playerRow, playerCol] = void_; 
            }
            else if (playerRow == doorRow && playerCol == doorCol)
            {
                if (keys > 0)
                {
                    Console.Clear();
                    seeMatriz();
                    Console.WriteLine("¡Has encontrado la puerta y tienes la llave! Has ganado.");
                    vida = 0;
                }
                else
                {
                    Console.WriteLine("Necesitas una llave para pasar por la puerta.");
                    playerRow = 0;
                    playerCol = 0;
                }
            }

            matriz[playerRow, playerCol] = player;
            MoveTroll();
        }

        Console.WriteLine("Juego terminado. Gracias por jugar.");
    }
}
