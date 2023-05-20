using SFML.System;
using SFML.Graphics;
using ExtensionMethods.FontExtentionMethods;
using ExtensionMethods.TextExtentionMethods;
using ExtensionMethods.GameObjectExtentionMethods;

namespace SFMLGame.Game
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

            player1 = new Player(Color.Yellow, true, scene);
            player2 = new Player(Color.Blue, false, scene);

            gate1 = new Gate(true, Color.Green, scene);
            gate2 = new Gate(false, Color.Green, scene);
        }
        public void Update(float time)
        {
            circle.Position += circle.Velocity * time;
            player1.Position += player1.Velocity * time;
            player2.Position += player2.Velocity * time;

            player1ScoreText.DisplayedString = "Player1: " + player1.Score;
            player2ScoreText.DisplayedString = "Player2: " + player2.Score;

            circle.Update();

            player1.Update();
            player2.Update();


            if (circle.CollidesWith(player1) && circle.Velocity.X < 0)
            {
                circle.BounceX();
            }
            else if (circle.CollidesWith(player2) && circle.Velocity.X > 0)
            {
                circle.BounceX();
            }

            if (circle.CollidesWith(gate1) && circle.Velocity.X < 0)
            {
                circle.BounceX();
                player2.Score++;
            }
            else if (circle.CollidesWith(gate2) && circle.Velocity.X > 0)
            {
                circle.BounceX();
                player1.Score++;
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
