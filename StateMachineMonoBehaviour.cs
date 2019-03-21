using UnityEngine;

// ReSharper disable SuspiciousTypeConversion.Global

namespace hStates
{
    public sealed class StateMachineMonoBehaviour : MonoBehaviour
    {
        private readonly StateMachine _stateMachine = new StateMachine();

        private void Update() => _stateMachine.Update();
        private void LateUpdate() => _stateMachine.LateUpdate();

        public void ChangeState(IState state) => _stateMachine.ChangeState(state);

        private void OnApplicationPause(bool pauseStatus) => _stateMachine.OnApplicationPause(pauseStatus);
    }
}