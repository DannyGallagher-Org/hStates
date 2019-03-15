using UnityEngine;

// ReSharper disable SuspiciousTypeConversion.Global

namespace hStates
{
    public sealed class StateMachine : MonoBehaviour
    {
        #region delegates
        public delegate void StateChanged(IState state);
        public event StateChanged OnStateChanged;
        #endregion
	
        #region fields

        #endregion
	
        #region properties
        public IState CurrentState { get; set; }

        #endregion
	
        #region methods
        public void Update()
        {
            (CurrentState as IUpdateable)?.Update();
        }

        private void LateUpdate()
        {
            if (CurrentState == default(IState)) 
                return;
			
            if (!CurrentState.CanTransition()) return;
            var nextState = CurrentState.NextState();
            ChangeState(nextState);
        }

        public void ChangeState(IState nextState)
        {
            CurrentState?.OnExit();

            CurrentState = nextState;
            OnStateChanged?.Invoke(CurrentState);

            var enterState = nextState as IEnterState;
            enterState?.OnEnter();
        }
	
        private void OnApplicationPause(bool paused)
        {
            if(!paused)
                return;

            (CurrentState as IPausable)?.ApplicationHasGoneIntoBackground();
        }
        #endregion
    }
}