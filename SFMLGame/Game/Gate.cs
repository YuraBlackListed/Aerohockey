using SFML.System;
using SFML.Graphics;
using SFMLGame.Engine;

namespace SFMLGame.Game
{
    class Gate : GameObject
    {
        public RectangleShape Shape;

        public Gate(bool left, Color color, RenderWindow window) : base(window)
        {
            Shape = new RectangleShape(new Vector2f(10f, window.Size.Y));
            if (left)
            {
                Shape.Position = new Vector2f(0, window.Size.Y / 2);
            }
            else
            {
                Shape.Position = new Vector2f(window.Size.X, window.Size.Y / 2);
            }
            Shape.Origin = new Vector2f(Shape.Size.X / 2f, Shape.Size.Y / 2f);

            Shape.FillColor = color;

            Mesh = Shape;
        }
    }
}
