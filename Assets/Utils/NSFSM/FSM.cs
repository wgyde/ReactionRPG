using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NSUtils.NSFSM
{
    public class FSM<TState> where TState : FSMState
    {
		public TState CurrentState { get; private set; }

		public FSM(TState initialState)
		{
			CurrentState = initialState;
			CurrentState?.OnEnter();
		}

		public void SetState(TState state)
		{
			CurrentState?.OnExit();
			CurrentState = state;
			CurrentState?.OnEnter();
		}
    }
}
