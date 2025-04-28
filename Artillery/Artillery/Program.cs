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

            Vector2 BulletPosition = Vector2.Zero;

            Vector2 BulletVelocity = Vector2.Zero;

            float BulletStrength = 0f;

            Rectangle player = new Rectangle(60, 400-pilars[1] -40,40,40);

            float cannon_rotation = -90;
            int width = 400;
            int height = 400;
            Vector2 A = new Vector2(width / 2, 0);
            Vector2 B = new Vector2(0, height / 2);
            Vector2 C = new Vector2(width, height * 3 / 4);
            Vector2 G = new Vector2(0, +50);

            Raylib.InitWindow(600, 400, "Raylib Testi");
            while (Raylib.WindowShouldClose() == false)
            {
                float delta = Raylib.GetFrameTime();
                if (Raylib.IsKeyDown(KeyboardKey.A)) { cannon_rotation -= 7 * delta; }
                if (Raylib.IsKeyDown(KeyboardKey.D)) { cannon_rotation += 7 * delta; }

                BulletVelocity += G * delta;
                BulletPosition += BulletVelocity * delta;
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);
                Raylib.DrawLineV(A, B, Color.Green);
                Raylib.DrawLineV(C, A, Color.Red);
                Raylib.DrawLineV(B, C, Color.Yellow);

                int x = 0;
                for (int i = 0; i < 10; i++)
                {
                 int y = 400 - pilars[i];
                    int w = 600 / pilars.Length;
                    int h = pilars[i];
                    Raylib.DrawRectangle(x, y, w, h, Color.Orange);
                    x += w;
                }
                Raylib.DrawRectangleRec(player, Color.Red);

                Matrix3x2 matrix = Matrix3x2.CreateRotation(cannon_rotation * Raylib.DEG2RAD);
                
                Vector2 direction = Vector2.Transform(Vector2.UnitX, matrix);

                Vector2 playercenter = new Vector2(player.X + player.Width /2, player.Y + player.Height /2);

                Vector2 cannonend = playercenter + direction * 40;

                Raylib.DrawLineV(playercenter, cannonend, Color.White);

                Raylib.DrawCircleV(BulletPosition, 3, Color.Green);

                Raylib.DrawText(BulletStrength.ToString(), 10, 10, 32, Color.Green);              
                Raylib.EndDrawing();
                if (Raylib.IsKeyDown(KeyboardKey.Space)) 
                {
                    BulletStrength += 3 * delta;
                }
                if (Raylib.IsKeyReleased(KeyboardKey.Space)) 
                { 
                    BulletPosition = cannonend;
                    BulletVelocity = direction * BulletStrength * 40;
                    BulletStrength = 0;
                }
            }
            Raylib.CloseWindow();
        }
    }
}
