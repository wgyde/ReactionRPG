using System.Collections.Generic;
using UnityEngine;

public class BattleScene : MonoBehaviour
{
#pragma warning disable 649
	[SerializeField] ControlUI ControlUI;
	[SerializeField] FieldUI FieldUI;
#pragma warning restore 649

	public Battle Battle { get; private set; }

	public void Initialize(MonsterTeam enemies)
	{
		Battle = new Battle(Player.Inst.Team, enemies);

		ControlUI.Initialize(this);
		FieldUI.Initialize(this);
	}
	
	private void ResyncUI()
	{
		
		ControlUI.ResyncUI();
		FieldUI.ResyncUI();
	}

	protected virtual void Update()
	{
		if (Battle.WinnerØ == null)
		{
			Battle.Step(Time.deltaTime);
		}
		else
		{
			SceneCatalog.BattleSelectScene.Load((bss) => {
				bss.OnBattleFinish(Battle.WinnerØ == Battle.Allies);
			});
		}
		ResyncUI();
	}
}
