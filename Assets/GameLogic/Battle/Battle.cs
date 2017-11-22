using System;
using System.Collections.Generic;
using UnityEngine;

public class Battle
{
	private const int INDEX_ALLIES = 0;
	private const int INDEX_ENEMIES = 1;
	public readonly BattlingMonsterTeam[] BattlingTeamSlots;
	public readonly HeadlessBattleActionInvoker ActionInvoker;

	public BattlingMonsterTeam Allies => BattlingTeamSlots[INDEX_ALLIES];
	public BattlingMonsterTeam Enemies => BattlingTeamSlots[INDEX_ENEMIES];

	public BattlingMonsterTeam WinnerØ { get; private set; }

	public Battle(MonsterTeam allies, MonsterTeam enemies)
	{
		BattlingTeamSlots = new BattlingMonsterTeam[2];
		BattlingTeamSlots[INDEX_ALLIES] = new BattlingMonsterTeam(this, INDEX_ALLIES, allies);
		BattlingTeamSlots[INDEX_ENEMIES] = new BattlingMonsterTeam(this, INDEX_ENEMIES, enemies);

		ActionInvoker = new HeadlessBattleActionInvoker();
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

		ActionInvoker.Step(dt);

		BattlingTeamSlots[0].Step(dt);
		BattlingTeamSlots[1].Step(dt);
	}
}
