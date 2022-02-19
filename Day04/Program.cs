using System;

namespace Day04
{
	class Program
	{
		public static void Main()
		{
			GameData gd = new GameData("../../../input.txt");
			Console.WriteLine(PlayGame(gd));
		}

		public static int PlayGame(GameData data)
		{
			int winners = 0;
			bool lastWinner = false;
			for (int i = 0; i < data.NumberList.Count; i++)
			{
				for (int j = 0; j < data.BingoBoards.Count; j++)
				{
					data.BingoBoards[j].Update(data.NumberList[i]);
					if (data.BingoBoards[j].HasWon() && !data.HasWon[j])
					{
						if (winners == data.HasWon.Count - 1)
						{
							lastWinner = true;
							var maxscore = 0;
							var score = data.BingoBoards[j].CalculateScore();
							maxscore = Math.Max(maxscore, score);

							return maxscore;
						}
						else
						{
							winners++;
							data.HasWon[j] = true;
						}
					}
				}
				if (lastWinner) break;
			}

			return -1;
		}
	}
}