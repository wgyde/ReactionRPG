using System.Collections.Generic;
using UnityEngine;

public class BattleAction_Heal : BattleAction
{
	private class Invocation : BattleActionInvocation_Generic<BattleAction_Heal>
	{
		public Invocation(BattleAction_Heal action, BattleSlot_Monster source, BattleSlot_Monster target) : base(action, source, target)
		{
		}

		public override void PerformAction()
		{
			Target.Monster.HPCur += 1;
		}
	}

	public override Color Color => Color.green;

	protected override BattleActionInvocation Invoke(BattleSlot_Monster source, BattleSlot_Monster target)
	{
		return new Invocation(this, source, target);
	}
}
