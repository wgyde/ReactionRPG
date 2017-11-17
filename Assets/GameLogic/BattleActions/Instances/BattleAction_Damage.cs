using System.Collections.Generic;
using UnityEngine;

public class BattleAction_Damage : BattleAction
{
	private class Invocation : BattleActionInvocation_Generic<BattleAction_Damage>
	{
		private int Damage;
		
		public Invocation(BattleAction_Damage action, BattleSlot_Monster source, BattleSlot_Monster target) : base(action, source, target)
		{
			Damage = action.Damage;
			if (source.Monster.CurrentStatus == MonsterStatus.Inst_Inspired)
				Damage += 1;
		}

		public override void PerformAction()
		{
			if (Target.Monster.CurrentStatus == MonsterStatus.Inst_Frail)
				Damage += 1;
			Target.Monster.HPCur -= Damage;
		}
	}

	public override Color Color => Color.red;
	private readonly int Damage = 1;

	protected override BattleActionInvocation Invoke(BattleSlot_Monster source, BattleSlot_Monster target)
	{
		return new Invocation(this, source, target);
	}
}
