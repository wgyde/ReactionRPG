using System.Collections.Generic;
using UnityEngine;

public class ControlUI : MonoBehaviour
{
#pragma warning disable 649
	[SerializeField] ControlUI_Monster[] Monsters;
#pragma warning restore 649

	public BattleScene ParentBattleScene { get; private set; }
	public int Index { get; private set; }

	public BattleTeam BattleTeam => ParentBattleScene.Battle.Teams[BattleScene.FRIENDLY_TEAM];

	public int FindTargetPosition()
	{
		return 
			Input.GetKey(KeyCode.UpArrow) ? 0 :
			Input.GetKey(KeyCode.DownArrow) ? 2 :
			1
		;
	}

	public void Initialize(BattleScene parentBattleScene)
	{
		ParentBattleScene = parentBattleScene;

		for (int i = 0; i < Monsters.Length; ++i)
		{
			Monsters[i].Initialize(this, i);
		}
	}

	public void ResyncUI()
	{
		for (int i=0; i<Monsters.Length; ++i)
		{
			Monsters[i].ResyncUI();
		}
	}
}
