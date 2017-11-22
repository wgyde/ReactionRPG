using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattlingMonsterTeam
{
	public readonly Battle ParentBattle;
	public readonly int Index;
	
	public readonly MonsterTeam Team;

	public BattlingMonsterTeam EnemyTeamSlot => ParentBattle.BattlingTeamSlots[1 - Index];
	public readonly BattlingMonster[] BattlingMonsters;

	#region sp
	public readonly float SPMax = 15.0f;
	private float _SPCur;
	public float SPCur
	{
		get { return _SPCur; }
		set { _SPCur = value.Clamp(0.0f, SPMax); }
	}
	#endregion
	#region action cooldown
	public readonly float ActionCooldownMax = 0.5f;
	public float ActionCooldownCur { get; private set; }
	public bool ActionCooldownActivated => ActionCooldownCur > 0.0f;
	public void ActivateCooldown() => ActionCooldownCur = ActionCooldownMax;
	#endregion

	public BattlingMonsterTeam(Battle parentBattle, int index, MonsterTeam team)
	{
		ParentBattle = parentBattle;
		Index = index;
		Team = team;
		SPCur = SPMax;
		ActionCooldownCur = 0.0f;

		BattlingMonsters = new BattlingMonster[Team.Monsters.Length];
		for (int i=0; i<BattlingMonsters.Length; ++i)
			BattlingMonsters[i] = new BattlingMonster(this, i);
	}

	public bool IsOutOfContention() => SPCur == 0.0f;

	public bool TryConsumeSP(float sp)
	{
		if (SPCur < sp) return false;

		SPCur -= sp;
		return true;
	}

	public void Step(float dt)
	{
		ActionCooldownCur -= dt;

		foreach (var monsterSlot in BattlingMonsters)
		{
			monsterSlot.Step(dt);
		}
	}
}
