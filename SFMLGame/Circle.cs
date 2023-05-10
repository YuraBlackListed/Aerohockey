using SFML.System;
using SFML.Graphics;
using SFML.Window;

namespace SFMLGame
{
    class Circle
    {

        public int Radius
        {
            get { return (int)shape.Radius; }
            set { shape.Radius = value; }
        }

        private CircleShape shape;
        public CircleShape Shape
        {
            get { return shape; }
            set { shape = value;}
        }

        private Vector2f position  = new Vector2f(400, 300);
        public Vector2f Position
        {
            get { return position; }
            set { position = value; shape.Position = position; }
        }

        public Vector2f velocity = new Vector2f(300, 200);

        public Circle(int _radius)
        {
            shape = new CircleShape(1);
            Radius = _radius;
            shape.FillColor = Color.Red;

            shape.Origin = new Vector2f(shape.Radius, shape.Radius);
            shape.Position = position;
        }
    }
}
