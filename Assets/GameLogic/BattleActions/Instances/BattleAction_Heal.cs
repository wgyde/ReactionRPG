using System.Collections.Generic;
using UnityEngine;

public class BattleAction_Heal : BattleAction
{
	private class Invocation : BattleActionInvocation_Generic<BattleAction_Heal>
	{
		public Invocation(BattleAction_Heal action, Monster self, Monster target) : base(action, self, target)
		{
		}

		public override void PerformAction()
		{
			Target.HPCur += 1;
		}
	}

	public override Color Color => Color.green;

	protected override BattleActionInvocation Invoke(Monster self, Monster target)
	{
		return new Invocation(this, self, target);
	}
}
