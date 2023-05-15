using SFML.System;
using SFML.Graphics;

namespace SFMLGame
{
    class GameObject
    {
        private Vector2f position = new Vector2f(0, 0);
        public Vector2f Position
        {
            get { return position; }
            set { position = value; mesh.Position = position; }
        }

        public Vector2f velocity = new Vector2f(0, 0);

        public Shape mesh;
        
        private RenderWindow scene;

        public GameObject(RenderWindow window)
        {
            scene = window;
        }

        public void Draw()
        {
            scene.Draw(mesh);
        }
    }
}
