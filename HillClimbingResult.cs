using System.Diagnostics;

namespace NQueenHillClimbing
{
    class HillClimbingResult(ref NQueen initialState)
    {
        private NQueen InitialState = new NQueen(ref initialState);

        private int Size = initialState.GetSize();

        private int Iterations = 0;

        private int Objective;

        public NQueen CurrentState = new NQueen(ref initialState);

        public Stopwatch Watch = Stopwatch.StartNew();


        public NQueen GetInitialState()
        {
            return InitialState;
        }

        public int GetSize()
        {
            return Size;
        }

        public ref NQueen GetCurrentState()
        {
            return ref CurrentState;
        }

        public void AddIteration()
        {
            Iterations++;
        }

        public int GetIterations()
        {
            return Iterations;
        }

        public int GetObjective()
        {
            return Objective;
        }

        public void SetObjective(int objective)
        {
            Objective = objective;
        }

        public void FinishWatch()
        {
            Watch.Stop();
        }

        public long GetWatchTicks()
        {
            return Watch.ElapsedTicks;
        }

        public override string ToString()
        {
            string result = String.Empty;

            result += $"Estado Inicial: {InitialState}\n";
            result += $"Estado Final: {CurrentState}\n";
            result += $"Objetivo: {Objective}\n";
            result += $"Iterações: {Iterations}\n";
            result += $"Tempo de Execução: {Watch.ElapsedTicks} ticks";

            return result;
        }
    }
}