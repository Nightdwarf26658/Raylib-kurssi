using System.Numerics;
using Raylib_cs;

namespace Raylib_test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = 600;
            int height = 400;
            Vector2 A = new Vector2(width / 2,0);
            Vector2 B = new Vector2(0, height / 2);
            Vector2 C = new Vector2(width, height * 3 / 4);

            List<Vector2> Dots = new List<Vector2>() { A, B, C,};

            Vector2 Asuunta = new Vector2(1, 1);
            Vector2 Bsuunta = new Vector2(1, 1);
            Vector2 Csuunta = new Vector2(1, 1);

            List<Vector2> Directions = new List<Vector2>() { Asuunta, Bsuunta, Csuunta,};

            Raylib.InitWindow(width, height, "Raylib Testi");
            while(Raylib.WindowShouldClose() == false)
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);
                Raylib.DrawLineV(C, A, Color.Red);
                Raylib.DrawLineV(B, C, Color.Yellow);

                for (int i = 0; i < 3; i++)
                {
                    Raylib.DrawLineV(Dots[i], Dots[(i+1)%3], Color.Green);
                    Dots[i] = Dots[i] + Directions[i] * 20 * Raylib.GetFrameTime();

                    if (Dots[i].X > width || Dots[i].X < 0) { Directions[i] = new Vector2 (Directions[i].X * -1, Directions[i].Y); }

                    if (Dots[i].Y > height || Dots[i].Y < 0) { Directions[i] = new Vector2(Directions[i].X,Directions[i].Y * -1); }
                }
                

                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }
    }
}
