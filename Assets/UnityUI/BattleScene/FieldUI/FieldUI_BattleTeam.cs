using System.Collections.Generic;
using UnityEngine;

public class FieldUI_BattleTeam : MonoBehaviour
{
#pragma warning disable 649
	[SerializeField] FillBar SPBar;
#pragma warning disable 649

	public FieldUI ParentFieldUI { get; private set; }
	public int Index { get; private set; }
	
	public BattlingMonsterTeam BattlingMonsterTeam => ParentFieldUI.ParentBattleScene.Battle.BattlingTeamSlots[Index];

	public FieldUI_Monster[] MonsterUIs;

	public void Initialize(FieldUI parentFieldUI, int index)
	{
		ParentFieldUI = parentFieldUI;
		Index = index;
		
		for (int i=0; i<MonsterUIs.Length; ++i)
			MonsterUIs[i].Initialize(this, i);
	}

	public void ResyncUI()
	{
		SPBar.Show(BattlingMonsterTeam.SPCur, BattlingMonsterTeam.SPMax);
		for (int i=0; i<MonsterUIs.Length; ++i)
			MonsterUIs[i].ResyncUI();
	}
}
