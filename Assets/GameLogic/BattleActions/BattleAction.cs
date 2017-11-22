using NSUtils.Exceptions;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleAction
{
	public enum TTargetType
	{
		Enemy,
		Friendly
	}
	
	public readonly float Duration = 0.5f;
	public TTargetType TargetType;
	public abstract Color Color { get; }

	private BattlingMonster FindTarget(BattlingMonster source, int targetPosition)
	{
		switch (TargetType)
		{
			case TTargetType.Enemy: return source.ParentBattlingTeam.EnemyTeamSlot.BattlingMonsters[targetPosition];
			case TTargetType.Friendly: return source.ParentBattlingTeam.BattlingMonsters[targetPosition];
			default: throw UnsupportedEnumMemberException.GetGeneric(TargetType);
		}
	}

	public BattleActionInvocation Invoke(BattlingMonster source, int targetPosition)
	{
		return Invoke(source, FindTarget(source, targetPosition));
	}

	protected abstract BattleActionInvocation Invoke(BattlingMonster source, BattlingMonster target);
}
