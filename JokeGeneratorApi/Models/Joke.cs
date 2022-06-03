using System;

namespace JokeGeneratorApi
{
    public class Joke
    {
        public int id { get; set; }

        public string type { get; set; }

        public string? joke { get; set; }

        public string? setup { get; set; }

        public string? delivery { get; set; }
    }
}
