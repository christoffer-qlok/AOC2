namespace AOC2
{
    internal class Program
    {
        static Dictionary<string, int> cubes = new Dictionary<string, int>()
            {
                { "red", 12 },
                { "green", 13},
                { "blue", 14 }
            };
        static void Main(string[] args)
        {
            int sum = 0;

            string[] lines = File.ReadAllLines("input.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split(": ", 2);
                int id = int.Parse(parts[0].Split(' ', 2)[1]);
                string[] drawLines = parts[1].Split("; ");
                string[][] draws = new string[drawLines.Length][];
                for (int i = 0; i < drawLines.Length; i++)
                {
                    draws[i] = drawLines[i].Split(", ");
                }

                if(CheckDraws(draws))
                {
                    sum += id;
                }
            }
            Console.WriteLine(sum);
        }

        static bool CheckDraws(string[][] draws)
        {
            return draws.All(d => CheckSingleDraw(d));
        }

        static bool CheckSingleDraw(string[] draw)
        {
            foreach (string set in draw)
            {
                var parts = set.Split(" ", 2);
                var count = int.Parse(parts[0]);
                if(count > cubes[parts[1]])
                {
                    return false;
                }
            }
            return true;
        }
    }
}