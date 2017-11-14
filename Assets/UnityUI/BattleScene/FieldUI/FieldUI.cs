using System;
using System.Collections.Generic;
using UnityEngine;

public class FieldUI : MonoBehaviour
{
#pragma warning disable 649
	[SerializeField] public PrefabPool_Sprite SpritePool;
	[SerializeField] RectTransform FrameTransform;
	[SerializeField] FieldUI_BattleTeam[] BattleTeamUIs;
#pragma warning restore 649

	public BattleScene ParentBattleScene { get; private set; }
	private Rect Frame;

	#region GetUI
	public FieldUI_Monster GetUI(Monster monster) => BattleTeamUIs[monster.ParentTeam.Index].MonsterUIs[monster.Index];
	#endregion

	public void Initialize(BattleScene parentBattleScene)
	{
		ParentBattleScene = parentBattleScene;

		SpritePool.Initialize();
		
		for (int i=0; i<BattleTeamUIs.Length; ++i)
			BattleTeamUIs[i].Initialize(this, i);
	}

	public void ResyncUI()
	{
		for (int i = 0; i < BattleTeamUIs.Length; ++i)
			BattleTeamUIs[i].ResyncUI();
	}
}
