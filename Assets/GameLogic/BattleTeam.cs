using System.Collections.Generic;
using UnityEngine;

public class BattleTeam
{
	public const int TEAM_SIZE = 3;

	public readonly Battle ParentBattle;
	public readonly int Index;

	public readonly Monster[] Monsters;

	public BattleTeam EnemyTeam => ParentBattle.Teams[1 - Index];

	public BattleTeam(Battle parentBattle, int index)
	{
		ParentBattle = parentBattle;
		Index = index;

		Monsters = new Monster[TEAM_SIZE];
		for (int i=0; i<Monsters.Length; ++i)
			Monsters[i] = new Monster(this, i);
	}

	public void Step(float dt)
	{
		foreach (var monster in Monsters)
		{
			monster.Step(dt);
		}
	}
}
