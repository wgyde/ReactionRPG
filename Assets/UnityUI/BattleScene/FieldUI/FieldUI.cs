using System;
using System.Collections.Generic;
using UnityEngine;

public class FieldUI : MonoBehaviour
{
#pragma warning disable 649
	[SerializeField] FieldUI_BattleTeam[] BattleTeamUIs;
#pragma warning restore 649

	public BattleScene ParentBattleScene { get; private set; }
	private Rect Frame;

	#region GetUI
	public FieldUI_Monster GetUI(BattlingMonster monsterSlot) => BattleTeamUIs[monsterSlot.ParentBattlingTeam.Index].MonsterUIs[monsterSlot.Index];
	#endregion

	public void Initialize(BattleScene parentBattleScene)
	{
		ParentBattleScene = parentBattleScene;
		
		for (int i=0; i<BattleTeamUIs.Length; ++i)
			BattleTeamUIs[i].Initialize(this, i);
	}

	public void ResyncUI()
	{
		for (int i = 0; i < BattleTeamUIs.Length; ++i)
			BattleTeamUIs[i].ResyncUI();
	}
}
