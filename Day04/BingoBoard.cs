namespace Day04
{
    class BingoBoard
    {
        List<List<int>> board;
        List<List<bool>> called;
        int final = -1;
        int score;

        public BingoBoard(List<int> numbers)
		{
            board = new List<List<int>>();
            called = new List<List<bool>>();
            for (int i = 0; i < numbers.Count; i++)
			{
                if (board.Count <= i / 5) board.Add(new List<int>());
                if (called.Count <= i / 5) called.Add(new List<bool>());
                board[i/5].Add(numbers[i]);
                called[i / 5].Add(false);
			}
		}

        public bool Contains(int x)
		{
            foreach(var line in board)
			{
                if (line.Contains(x))
				{
                    return true;
				}
			}

            return false;
		}

        public bool Update(int num)
		{
            for (int i = 0; i < 5; i++)
			{
                for (int j = 0; j < 5; j++)
				{
                    if (board[i][j] == num)
					{
                        called[i][j] = true;
                        final = num;
                        return true;
					}
				}
			}

            return false;
		}

        public bool HasWon()
		{
            // check rows and cols
            for (int i = 0; i < 5; i++)
			{
                if (called[i][0] == true && called[i][1] == true 
                    && called[i][2] == true && called[i][3] == true 
                    && called[i][4] == true)
				{
                    return true;
				}

                if (called[0][i] == true && called[1][i] == true
                    && called[2][i] == true && called[3][i] == true
                    && called[4][i] == true)
				{
                    return true;
				}
            }

            return false;
		}

        public int CalculateScore()
		{
            if (!HasWon()) return -1;

            var sum = 0;
            for (int i = 0; i < 5; i++)
			{
                for (int j = 0; j < 5; j++)
				{
                    if (!called[i][j])
					{
                        sum += board[i][j];
					}
				}
			}

            score = sum * final;
            return score;
		}
    }
}