using System.Collections.Generic;
using UnityEngine;

public class BattleAction_Status : BattleAction
{
	private class Invocation : BattleActionInvocation_Generic<BattleAction_Status>
	{
		public Invocation(BattleAction_Status action, Monster self, Monster target) : base(action, self, target)
		{
		}

		public override void PerformAction()
		{
			Target.CurrentStatus = Action.Status;
		}
	}

	public override Color Color => Status.Color;

	public readonly MonsterStatus Status;

	public BattleAction_Status(MonsterStatus status)
	{
		Status = status;
	}

	protected override BattleActionInvocation Invoke(Monster self, Monster target)
	{
		return new Invocation(this, self, target);
	}
}
