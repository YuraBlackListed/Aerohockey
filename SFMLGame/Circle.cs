using SFML.System;
using SFML.Graphics;

namespace SFMLGame
{
    class Circle : GameObject
    {
        public int score = 0;

        private int Radius
        {
            get { return (int)shape.Radius; }
            set { shape.Radius = value; }
        }

        private CircleShape shape;

        private Vector2u windowSize;

        public Circle(int _radius, Vector2u _windowSize, RenderWindow window)
            : base(window)
        {
            windowSize = _windowSize;

            shape = new CircleShape(1);
            Radius = _radius;
            shape.FillColor = Color.Red;

            shape.Origin = new Vector2f(shape.Radius, shape.Radius);

            mesh = shape;

            velocity = new Vector2f(600, 400);
            mesh.Position = new Vector2f(400, 300);
        }

        public void Update()
        {
            if(Position.X < Radius && velocity.X < 0)
            {
                velocity.X = -velocity.X;
            }
            if(Position.Y < Radius && velocity.Y < 0)
            {
                velocity.Y = -velocity.Y;
            }
            if(Position.X > windowSize.X - Radius && velocity.X > 0)
            {
                velocity.X = -velocity.X;
            }
            if(Position.Y > windowSize.Y - Radius && velocity.Y > 0)
            {
                velocity.Y = -velocity.Y;
            }
        }

    }
}
