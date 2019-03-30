using System;
using hStates;
using NUnit.Framework;

namespace tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Assert.True(true);
        }

        [Test]
        public void ChangeState()
        {
            var stateMachine = new StateMachine();
            var testStateA = new TestStateA();
            stateMachine.ChangeState(testStateA);
            
            Assert.True(stateMachine.CurrentState == testStateA);
        }
        
        [Test]
        public void OnEnter()
        {
            var stateMachine = new StateMachine();
            var testStateA = new TestStateA();
            stateMachine.ChangeState(testStateA);
            
            Assert.True(testStateA.DidOnEnter);
        }
        
        [Test]
        public void OnExit()
        {
            var stateMachine = new StateMachine();
            var testStateA = new TestStateA();
            stateMachine.ChangeState(testStateA);
            
            Assert.True(testStateA.DidOnEnter);
            
            stateMachine.ChangeState(default(IState));
            
            Assert.True(testStateA.DidOnExit);
        }
        
        [Test]
        public void UpdateLateUpdateFixedUpdate()
        {    
            var stateMachine = new StateMachine();
            var testStateA = new TestStateA();
            stateMachine.ChangeState(testStateA);
            stateMachine.Update();
            stateMachine.LateUpdate();
            
            Assert.True(testStateA.DidUpdate);
            Assert.True(testStateA.DidLateUpdate);
        }
        
        [Test]
        public void PushAndPop()
        {
            var stateMachine = new StateMachine();
            var testStateB = new TestStateBForPushing();
            var testStateA = new TestStateA();
            
            stateMachine.ChangeState(testStateA);
            Assert.True(stateMachine.CurrentState == testStateA);
            stateMachine.PushState(testStateB);
            Assert.True(stateMachine.CurrentState == testStateB);
            stateMachine.PopState();
            Assert.True(stateMachine.CurrentState == testStateA);
        }
    }
}