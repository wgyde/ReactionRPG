using System.Collections.Generic;
using UnityEngine;

public class ControlUI_Monster : MonoBehaviour
{
#pragma warning disable 649
	[SerializeField] ControlUI_BattleAction[] ControlUIs;
#pragma warning restore 649

	public ControlUI ParentControlUI { get; private set; }
	public int Index { get; private set; }

	public BattlingMonster MonsterSlot => ParentControlUI.BattlingTeam.BattlingMonsters[Index];

	public void Initialize(ControlUI parentControlUI, int index)
	{
		ParentControlUI = parentControlUI;
		Index = index;

		for (int i=0; i<ControlUIs.Length; ++i)
			ControlUIs[i].Initialize(this, i);
	}

	public void ResyncUI()
	{
		foreach (var controlUI in ControlUIs)
			controlUI.ResyncUI();
	}
}
