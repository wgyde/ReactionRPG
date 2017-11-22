using NSUtils;
using System.Collections.Generic;
using UnityEngine;

public class Monster
{
	private const int ACTION_COUNT = 2;

	public Monster()
	{
		Actions = new BattleAction[ACTION_COUNT];
		for (int i = 0; i < Actions.Length; ++i)
			Actions[i] = new BattleAction_Damage() { TargetType = BattleAction.TTargetType.Enemy };
		Actions[1] = new BattleAction_Heal() { TargetType = BattleAction.TTargetType.Friendly };
	}
	
	public BattleAction[] Actions;
}
