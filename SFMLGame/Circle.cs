using SFML.System;
using SFML.Graphics;

namespace SFMLGame
{
    class Circle : GameObject
    {
        public int score = 0;

        public int radius;

        private CircleShape shape;

        private Vector2u windowSize;

        public Circle(int _radius, Vector2u _windowSize, RenderWindow window)
            : base(window)
        {
            windowSize = _windowSize;

            shape = new CircleShape(1);
            shape.Radius = _radius;
            radius = _radius;
            shape.FillColor = Color.Red;

            shape.Origin = new Vector2f(shape.Radius, shape.Radius);

            mesh = shape;

            velocity = new Vector2f(600, 400);
            mesh.Position = new Vector2f(400, 300);
        }

        public void Update()
        {
            if(Position.X < radius && velocity.X < 0)
            {
                BounceX();
            }
            if(Position.Y < radius && velocity.Y < 0)
            {
                BounceY();
            }
            if(Position.X > windowSize.X - radius && velocity.X > 0)
            {
                BounceX();
            }
            if(Position.Y > windowSize.Y - radius && velocity.Y > 0)
            {
                BounceY();
            }
        }
        public void BounceX()
        {
            velocity.X = -velocity.X;
        }
        public void BounceY()
        {
            velocity.Y = -velocity.Y;
        }
    }
}
