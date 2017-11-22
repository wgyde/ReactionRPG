using System;
using System.Collections.Generic;
using UnityEngine;

public class BattleScene : MonoBehaviour
{
#pragma warning disable 649
	[SerializeField] public PrefabPool_Sprite SpritePool;
	[SerializeField] public ControlUI ControlUI;
	[SerializeField] public FieldUI FieldUI;
#pragma warning restore 649

	[NonSerialized] public UI_HeadlessActionInvoker ActionInvokerUI;

	public Battle Battle { get; private set; }
	public bool WonBattle => Battle.WinnerØ == Battle.Allies;
	public bool RunningBattle { get; private set; }

	public void Initialize(MonsterTeam enemies)
	{
		Battle = new Battle(Player.Inst.Team, enemies);
		
		SpritePool.Initialize();
		ControlUI.Initialize(this);
		FieldUI.Initialize(this);
		ActionInvokerUI = new UI_HeadlessActionInvoker(this);

		RunningBattle = true;
	}
	
	private void _Update()
	{
		if (RunningBattle)
		{
			if (Battle.WinnerØ != null)
			{
				RunningBattle = false;
				SceneTransitioner.Inst.Transition(SceneCatalog.BattleSelectScene, () => {
					var controller = SceneCatalog.BattleSelectScene.Controller;
					controller.OnBattleFinish(WonBattle);
				});
			}
			else
			{
				Battle.Step(Time.deltaTime);
			}
		}
	}

	private void ResyncUI()
	{
		ControlUI.ResyncUI();
		FieldUI.ResyncUI();
		ActionInvokerUI.ResyncUI();
	}

	protected virtual void Update()
	{
		_Update();
		ResyncUI();
	}
}
