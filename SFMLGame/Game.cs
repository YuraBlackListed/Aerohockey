using SFML.System;
using SFML.Graphics;
using System.IO;
using System;

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

        private float bounceTimer;
        private bool counting;

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

            player1 = new Player(Color.Yellow, scene.Size, false, scene);
            player2 = new Player(Color.Blue, scene.Size, true, scene);

            bounceTimer = 0;
        }
        public void Update(float time)
        {
            if(counting)
            {
                bounceTimer += time;
                if (bounceTimer >= 1)
                {
                    bounceTimer = 0;
                    counting = false;
                }
            }
            circle.Position += circle.velocity * time;
            player1.Position += player1.velocity * time;
            player2.Position += player2.velocity * time;

            text.DisplayedString = "Hits: " + circle.score;

            circle.Update();

            player1.Update();
            player2.Update();


            if (circle.mesh.GetGlobalBounds().Intersects(player1.mesh.GetGlobalBounds()))
            {
                if(!counting)
                {
                    circle.BounceX();
                    circle.BounceY();
                    counting = true;
                }
            }
            else if (circle.mesh.GetGlobalBounds().Intersects(player2.mesh.GetGlobalBounds()))
            {
                if (!counting)
                {
                    circle.BounceX();
                    circle.BounceY();
                    counting = true;
                }
            }
        }
        public void CheckInput()
        {
            player1.CheckInput();
            player2.CheckInput();
        }
    }
}
