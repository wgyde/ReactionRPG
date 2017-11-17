using System.Collections.Generic;
using UnityEngine;

public class BattleAction_Status : BattleAction
{
	private class Invocation : BattleActionInvocation_Generic<BattleAction_Status>
	{
		public Invocation(BattleAction_Status action, BattleSlot_Monster source, BattleSlot_Monster target) : base(action, source, target)
		{
		}

		public override void PerformAction()
		{
			Target.Monster.CurrentStatus = Action.Status;
		}
	}

	public override Color Color => Status.Color;

	public readonly MonsterStatus Status;

	public BattleAction_Status(MonsterStatus status)
	{
		Status = status;
	}

	protected override BattleActionInvocation Invoke(BattleSlot_Monster source, BattleSlot_Monster target)
	{
		return new Invocation(this, source, target);
	}
}
