using System;
using hStates;

namespace tests
{
    public class TestStateA : IState, IEnterState, IUpdateable
    {
        public bool DidOnEnter;
        public bool DidOnExit;
        public bool DidUpdate;
        public bool DidLateUpdate;

        public DateTime TimeCreated;

        public TestStateA()
        {
            TimeCreated = DateTime.UtcNow;
        }

        public bool CanTransition() => false;
        public IState NextState() => default(IState);
        
        public void OnEnter() => DidOnEnter = true;

        public void Update() => DidUpdate = true;
        public void LateUpdate() => DidLateUpdate = true;

        public void OnExit() => DidOnExit = true;
    }
}