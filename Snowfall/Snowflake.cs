using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SnowfallFNA
{
    internal class Snowflake
    {
        public Vector2 Position { get; private set; }
        private readonly float speed;
        private readonly float size;
        private readonly Texture2D texture;

        /// <summary>
        /// Инициализация текстуры, позиции, скорости и размера.
        /// </summary>
        public Snowflake(Texture2D texture, Vector2 startPosition, float speed, float size)
        {
            this.texture = texture;
            Position = startPosition;
            this.speed = speed;
            this.size = size;
        }

        /// <summary>
        /// Обновляет положение снежинки.
        /// </summary>
        public void UpdateFall(GameTime gameTime)
        {
            Position = new Vector2(Position.X, Position.Y + speed * (float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        /// <summary>
        /// Сбрасывает позицию снежинки.
        /// </summary>
        public void ResetPosition(Vector2 newPosition)
        {
            Position = newPosition;
        }

        /// <summary>
        /// Отрисовывает снежинку.
        /// </summary>
        public void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, null, Color.White, 0f, Vector2.Zero, size, SpriteEffects.None, 0f);
        }
    }
}
