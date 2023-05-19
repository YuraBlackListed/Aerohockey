using SFML.System;
using SFML.Graphics;
using MyExtensionMethods;
using TextExtentionMethods;

namespace SFMLGame
{
    class Game
    {
        private string fontName = "arial.ttf";
        private Font font;

        public Text player1ScoreText;
        public Text player2ScoreText;

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
        }

        public void Start()
        {
            circle = new Circle(50, scene.Size, scene);

            font = font.LoadFromFile(fontName);

            player1ScoreText = player1ScoreText.SetupText("Player 1: 0", font, Color.White, 24, new Vector2f(100, 100));
            player2ScoreText = player2ScoreText.SetupText("Player 2: 0", font, Color.White, 24, new Vector2f(scene.Size.X - 300, 100));

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
            circle.Position += circle.Velocity * time;
            player1.Position += player1.Velocity * time;
            player2.Position += player2.Velocity * time;

            player1ScoreText.DisplayedString = "Player1: " + player1.score;
            player2ScoreText.DisplayedString = "Player2: " + player2.score;

            circle.Update();

            player1.Update();
            player2.Update();


            if (circle.Mesh.GetGlobalBounds().Intersects(player1.Mesh.GetGlobalBounds()))
            {
                if(!counting)
                {
                    circle.BounceX();
                    circle.BounceY();
                    counting = true;
                }
            }
            else if (circle.Mesh.GetGlobalBounds().Intersects(player2.Mesh.GetGlobalBounds()))
            {
                if (!counting)
                {
                    circle.BounceX();
                    circle.BounceY();
                    counting = true;
                }
            }

            if (circle.Mesh.GetGlobalBounds().Intersects(gate1.Mesh.GetGlobalBounds()))
            {
                if (!counting)
                {
                    gate1.PlayerScored();
                    counting = true;
                }
            }
            else if (circle.Mesh.GetGlobalBounds().Intersects(gate2.Mesh.GetGlobalBounds()))
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
        public void Render()
        {
            circle.Draw();
            player1.Draw();
            player2.Draw();
            gate1.Draw();
            gate2.Draw();
        }

    }
}
