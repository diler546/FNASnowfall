using Microsoft.Xna.Framework;

namespace FNASnowfall
{
    /// <summary>
    /// Представляет снежинку с определённой позицией, размером и скоростью.
    /// </summary>
    internal class Snowflake
    {
        /// <summary>
        /// Получает или задаёт позицию снежинки.
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Получает или задаёт размер снежинки.
        /// </summary>
        public float Size { get; set; }

        /// <summary>
        /// Получает или задаёт скорость падения снежинки.
        /// </summary>
        public float Speed { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Snowflake"/> с заданными позицией, размером и скоростью.
        /// </summary>
        /// <param name="startPosition">Начальная позиция снежинки.</param>
        /// <param name="size">Размер снежинки.</param>
        /// <param name="speed">Скорость падения снежинки.</param>
        public Snowflake(Vector2 startPosition, float size, float speed)
        {
            Position = startPosition;
            Size = size;
            Speed = speed;
        }
    }
}
