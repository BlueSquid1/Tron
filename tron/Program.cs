using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace tron
{
    public class Program
    {
        const int WIDTH = 640;
        const int HEIGHT = 480;
        const string TITLE = "Tron";
        static void Main(string[] args)
        {
            VideoMode mode = new VideoMode(WIDTH, HEIGHT);
            RenderWindow window = new RenderWindow(mode, TITLE);
            window.SetFramerateLimit(2);
            window.Closed += (sender, args) => window.Close();

            Background background = new Background(64, 48);
            Player player1 = new Player(32, 24, Player.Direction.UP);

            while (window.IsOpen)
            {
                window.DispatchEvents();
                player1.HandleUserInput();

                player1.Process();

                background.SetSquareToUsed(player1.curPosition);

                window.Clear(Color.White);
                background.Render(ref window);
                player1.Render(ref window);
                window.Display();
            }
        }
    }
}