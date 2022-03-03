class Program
{
	public static void Main()
	{
		var sr = new StreamReader("../../../../input.txt");
		string? line = sr.ReadLine();
		var countdown = new long[9];
		if (line == null) return;

		var tokens = line.Split(',');
		foreach (var fish in tokens)
		{
			try
			{
				countdown[long.Parse(fish)]++;
			}
			catch { }
		}

		for (int i = 0; i < 256; i++)
		{
			var newFish = countdown[0];
			countdown[0] = countdown[1];
			countdown[1] = countdown[2];
			countdown[2] = countdown[3];
			countdown[3] = countdown[4];
			countdown[4] = countdown[5];
			countdown[5] = countdown[6];
			countdown[6] = countdown[7];
			countdown[7] = countdown[8];
			countdown[8] = newFish;
			countdown[6] += newFish;
		}

		var population = 0L;
		foreach (var i in countdown)
		{
			population += i;
		}

		Console.WriteLine(population);
	}
}