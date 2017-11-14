using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NSUtils.NSFSM
{
	public class StackFSM<TState> where TState : FSMState
	{
		private Stack<TState> States;
		public TState CurrentState => States.Peek();

		public StackFSM(TState defaultState)
		{
			States = new Stack<TState>();

			States.Push(defaultState);
			defaultState.OnEnter();
		}

		public void Push(TState state)
		{
			CurrentState.OnExit();
			States.Push(state);
			CurrentState.OnEnter();
			(CurrentState as StackFSMState)?.OnPush();
		}

		public void Pop()
		{
			if (States.Count <= 1) return;
			CurrentState.OnExit();
			(CurrentState as StackFSMState)?.OnPop();
			States.Pop();
			CurrentState.OnEnter();
		}

		public void PopAll()
		{
			if (States.Count == 1) return;

			CurrentState.OnExit();
			while (States.Count > 1)
			{
				(CurrentState as StackFSMState)?.OnPop();
				States.Pop();
			}
			CurrentState.OnEnter();
		}

		public void Set(TState state)
		{
			PopAll();
			Push(state);
		}
	}
}
