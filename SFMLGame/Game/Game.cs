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

        public Text Player1ScoreText;
        public Text Player2ScoreText;

        public Player Player1;
        public Player Player2;

        public Circle Pircle;

        public Gate Gate1;
        public Gate Gate2;

        private RenderWindow scene;

        public Game(RenderWindow window)
        {
            scene = window;
        }

        public void Start()
        {
            Pircle = new Circle(50, scene.Size, scene);

            font = font.LoadFromFile(fontName);

            Player1ScoreText = Player1ScoreText.SetupText("Player 1: 0", font, Color.White, 24, new Vector2f(100, 100));
            Player2ScoreText = Player2ScoreText.SetupText("Player 2: 0", font, Color.White, 24, new Vector2f(scene.Size.X - 300, 100));

            Player1 = new Player(Color.Yellow, true, scene);
            Player2 = new Player(Color.Blue, false, scene);

            Gate1 = new Gate(true, Color.Green, scene);
            Gate2 = new Gate(false, Color.Green, scene);
        }
        public void Update(float time)
        {
            Player1ScoreText.DisplayedString = "Player1: " + Player1.Score;
            Player2ScoreText.DisplayedString = "Player2: " + Player2.Score;

            Pircle.Update(time);

            Player1.Update(time);
            Player2.Update(time);


            if (Pircle.CollidesWith(Player1) && Pircle.Velocity.X < 0)
            {
                Pircle.BounceX();
            }
            else if (Pircle.CollidesWith(Player2) && Pircle.Velocity.X > 0)
            {
                Pircle.BounceX();
            }

            if (Pircle.CollidesWith(Gate1) && Pircle.Velocity.X < 0)
            {
                Pircle.BounceX();
                Player2.Score++;
            }
            else if (Pircle.CollidesWith(Gate2) && Pircle.Velocity.X > 0)
            {
                Pircle.BounceX();
                Player1.Score++;
            }
        }
        public void CheckInput()
        {
            Player1.CheckInput();
            Player2.CheckInput();
        }
        public void Render()
        {
            Pircle.Draw();
            Player1.Draw();
            Player2.Draw();
            Gate1.Draw();
            Gate2.Draw();
        }

    }
}
