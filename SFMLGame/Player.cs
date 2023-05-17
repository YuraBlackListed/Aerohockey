using SFML.System;
using SFML.Graphics;
using SFML.Window;

namespace SFMLGame
{
    class Player : GameObject
    {
        public int score = 0;

        private float coordinateX;

        private Keyboard.Key up;
        private Keyboard.Key down;

        public RectangleShape shape;

        private Vector2u windowSize;

        public float shapeSizeX = 30f;
        public float shapeSizeY = 100f;

        public Player(Color color, bool left, RenderWindow window) : base(window)
        {
            shape = new RectangleShape(new Vector2f(shapeSizeX, shapeSizeY));
            if (left)
            {
                coordinateX = 50f;
                shape.Position = new Vector2f(coordinateX, 300);
                up = Keyboard.Key.W;
                down = Keyboard.Key.S;
            }
            else
            {
                coordinateX = window.Size.X - 50f;
                shape.Position = new Vector2f(window.Size.X - 50f, 300);
                up = Keyboard.Key.Up;
                down = Keyboard.Key.Down;
            }
            shape.Origin = new Vector2f(shape.Size.X / 2f, shape.Size.Y / 2f);

            shape.FillColor = color;

            mesh = shape;

            windowSize = window.Size;
        }

        public void Update()
        {
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
                velocity.Y = -300f;
            }
            else if (Keyboard.IsKeyPressed(down))
            {
                velocity.Y = 300f;
            }
            else
            {
                velocity.Y = 0;
            }
        }
    }
}