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

		ResetVolatileState();
	}

	public void ResetVolatileState()
	{
		HPCur = 1;//HPMax;
		CurrentStatus = MonsterStatus.Inst_NoStatus;
	}

	#region actions
	public BattleAction[] Actions;
	#endregion

	#region status
	public int HPMax => 10;
	private int _HPCur = 5;
	public int HPCur
	{
		get { return _HPCur; }
		set { _HPCur = value.Clamp(0, HPMax); }
	}
	public bool IsDead => HPCur == 0;

	public MonsterStatus CurrentStatus;
	#endregion
}
