using hStates;

namespace tests
{
    public class TestStateBForPushing : IState
    {
        public void OnExit()
        {
            
        }

        public bool CanTransition()
        {
            return false;
        }

        public IState NextState()
        {
            return default(IState);
        }
    }
}