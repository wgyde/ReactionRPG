using System.Collections.Generic;
using UnityEngine;

public class Battle
{
	public readonly BattleTeam[] Teams;

	public Battle()
	{
		Teams = new BattleTeam[2];
		Teams[0] = new BattleTeam(this, 0);
		Teams[1] = new BattleTeam(this, 1);
	}

	public void Step(float dt)
	{
		Teams[0].Step(dt);
		Teams[1].Step(dt);
	}
}
