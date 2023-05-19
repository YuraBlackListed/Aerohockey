﻿using SFML.System;
using SFML.Graphics;
using SFML.Window;
using System.IO;


namespace SFMLGame
{
    class GameLoop
    {
        private bool running = false;

        private const int windiwWidth = 1200;
        private const int windowHeight = 600;

        private RenderWindow scene;

        private Clock clock = new Clock();

        private Game game;

        public void Run()
        {
            Start();
            while (running)
            {
                Render();
                CheckInput();
                Update();
            }
        }
        private void Start()
        {
            running = true;

            scene = new RenderWindow(new VideoMode(windiwWidth, windowHeight), "Game window");
            scene.DispatchEvents();

            game = new Game(scene);
            game.Start();
        }

        private void Update()
        {
            Time deltaTime = clock.Restart();
            float seconds = deltaTime.AsSeconds();

            game.Update(seconds);
        }
        private void Render()
        {
            scene.Clear(Color.Black);

            scene.Draw(game.player1Score);
            scene.Draw(game.player2Score);


            game.Render();

            scene.Display();
        }
        private void CheckInput()
        {
            game.CheckInput();
        }
    }
}
