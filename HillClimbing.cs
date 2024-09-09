namespace NQueenHillClimbing
{
    class HillClimbing
    {

        public HillClimbingResult Run(ref NQueen initialState, int limitIterations = -1)
        {
            var result = new HillClimbingResult(ref initialState);
            var neighbourState = new NQueen(ref result.GetCurrentState());

            do {
                result.GetCurrentState().FillState(neighbourState.GetState());
                result.SetObjective(CalculateObjective(ref neighbourState));
                GetNeighbour(ref neighbourState);

                if (result.GetCurrentState().EqualsState(neighbourState.GetState())) break;
                
                if (CalculateObjective(ref result.GetCurrentState()) == CalculateObjective(ref neighbourState))
                    neighbourState.UpdatePositionState(new Random().Next(result.GetSize()), new Random().Next(result.GetSize()));
                
                result.AddIteration();
            } while(limitIterations == -1 || limitIterations > result.GetIterations());

            result.FinishWatch();

            return result;
        }

        public void GetNeighbour(ref NQueen state)
        {
            var opState = new NQueen(ref state);
            int opObjective = CalculateObjective(ref opState);

            var neighbourState = new NQueen(ref state);
            
            for (int i = 0; i < state.GetSize(); i++) {
                for (int j =0; j < state.GetSize(); j++) {
                    if (j != state.GetStatePosition(i)) {
                        neighbourState.UpdatePositionState(i, j);
                        int objective = CalculateObjective(ref neighbourState);
                        
                        if (objective <= opObjective) {
                            opObjective = objective;
                            opState.FillState(neighbourState.GetState());
                        }

                        neighbourState.UpdatePositionState(i, state.GetStatePosition(i));
                    }
                }
            }

            state.FillState(opState.GetState());
        }

        public int CalculateObjective(ref NQueen state)
        {
            int attacking = 0;

            for (int i = 0; i < state.GetSize(); i++)
                attacking += state.GetPositionCollisions(i);

            return attacking / 2;
        }
    }
}
