using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownUI : MonoBehaviour
{
#pragma warning disable 649
	[SerializeField] Image Fader;
	[SerializeField] Image Wipe;
#pragma warning restore 649

	public ControlUI_BattleAction ParentActionUI { get; private set; }

	private BattlingMonsterTeam BattlingTeam => ParentActionUI.ParentMonsterUI.ParentControlUI.BattlingTeam;

	public void Initialize(ControlUI_BattleAction parentActionUI)
	{
		ParentActionUI = parentActionUI;
	}

	public void ResyncUI()
	{
		if (BattlingTeam.ActionCooldownActivated)
		{
			Fader.gameObject.SetActive(true);
			Wipe.fillAmount = BattlingTeam.ActionCooldownCur / BattlingTeam.ActionCooldownMax;
		}
		else
		{
			Fader.gameObject.SetActive(false);
			Wipe.fillAmount = 0.0f;
		}
	}
}
