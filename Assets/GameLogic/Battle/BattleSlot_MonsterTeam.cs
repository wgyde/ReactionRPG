using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleSlot_MonsterTeam
{
	public readonly Battle ParentBattle;
	public readonly int Index;
	
	public readonly MonsterTeam Team;

	public BattleSlot_MonsterTeam EnemyTeamSlot => ParentBattle.TeamSlots[1 - Index];
	public readonly BattleSlot_Monster[] MonsterSlots;

	public BattleSlot_MonsterTeam(Battle parentBattle, int index, MonsterTeam team)
	{
		ParentBattle = parentBattle;
		Index = index;
		Team = team;

		MonsterSlots = new BattleSlot_Monster[Team.Monsters.Length];
		for (int i=0; i<MonsterSlots.Length; ++i)
			MonsterSlots[i] = new BattleSlot_Monster(this, i);
	}

	public bool IsOutOfContention() => MonsterSlots.All(el => el.Monster.IsDead);

	public void Step(float dt)
	{
		foreach (var monsterSlot in MonsterSlots)
		{
			monsterSlot.Step(dt);
		}
	}
}
