using SFML.System;
using SFML.Graphics;
using SFMLGame.Engine;

namespace SFMLGame.Game
{
    class Circle : GameObject
    {
        public int Radius;

        private CircleShape shape;

        private Vector2u windowSize;

        public Circle(int _radius, Vector2u _windowSize, RenderWindow window)
            : base(window)
        {
            windowSize = _windowSize;

            shape = new CircleShape(1);
            shape.Radius = _radius;
            Radius = _radius;
            shape.FillColor = Color.Red;

            shape.Origin = new Vector2f(shape.Radius, shape.Radius);

            Mesh = shape;

            Velocity = new Vector2f(600, 400);
            Mesh.Position = new Vector2f(400, 300);
        }

        public void Update(float time)
        {
            Position += Velocity * time;

            if (Position.X < Radius && Velocity.X < 0)
            {
                BounceX();
            }
            if(Position.Y < Radius && Velocity.Y < 0)
            {
                BounceY();
            }
            if(Position.X > windowSize.X - Radius && Velocity.X > 0)
            {
                BounceX();
            }
            if(Position.Y > windowSize.Y - Radius && Velocity.Y > 0)
            {
                BounceY();
            }
        }
        public void BounceX()
        {
            Velocity.X = -Velocity.X;
        }
        public void BounceY()
        {
            Velocity.Y = -Velocity.Y;
        }
    }
}
