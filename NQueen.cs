namespace NQueenHillClimbing
{
    class NQueen
    {
        private int[] State;
        private int Size;

        public NQueen(int NSize)
        {
            State = new int[NSize];
            Size = NSize;
                    
        }

        public NQueen(ref NQueen queen)
        {
            Size = queen.GetSize();
            State = new int[Size];

            for (int i = 0; i < Size; i++)
                State[i] = queen.GetStatePosition(i);
        }

        public void FillRandomly()
        {
            var random = new Random();

            for (int i = 0; i < Size; i++)
                State[i] = random.Next(0, Size);
        }

        public int GetSize()
        {
            return Size;
        }

        public int GetStatePosition(int index)
        {
            return State[index];
        }

        public int[] GetState()
        {
            return State;
        }

        public int[,] GenerateBoard()
        {
            var board = new int[Size, Size];

            for (int i = 0; i < Size; i++) 
                for (int j = 0; i < Size; j++)
                    board[i, j] = 0;

            for (int i = 0; i < Size; i++)
                board[State[i], i] = 1;

            return board;
        }

        public int GetPositionCollisions(int index)
        {
            int collisions = 0;

            for (int i = 0; i < Size; i++) {
                if (i == index) continue;
                if (State[index] == State[i]) collisions++;

                int diffHorizontally = Math.Abs(i - index);
                int diffVertically = Math.Abs(State[i] - State[index]);

                if (diffHorizontally == diffVertically) collisions++;
            }

            return collisions;
        }

        public void UpdatePositionState(int index, int value)
        {
            State[index] = value;
        }

        public void FillState(int[] state)
        {
            for (int i = 0; i < Size; i++) 
                State[i] = state[i];
        }

        public bool EqualsState(int[] state)
        {
            for (int i = 0; i < Size; i++)
                if (State[i] != state[i]) return false;

            return true;
        }

        public override string ToString()
        {
            string data = "";

            for (int i = 0; i < Size; i++)
                data += $"{State[i]} ";

            return data;
        }
    }
}
