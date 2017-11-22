using System.Collections.Generic;
using UnityEngine;

public class BattleAction_Damage : BattleAction
{
	private class Invocation : BattleActionInvocation_Generic<BattleAction_Damage>
	{
		private int Damage;
		
		public Invocation(BattleAction_Damage action, BattlingMonster source, BattlingMonster target) : base(action, source, target)
		{
			Damage = action.Damage;
		}

		public override void PerformAction()
		{
			Target.SPCur -= Damage;
		}
	}

	public override Color Color => Color.red;
	private readonly int Damage = 1;

	protected override BattleActionInvocation Invoke(BattlingMonster source, BattlingMonster target)
	{
		return new Invocation(this, source, target);
	}
}
