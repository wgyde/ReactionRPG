using System.Collections.Generic;
using UnityEngine;

public class BattleAction_Damage : BattleAction
{
	private class Invocation : BattleActionInvocation_Generic<BattleAction_Damage>
	{
		private int Damage;
		
		public Invocation(BattleAction_Damage action, Monster self, Monster target) : base(action, self, target)
		{
			Damage = action.Damage;
			if (self.CurrentStatus == MonsterStatus.Inst_Inspired)
				Damage += 1;
		}

		public override void PerformAction()
		{
			if (Target.CurrentStatus == MonsterStatus.Inst_Frail)
				Damage += 1;
			Target.HPCur -= Damage;
		}
	}

	public override Color Color => Color.red;
	private readonly int Damage = 1;

	protected override BattleActionInvocation Invoke(Monster self, Monster target)
	{
		return new Invocation(this, self, target);
	}
}
