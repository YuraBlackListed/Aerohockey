using SFML.System;
using SFML.Graphics;

namespace SFMLGame
{
    class Gate : GameObject
    {
        private Player opponent;

        public RectangleShape shape;

        public Gate(Player _opponent, bool left, Color color, RenderWindow window) : base(window)
        {
            opponent = _opponent;

            shape = new RectangleShape(new Vector2f(10f, window.Size.Y));
            if (left)
            {
                shape.Position = new Vector2f(0, window.Size.Y / 2);
            }
            else
            {
                shape.Position = new Vector2f(window.Size.X, window.Size.Y / 2);
            }
            shape.Origin = new Vector2f(shape.Size.X / 2f, shape.Size.Y / 2f);

            shape.FillColor = color;

            Mesh = shape;
        }
        public void PlayerScored()
        {
            opponent.Score++;
        }
    }
}
