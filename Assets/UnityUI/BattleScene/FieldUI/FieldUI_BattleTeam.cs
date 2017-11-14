using System.Collections.Generic;
using UnityEngine;

public class FieldUI_BattleTeam : MonoBehaviour
{
	public FieldUI ParentFieldUI { get; private set; }
	public int Index { get; private set; }
	
	public BattleTeam BattleTeam => ParentFieldUI.ParentBattleScene.Battle.Teams[Index];

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
		for (int i=0; i<MonsterUIs.Length; ++i)
			MonsterUIs[i].ResyncUI();
	}
}
