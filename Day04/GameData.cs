namespace Day04
{
	class GameData
	{
		public List<int> NumberList { get; set; }
		public List<BingoBoard> BingoBoards { get; set; }
		public List<bool> HasWon { get; set; }

		public GameData(string filename)
		{
			StreamReader sr = new StreamReader(filename);
			string? line;

			NumberList = new List<int>(); 
			BingoBoards = new List<BingoBoard>();
			HasWon = new List<bool>();

			line = sr.ReadLine();
			if (line == null) return;
			line.Split(',').ToList().ForEach(x => NumberList.Add(int.Parse(x)));

			while ((line = sr.ReadLine()) != null)
			{
				var card = new List<int>();
				for (int i = 0; i < 5; i++)
				{
					sr.ReadLine().Split(' ').ToList().ForEach(x =>
					{
						if (x != "")
							card.Add(int.Parse(x));
					}
					);
				}
				BingoBoards.Add(new BingoBoard(card));
				HasWon.Add(false);
			}
		}
	}
}