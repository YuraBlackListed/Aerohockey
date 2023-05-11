using System;
using SFML.System;
using SFML.Graphics;
using SFML.Window;


namespace SFMLGame
{
    class Player
    {
        public int score { get; private set; } = 0;
        public int roundWins { get; private set; } = 0;
        public bool IsAI { get; private set; } = false;

        private Keyboard.Key up;
        private Keyboard.Key down;

        private RectangleShape shape;
        public RectangleShape Shape
        {
            get { return shape; }
            set { shape = value; }
        }

        private Vector2f position = new Vector2f(400, 300);
        public Vector2f Position
        {
            get { return position; }
            set { position = value; shape.Position = position; }
        }

        public Vector2f velocity = new Vector2f(0, 0);

        private Vector2u windowSize;

        public Player(bool isAi, Color color, Vector2u _windowSize, bool left)
        {
            shape = new RectangleShape(new Vector2f(30f, 100f));
            if (left)
            {
                position = new Vector2f(50f, 300);
                up = Keyboard.Key.W;
                down = Keyboard.Key.S;
            }
            else
            {
                position = new Vector2f(_windowSize.X - 50f, 300);
                up = Keyboard.Key.Up;
                down = Keyboard.Key.Down;
            }
            shape.Origin = new Vector2f(shape.Size.X / 2f, shape.Size.Y / 2f);
            IsAI = isAi;

            shape.FillColor = color;

            windowSize = _windowSize;
        }

        public void Update()
        {
            Position += velocity;
            velocity.Y = 0;

            if(position.Y < 90f)
            {
                position.Y = 90f;
            }
            else if(position.Y > windowSize.Y - 90f)
            {
                position.Y = windowSize.Y - 90f;
            }
        }
        public void CheckInput()
        {
            if (Keyboard.IsKeyPressed(up))
            {
                velocity.Y -= 0.2f;
            }
            else if (Keyboard.IsKeyPressed(down))
            {
                position.Y += 0.2f;
            }
        }
    }
}
