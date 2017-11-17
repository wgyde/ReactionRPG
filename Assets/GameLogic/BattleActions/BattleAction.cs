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
	
	public readonly float Duration = 2.0f;
	public TTargetType TargetType;
	public abstract Color Color { get; }

	private BattleSlot_Monster FindTarget(BattleSlot_Monster source, int targetPosition)
	{
		switch (TargetType)
		{
			case TTargetType.Enemy: return source.ParentTeam.EnemyTeamSlot.MonsterSlots[targetPosition];
			case TTargetType.Friendly: return source.ParentTeam.MonsterSlots[targetPosition];
			default: throw UnsupportedEnumMemberException.GetGeneric(TargetType);
		}
	}

	public BattleActionInvocation Invoke(BattleSlot_Monster source, int targetPosition)
	{
		return Invoke(source, FindTarget(source, targetPosition));
	}

	protected abstract BattleActionInvocation Invoke(BattleSlot_Monster source, BattleSlot_Monster target);
}
