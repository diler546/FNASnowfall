namespace FNASnowfall
{
    internal static class Program
    {
        /// <summary>
        /// Основная точка входа в приложение.
        /// </summary>
        private static void Main(string[] args)
        {
            using (var snowfall = new Snowfall())
            {
                snowfall.Run();
            }
        }
    }
}
