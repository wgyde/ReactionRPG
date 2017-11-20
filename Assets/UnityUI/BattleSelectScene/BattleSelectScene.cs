using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BattleSelectScene : MonoBehaviour
{
#pragma warning disable 649
	[SerializeField] Text Text;
#pragma warning restore 649

	private int BattleCount { get { return PersistentData.Inst.BattleCount; } set { PersistentData.Inst.BattleCount = value; } } 
	private int WinCount { get { return PersistentData.Inst.WinCount; } set {PersistentData.Inst.WinCount = value; } }

	private class BattleListElement
	{
		public string Name;
		public Func<MonsterTeam> CreateEnemyTeam;
	}
	List<BattleListElement> BattleListElements = new List<BattleListElement>();

	public void OnBattleFinish(bool win)
	{
		BattleCount += 1;
		WinCount += win ? 1 : 0;
		UpdateVisuals();
	}

	private void Initialize()
	{
		CreateBattleListElements();
		UpdateVisuals();
	}

	private void CreateBattleListElements()
	{
		BattleListElement el;

		el = new BattleListElement();
		el.Name = "Test Battle";
		el.CreateEnemyTeam = () => {
			var team = new MonsterTeam();
			team.Monsters[0].HPCur = 1;
			return team;
		};
		BattleListElements.Add(el);
	}

	private void UpdateVisuals()
	{
		Text.text = "";
		Text.text += $"Won {WinCount} / {BattleCount}\n";
		for (int i=0; i<BattleListElements.Count; ++i)
		{
			var el = BattleListElements[i];
			Text.text += $"{i}. {el.Name}\n";
		}
	}

	private void _Update()
	{
		for (int i=0; i<BattleListElements.Count; ++i)
		{
			if (Input.GetKeyDown(i.ToString()))
			{
				int closure_i = i;
				SceneTransitioner.Inst.Transition(SceneCatalog.BattleScene, () => {
					var controller = SceneCatalog.BattleScene.Controller;
					controller.Initialize(BattleListElements[closure_i].CreateEnemyTeam());
				});
			}
		}
	}

	protected virtual void Start()
	{
		Initialize();
	}

	protected virtual void Update()
	{
		_Update();
	}
}
