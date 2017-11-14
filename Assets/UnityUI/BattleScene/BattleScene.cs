using System.Collections.Generic;
using UnityEngine;

public class BattleScene : MonoBehaviour
{
#pragma warning disable 649
	[SerializeField] ControlUI ControlUI;
	[SerializeField] FieldUI FieldUI;
#pragma warning restore 649

	public const int FRIENDLY_TEAM = 0;
	public const int ENEMY_TEAM = 1;

	public Battle Battle { get; private set; }

	private void Initialize()
	{
		Battle = new Battle();

		Battle.Teams[FRIENDLY_TEAM].Monsters[2].Actions[0] = new BattleAction_Status(MonsterStatus.Inst_Frail) { TargetType = BattleAction.TTargetType.Enemy };
		Battle.Teams[FRIENDLY_TEAM].Monsters[2].Actions[1] = new BattleAction_Status(MonsterStatus.Inst_Inspired) { TargetType = BattleAction.TTargetType.Friendly };

		ControlUI.Initialize(this);
		FieldUI.Initialize(this);
	}
	
	private void ResyncUI()
	{
		
		ControlUI.ResyncUI();
		FieldUI.ResyncUI();
	}

	protected virtual void Awake()
	{
		Initialize();
	}

	protected virtual void Update()
	{
		Battle.Step(Time.deltaTime);
		ResyncUI();
	}
}
