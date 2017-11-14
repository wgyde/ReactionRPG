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

	private Monster FindTarget(Monster self, int targetPosition)
	{
		switch (TargetType)
		{
			case TTargetType.Enemy: return self.ParentTeam.EnemyTeam.Monsters[targetPosition];
			case TTargetType.Friendly: return self.ParentTeam.Monsters[targetPosition];
			default: throw UnsupportedEnumMemberException.GetGeneric(TargetType);
		}
	}

	public BattleActionInvocation Invoke(Monster self, int targetPosition)
	{
		return Invoke(self, FindTarget(self, targetPosition));
	}

	protected abstract BattleActionInvocation Invoke(Monster self, Monster target);
}
