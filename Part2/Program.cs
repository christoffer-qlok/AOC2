namespace Part2
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

                sum += GetPower(draws);
            }
            Console.WriteLine(sum);
        }

        static int GetPower(string[][] draws)
        {
            var minCubes = new Dictionary<string, int>()
            {
                { "red", 0 },
                { "green", 0},
                { "blue", 0 }
            };
            foreach (var draw in draws)
            {
                foreach (string set in draw)
                {
                    var parts = set.Split(" ", 2);
                    var count = int.Parse(parts[0]);
                    var color = parts[1];
                    minCubes[color] = Math.Max(minCubes[color], count);
                }
            }
            return minCubes["red"] * minCubes["blue"] * minCubes["green"];
        }
    }
}