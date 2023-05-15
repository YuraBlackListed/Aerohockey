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

        private RenderWindow scene;

        private Circle circle;

        private Clock clock = new Clock();

        private static string fontPath;

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

            scene = new RenderWindow(new VideoMode(windiwWidth, windowHeight), "Game window");
            scene.DispatchEvents();

            circle = new Circle(50, scene.Size, scene);

            fontPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Fonts", "arial.ttf");

            font = new Font(fontPath);

            text = new Text("Hits: 0", font);
            text.CharacterSize = 24;
            text.FillColor = Color.White;
            text.Position = new Vector2f(100, 100);

            player1 = new Player(false, Color.White, scene.Size, false);
            player2 = new Player(false, Color.Green, scene.Size, true);
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
            scene.Clear(Color.Black);
            scene.Draw(text);
            scene.Draw(circle.mesh);
            scene.Draw(player1.Shape);
            scene.Draw(player2.Shape);

            circle.Draw();

            scene.Display();
        }
        private void CheckInput()
        {
            player1.CheckInput();
            player2.CheckInput();
        }
    }
}
