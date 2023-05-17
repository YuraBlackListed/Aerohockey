using SFML.System;
using SFML.Graphics;
using System.IO;

namespace SFMLGame
{
    class Game
    {
        public Circle circle;

        private static string fontPath;

        private Font font;

        public Text text;

        public Player player1;
        public Player player2;

        private RenderWindow scene;

        public Game(RenderWindow window)
        {
            scene = window;

            circle = new Circle(50, scene.Size, scene);

            fontPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Fonts", "arial.ttf");

            font = new Font(fontPath);

            text = new Text("Hits: 0", font);
            text.CharacterSize = 24;
            text.FillColor = Color.White;
            text.Position = new Vector2f(100, 100);

            player1 = new Player(false, Color.White, scene.Size, false, scene);
            player2 = new Player(false, Color.Green, scene.Size, true, scene);
        }
        public void Update(float time)
        {
            circle.Position += circle.velocity * time;

            text.DisplayedString = "Hits: " + circle.score;

            circle.Update();

            player1.Update();
            player2.Update();
        }
        public void CheckInput()
        {
            player1.CheckInput();
            player2.CheckInput();
        }
    }
}
