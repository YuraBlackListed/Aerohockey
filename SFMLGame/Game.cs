using SFML.System;
using SFML.Graphics;
using System.IO;

namespace SFMLGame
{
    class Game
    {
        private static string fontPath;

        private Font font;

        public Text player1Score;
        public Text player2Score;

        public Player player1;
        public Player player2;

        public Circle circle;

        public Gate gate1;
        public Gate gate2;

        private RenderWindow scene;

        private float bounceTimer;
        private bool counting;

        public Game(RenderWindow window)
        {
            scene = window;

            circle = new Circle(50, scene.Size, scene);

            fontPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Fonts", "arial.ttf");

            font = new Font(fontPath);

            player1Score = new Text("Player 1: 0", font);
            player1Score.CharacterSize = 24;
            player1Score.FillColor = Color.White;
            player1Score.Position = new Vector2f(100, 100);
            
            player2Score = new Text("Player 1: 0", font);
            player2Score.CharacterSize = 24;
            player2Score.FillColor = Color.White;
            player2Score.Position = new Vector2f(window.Size.X - 300, 100);

            player1 = new Player(Color.Yellow, false, scene);
            player2 = new Player(Color.Blue, true, scene);

            gate1 = new Gate(player2, true, Color.Green, scene);
            gate2 = new Gate(player1, false, Color.Green, scene);

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

            player1Score.DisplayedString = "Player1: " + player1.score;
            player2Score.DisplayedString = "Player2: " + player2.score;

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

            if (circle.mesh.GetGlobalBounds().Intersects(gate1.mesh.GetGlobalBounds()))
            {
                if (!counting)
                {
                    gate1.PlayerScored();
                    counting = true;
                }
            }
            else if (circle.mesh.GetGlobalBounds().Intersects(gate2.mesh.GetGlobalBounds()))
            {
                if (!counting)
                {
                    gate2.PlayerScored();
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
