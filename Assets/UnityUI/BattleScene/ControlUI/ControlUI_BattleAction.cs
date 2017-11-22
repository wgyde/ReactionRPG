using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlUI_BattleAction : MonoBehaviour
{
#pragma warning disable 649
	[SerializeField] Image Image;
	[SerializeField] KeyCode Key;
	[SerializeField] CooldownUI CooldownUI;
#pragma warning restore 649

	public ControlUI_Monster ParentMonsterUI { get; private set; }
	public int Index { get; private set; }

	public BattleAction Action => ParentMonsterUI.MonsterSlot.Monster.Actions[Index];
	
	public void Initialize(ControlUI_Monster parentMonsterUI, int index)
	{
		ParentMonsterUI = parentMonsterUI;
		Index = index;

		Image.color = Action.Color;

		CooldownUI.Initialize(this);
	}

	public void ResyncUI()
	{
		if (Input.GetKey(Key))
		{
			ParentMonsterUI.MonsterSlot.InvokeAction(Action, ParentMonsterUI.ParentControlUI.FindTargetPosition());
		}
		CooldownUI.ResyncUI();
	}
}
