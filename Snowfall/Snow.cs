using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace SnowfallFNA
{
    public class Snow : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Texture2D textureSnowflake;
        private Texture2D textureBackground;
        private List<Snowflake> snowflakes;

        private const int ScreenHeight = 600;
        private const int ScreenWidth = 1000;
        private readonly Random random = new Random();

        /// <summary>
        /// Конфигурация графики.
        /// </summary>
        public Snow()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = ScreenHeight;
            graphics.PreferredBackBufferWidth = ScreenWidth;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Инициализация игры.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Загрузка ресурсов.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            textureSnowflake = Content.Load<Texture2D>("snowflake");
            textureBackground = Content.Load<Texture2D>("background");

            snowflakes = new List<Snowflake>();

            for (var i = 0; i < 75; i++)
            {
                var size = (float)random.Next(3, 10) / 100;
                // Скорость падения зависит от размера (чем больше размер, тем меньше скорость).
                var speed = (1 / size) * 5f;
                var initialPosition = new Vector2(random.Next(0, ScreenWidth), random.Next(0, ScreenHeight));

                snowflakes.Add(new Snowflake(textureSnowflake, initialPosition, speed, size));
            }
        }

        /// <summary>
        /// Обработка движения снежинок и перезапуск при выходе за границы.
        /// </summary>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            foreach (var snowflake in snowflakes)
            {
                snowflake.UpdateFall(gameTime);

                if (snowflake.Position.Y > ScreenHeight)
                {
                    snowflake.ResetPosition(new Vector2(random.Next(0, ScreenWidth), -200));
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// Отрисовка снежинок.
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(textureBackground, new Rectangle(0, 0, ScreenWidth, ScreenHeight), Color.White);

            foreach (var snowflake in snowflakes)
            {
                snowflake.Render(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
