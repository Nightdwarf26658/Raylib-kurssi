using Raylib_cs;
using System.Numerics;

namespace Artillery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] pilars = new int[10];

            Random rnd = new Random();

            for (int i = 0; i < 10; i++) 
            {
                pilars[i] = rnd.Next(150);
            }


            int width = 400;
            int height = 400;
            Vector2 A = new Vector2(width / 2, 0);
            Vector2 B = new Vector2(0, height / 2);
            Vector2 C = new Vector2(width, height * 3 / 4);

            Raylib.InitWindow(600, 400, "Raylib Testi");
            while (Raylib.WindowShouldClose() == false)
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);
                Raylib.DrawLineV(A, B, Color.Green);
                Raylib.DrawLineV(C, A, Color.Red);
                Raylib.DrawLineV(B, C, Color.Yellow);

                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }
    }
}
