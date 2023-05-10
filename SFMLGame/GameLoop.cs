using System;
using System.Threading;
using SFML.System;
using SFML.Graphics;
using SFML.Window;


namespace SFMLGame
{
    class GameLoop
    {
        private bool running = false;

        private const int windiwWidth = 1200;
        private const int windowHeight = 600;

        private RenderWindow window;

        Circle circle;

        private Clock clock = new Clock();

        public void Run()
        {
            Start();
            while (running)
            {
                Render();
                CheckInput();
                Update();
                //Thread.Sleep(20);
            }
        }

        private void Start()
        {

            running = true;

            window = new RenderWindow(new VideoMode(windiwWidth, windowHeight), "Game window");
            window.DispatchEvents();

            circle = new Circle(50);
        }
        private void Update()
        {
            Time deltaTime = clock.Restart();
            float seconds = deltaTime.AsSeconds();

            circle.Position += circle.velocity * seconds;


            if (circle.Position.X < circle.Radius || circle.Position.X > window.Size.X - circle.Radius)
            {
                circle.velocity.X = -circle.velocity.X;
            }
            if (circle.Position.Y < circle.Radius || circle.Position.Y > window.Size.Y - circle.Radius)
            {
                circle.velocity.Y = -circle.velocity.Y;
            }

        }
        private void Render()
        {
            window.Clear(Color.Black);
            window.Draw(circle.Shape);
            window.Display();
        }
        private void CheckInput()
        {
            //I messed up, I'd better use this
        }

    }

}
