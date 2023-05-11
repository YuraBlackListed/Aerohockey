using System;
using System.Threading;
using SFML.System;
using SFML.Graphics;
using SFML.Window;
using System.IO;


namespace SFMLGame
{
    class GameLoop
    {
        private bool running = false;

        private const int windiwWidth = 1200;
        private const int windowHeight = 600;

        private RenderWindow window;

        private Circle circle;

        private Clock clock = new Clock();

        static string fontPath;

        private Font font;

        private Text text;

        private Player player1;
        private Player player2;

        public void Run()
        {
            Start();
            while (running)
            {
                Render();
                CheckInput();
                Update();
            }
        }
        private void Start()
        {
            running = true;

            window = new RenderWindow(new VideoMode(windiwWidth, windowHeight), "Game window");
            window.DispatchEvents();

            circle = new Circle(50, window.Size);

            fontPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Fonts", "arial.ttf");

            font = new Font(fontPath);

            text = new Text("Hits: 0", font);
            text.CharacterSize = 24;
            text.FillColor = Color.White;
            text.Position = new Vector2f(100, 100);

            player1 = new Player(false, Color.White, window.Size, false);
            player2 = new Player(false, Color.Green, window.Size, true);
        }

        private void Update()
        {
            Time deltaTime = clock.Restart();
            float seconds = deltaTime.AsSeconds();

            circle.Position += circle.velocity * seconds;

            text.DisplayedString = "Hits: " + circle.score;

            circle.Update();

            player1.Update();
            player2.Update();
        }
        private void Render()
        {
            window.Clear(Color.Black);
            window.Draw(text);
            window.Draw(circle.Shape);
            window.Draw(player1.Shape);
            window.Draw(player2.Shape);
            window.Display();
        }
        private void CheckInput()
        {
            player1.CheckInput();
            player2.CheckInput();
        }
    }
}
