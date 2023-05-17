using SFML.System;
using SFML.Graphics;
using SFML.Window;

namespace SFMLGame
{
    class Player : GameObject
    {
        public int score { get; private set; } = 0;

        private float coordinateX;

        private Keyboard.Key up;
        private Keyboard.Key down;

        public RectangleShape shape;

        private Vector2u windowSize;

        public Player(Color color, Vector2u _windowSize, bool left, RenderWindow window) : base(window)
        {
            shape = new RectangleShape(new Vector2f(30f, 100f));
            if (left)
            {
                coordinateX = 50f;
                shape.Position = new Vector2f(coordinateX, 300);
                up = Keyboard.Key.W;
                down = Keyboard.Key.S;
            }
            else
            {
                coordinateX = _windowSize.X - 50f;
                shape.Position = new Vector2f(_windowSize.X - 50f, 300);
                up = Keyboard.Key.Up;
                down = Keyboard.Key.Down;
            }
            shape.Origin = new Vector2f(shape.Size.X / 2f, shape.Size.Y / 2f);

            shape.FillColor = color;

            mesh = shape;

            windowSize = _windowSize;
        }

        public void Update()
        {
            Position += velocity;
            velocity.Y = 0;

            if(Position.Y < 90f)
            {
                Position = new Vector2f(coordinateX, 90f);
            }
            else if(Position.Y > windowSize.Y - 90f)
            {
                Position = new Vector2f(coordinateX, windowSize.Y - 90f);
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
                velocity.Y += 0.2f;
            }
        }
    }
}