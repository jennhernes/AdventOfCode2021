class Program
{
	public static void Main()
	{
		var sr = new StreamReader("../../../../input.txt");
		var vents = new List<Vent>();

		string? line;
		var maxX = 0;
		var maxY = 0;
		while ((line = sr.ReadLine()) != null)
		{
			var nums = line.Split(new char[] { ',', ' ', '-', '>' }).ToList().ConvertAll(x => x == "" ? -1 : int.Parse(x));
			nums.RemoveAll(x => x == -1);
			//if (!(nums[0] == nums[2] || nums[1] == nums[3]))
			//{
			//	continue;
			//}
			vents.Add(new Vent(nums[0], nums[1], nums[2], nums[3]));
			maxX = Math.Max(maxX, nums[0]);
			maxX = Math.Max(maxX, nums[2]);
			maxY = Math.Max(maxY, nums[1]);
			maxY = Math.Max(maxY, nums[3]);
		}

		Console.WriteLine(maxX + " " + maxY);
		var map = new int[maxX + 1, maxY + 1];
		var overlaps = 0;
		foreach (var vent in vents)
		{
			foreach (var point in vent.points)
			{
				map[point.x, point.y] += 1;
				if (map[point.x, point.y] == 2)
				{
					//Console.Write(point.x + " " + point.y + "\n");
					overlaps++;
				}
			}
		}

		//for (int i = 0; i < map.GetLength(1); i++)
		//{
		//	for (int j = 0; j < map.GetLength(0); j++)
		//	{
		//		Console.Write(map[j, i]);
		//	}
		//	Console.WriteLine();
		//}

		Console.WriteLine(overlaps);
	}
}

public class Vent
{
	public List<Point> points;

	public Vent(int x1, int y1, int x2, int y2)
	{
		points = new List<Point>();
		if (x1 == x2)
		{
			for (int j = Math.Min(y1, y2); j <= Math.Max(y1, y2); j++)
			{
				points.Add(new Point(x1, j));
			}
		}
		else if (y1 == y2)
		{
			for (int i = Math.Min(x1, x2); i <= Math.Max(x1, x2); i++)
			{
				points.Add(new Point(i, y1));
			}
		}
		else if (Math.Sign(x2 - x1) == Math.Sign(y2 - y1))
		{
			for (int i = Math.Min(x1, x2), j = Math.Min(y1, y2); i <= Math.Max(x1, x2) && j <= Math.Max(y1, y2); i++, j++)
			{
				points.Add(new Point(i, j));
			}
		}
		else
		{
			for (int i = Math.Min(x1, x2), j = Math.Max(y1, y2); i <= Math.Max(x1, x2) && j >= Math.Min(y1, y2); i++, j--)
			{
				points.Add(new Point(i, j));
			}
		}

		//Console.WriteLine(x1 + "," + y1 + "->" + x2 + "," + y2);
		//foreach (var point in points)
		//{
		//	Console.Write(point.x + "," + point.y + "; ");
		//}
		//Console.WriteLine();
	}
}

public class Point
{
	public int x;
	public int y;

	public Point(int x, int y)
	{
		this.x = x;
		this.y = y;
	}
}