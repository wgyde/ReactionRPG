using System;
using System.Collections.Generic;
using UnityEngine;

public class Battle
{
	private const int INDEX_ALLIES = 0;
	private const int INDEX_ENEMIES = 1;
	public readonly BattleSlot_MonsterTeam[] TeamSlots;
	public BattleSlot_MonsterTeam Allies => TeamSlots[INDEX_ALLIES];
	public BattleSlot_MonsterTeam Enemies => TeamSlots[INDEX_ENEMIES];

	public BattleSlot_MonsterTeam WinnerØ { get; private set; }

	public Battle(MonsterTeam allies, MonsterTeam enemies)
	{
		TeamSlots = new BattleSlot_MonsterTeam[2];
		TeamSlots[INDEX_ALLIES] = new BattleSlot_MonsterTeam(this, INDEX_ALLIES, allies);
		TeamSlots[INDEX_ENEMIES] = new BattleSlot_MonsterTeam(this, INDEX_ENEMIES, enemies);
	}
	
	private void TryFindWinner()
	{
		if (Enemies.IsOutOfContention()) WinnerØ = Allies;
		if (Allies.IsOutOfContention()) WinnerØ = Enemies;
	}

	public void Step(float dt)
	{
		TryFindWinner();

		if (WinnerØ != null)
		{
			return;
		}

		TeamSlots[0].Step(dt);
		TeamSlots[1].Step(dt);
	}
}
