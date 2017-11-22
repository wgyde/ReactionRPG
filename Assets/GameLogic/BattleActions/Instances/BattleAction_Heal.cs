using System.Collections.Generic;
using UnityEngine;

public class BattleAction_Heal : BattleAction
{
	private class Invocation : BattleActionInvocation_Generic<BattleAction_Heal>
	{
		public Invocation(BattleAction_Heal action, BattlingMonster source, BattlingMonster target) : base(action, source, target)
		{
		}

		public override void PerformAction()
		{
			Target.SPCur += 1.0f;
		}
	}

	public override Color Color => Color.green;

	protected override BattleActionInvocation Invoke(BattlingMonster source, BattlingMonster target)
	{
		return new Invocation(this, source, target);
	}
}
