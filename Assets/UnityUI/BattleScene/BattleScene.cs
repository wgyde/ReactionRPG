using System.Collections.Generic;
using UnityEngine;

public class BattleScene : MonoBehaviour
{
#pragma warning disable 649
	[SerializeField] public PrefabPool_Sprite SpritePool;
	[SerializeField] ControlUI ControlUI;
	[SerializeField] FieldUI FieldUI;
#pragma warning restore 649

	public Battle Battle { get; private set; }
	public bool WonBattle => Battle.WinnerØ == Battle.Allies;
	public bool RunningBattle { get; private set; }

	public void Initialize(MonsterTeam enemies)
	{
		Battle = new Battle(Player.Inst.Team, enemies);
		
		SpritePool.Initialize();
		ControlUI.Initialize(this);
		FieldUI.Initialize(this);

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
	}

	protected virtual void Update()
	{
		_Update();
		ResyncUI();
	}
}
