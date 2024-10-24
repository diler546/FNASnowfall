using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FNASnowfall
{
    /// <summary>
    /// Игра, симулирующая снегопад с анимацией снежинок.
    /// </summary>
    public class Snowfall : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Texture2D snowflakeTexture;
        private Texture2D backgroundTexture;
        private List<Snowflake> snowflakes;

        private readonly int windowHeight;
        private readonly int windowWidth;
        private readonly Random random = new Random();
        private MouseState previousMouseState;

        /// <summary>
        /// Инициализирует новый экземпляр игры <see cref="Snowfall"/>.
        /// Устанавливает графические параметры и начальные настройки.
        /// </summary>
        public Snowfall()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            windowWidth = graphics.PreferredBackBufferWidth;
            windowHeight = graphics.PreferredBackBufferHeight;

            graphics.IsFullScreen = true;
            IsMouseVisible = false;
        }

        /// <summary>
        /// Инициализация игры. Генерирует начальный список снежинок.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            snowflakes = new List<Snowflake>();
            for (var i = 0; i < 600; i++)
            {
                snowflakes.Add(GenerateRandomSnowflake());
            }

            previousMouseState = Mouse.GetState();
        }

        /// <summary>
        /// Загружает ресурсы для игры, такие как текстуры снежинки и фона.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            snowflakeTexture = Content.Load<Texture2D>("Snowflake");
            backgroundTexture = Content.Load<Texture2D>("Background");
        }

        /// <summary>
        /// Обновляет состояние игры, в том числе позицию снежинок и проверяет события ввода с клавиатуры и мыши.
        /// </summary>
        /// <param name="gameTime">Объект, представляющий время с момента последнего обновления.</param>
        protected override void Update(GameTime gameTime)
        {
            var currentMouseState = Mouse.GetState();
            if (currentMouseState.X != previousMouseState.X ||
                currentMouseState.Y != previousMouseState.Y ||
                Keyboard.GetState().GetPressedKeys().Length > 0)
            {
                Exit();
            }

            UpdateSnowFlakePosition(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// Обновляет позиции снежинок в зависимости от времени.
        /// Если снежинка выходит за пределы окна, она перемещается наверх экрана.
        /// </summary>
        /// <param name="gameTime">Объект, представляющий время с момента последнего обновления.</param>
        private void UpdateSnowFlakePosition(GameTime gameTime)
        {
            foreach (var snowflake in snowflakes)
            {
                snowflake.Position = new Vector2(snowflake.Position.X, snowflake.Position.Y + snowflake.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds);

                if (snowflake.Position.Y > windowHeight)
                {
                    snowflake.Position = new Vector2(random.Next(0, windowWidth), -50);
                }
            }
        }

        /// <summary>
        /// Отрисовывает кадр игры, включая фон и снежинки.
        /// </summary>
        /// <param name="gameTime">Объект, представляющий время с момента последнего обновления.</param>
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

            foreach (var snowflake in snowflakes)
            {
                spriteBatch.Draw(snowflakeTexture, snowflake.Position, null, Color.White, 0f, Vector2.Zero, snowflake.Size, SpriteEffects.None, 0f);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private Snowflake GenerateRandomSnowflake()
        {
            var size = (float)random.Next(2, 5) / 100;
            var speed = random.Next(10, 50);
            var startPosition = new Vector2(random.Next(0, windowWidth), random.Next(0, windowHeight));

            return new Snowflake(startPosition, size, speed);
        }
    }
}
