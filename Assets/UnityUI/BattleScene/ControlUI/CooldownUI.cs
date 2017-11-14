using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownUI : MonoBehaviour
{
#pragma warning disable 649
	[SerializeField] Image Fader;
	[SerializeField] Image Wipe;
#pragma warning restore 649

	public ControlUI_Monster ParentMonsterUI { get; private set; }

	public Monster Monster => ParentMonsterUI.Monster;

	public void Initialize(ControlUI_Monster parentMonsterUI)
	{
		ParentMonsterUI = parentMonsterUI;
	}

	public void ResyncUI()
	{
		if (Monster.Invoking)
		{
			Fader.gameObject.SetActive(true);
			Wipe.fillAmount = 1.0f - Monster.CurrentInvocationØ.NormalizedProgress;
		}
		else
		{
			Fader.gameObject.SetActive(false);
			Wipe.fillAmount = 0.0f;
		}
	}
}
