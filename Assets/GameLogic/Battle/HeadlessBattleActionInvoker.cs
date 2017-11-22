using System;
using System.Collections.Generic;
using System.Linq;

public class HeadlessBattleActionInvoker
{
	private List<BattleActionInvocation> Invocations;
	public event Action<BattleActionInvocation> OnInvocationAdded = delegate {};

	public HeadlessBattleActionInvoker()
	{
		Invocations = new List<BattleActionInvocation>();
	}

	public void AddInvocation(BattleActionInvocation invocation)
	{
		Invocations.Add(invocation);
		OnInvocationAdded(invocation);
	}

	public void Step(float dt)
	{
		Invocations.ForEach((el) => el.Step(dt));
		Invocations.RemoveAll(el => el.IsFinished);
	}
}
