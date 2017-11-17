using System.Collections.Generic;
using System.Linq;

public class BattleSlot_Monster
{
	public readonly BattleSlot_MonsterTeam ParentTeam;
	public readonly int Index;

	public BattleActionInvocation CurrentInvocationØ { get; private set; }
	public bool Invoking => CurrentInvocationØ != null;
	public Monster Monster => ParentTeam.Team.Monsters[Index];

	public BattleSlot_Monster(BattleSlot_MonsterTeam parentTeam, int index)
	{
		ParentTeam = parentTeam;
		Index = index;
	}

	public void InvokeAction(BattleAction action, int targetPosition)
	{
		if (Invoking) return;
		CurrentInvocationØ = action.Invoke(this, targetPosition);
	}

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
}
