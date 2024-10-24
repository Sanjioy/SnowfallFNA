namespace SnowfallFNA
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Snow game = new Snow())
            {
                game.Run();
            }
        }
    }
}
