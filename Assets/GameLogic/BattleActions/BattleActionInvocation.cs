using System.Collections.Generic;
using UnityEngine;

public abstract class BattleActionInvocation
{
	public readonly BattleAction Action;
	public readonly BattlingMonster Source;
	public readonly BattlingMonster Target;

	public float Progress { get; private set; }
	public float NormalizedProgress => Progress / Action.Duration;
	public bool IsFinished => Progress >= Action.Duration;

	public BattleActionInvocation(BattleAction action, BattlingMonster source, BattlingMonster target)
	{
		Action = action;
		Source = source;
		Target = target;
		Progress = 0.0f;
	}

	public void Step(float dt)
	{
		Progress += dt;
		if (IsFinished)
		{
			PerformAction();
		}
	}

	public abstract void PerformAction();
}
