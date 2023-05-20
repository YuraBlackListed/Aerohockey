using SFML.System;
using SFML.Graphics;
using SFML.Window;
using SFMLGame.Engine;

namespace SFMLGame.Game
{
    class Player : GameObject
    {
        public int Score = 0;

        private float coordinateX;

        public RectangleShape Shape;

        private Vector2u windowSize;

        public float ShapeSizeX = 30f;
        public float ShapeSizeY = 100f;

        private InputHandler inputHandler;

        public Player(Color color, bool left, RenderWindow window) : base(window)
        {
            Shape = new RectangleShape(new Vector2f(ShapeSizeX, ShapeSizeY));
            if (left)
            {
                coordinateX = 50f;
                Shape.Position = new Vector2f(coordinateX, 300);

                inputHandler = new InputHandler(Keyboard.Key.W, Keyboard.Key.S);
            }
            else
            {
                coordinateX = window.Size.X - 50f;
                Shape.Position = new Vector2f(coordinateX, 300);

                inputHandler = new InputHandler(Keyboard.Key.Up, Keyboard.Key.Down);
            }
            Shape.Origin = new Vector2f(Shape.Size.X / 2f, Shape.Size.Y / 2f);

            Shape.FillColor = color;

            Mesh = Shape;

            windowSize = window.Size;
        }

        public void Update(float time)
        {
            Position += Velocity * time;
            if (Position.Y < 90f)
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
            Velocity.Y = inputHandler.HandleInput();
        }
    }
}