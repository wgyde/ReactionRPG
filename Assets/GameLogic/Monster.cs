using NSUtils;
using System.Collections.Generic;
using UnityEngine;

public class Monster
{
	private const int ACTION_COUNT = 2;

	public readonly BattleTeam ParentTeam;
	public readonly int Index;

	public Monster(BattleTeam parentTeam, int index)
	{
		ParentTeam = parentTeam;
		Index = index;

		Actions = new BattleAction[ACTION_COUNT];
		for (int i = 0; i < Actions.Length; ++i)
			Actions[i] = new BattleAction_Damage() { TargetType = BattleAction.TTargetType.Enemy };
		Actions[1] = new BattleAction_Heal() { TargetType = BattleAction.TTargetType.Friendly };

		CurrentStatus = MonsterStatus.Inst_NoStatus;
	}

	#region actions
	public BattleAction[] Actions;
	public BattleActionInvocation CurrentInvocationØ { get; private set; }
	public bool Invoking => CurrentInvocationØ != null;

	public void InvokeAction(BattleAction action, int targetPosition)
	{
		if (Invoking) return;
		CurrentInvocationØ = action.Invoke(this, targetPosition);
	}
	#endregion

	#region status
	public int HPMax => 10;
	private int _HPCur = 5;
	public int HPCur
	{
		get { return _HPCur; }
		set { _HPCur = value.Clamp(0, HPMax); }
	}

	public MonsterStatus CurrentStatus;
	#endregion

	public void Step(float dt)
	{
		if (CurrentInvocationØ != null)
		{
			CurrentInvocationØ.Step(dt);
			if (CurrentInvocationØ.IsFinished)
			{
				CurrentInvocationØ = null;
			}
		}
	}

	public override string ToString()
	{
		return $"Monster{Index}";
	}
}
