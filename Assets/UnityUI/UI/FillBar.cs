using NSUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FillBar : MonoBehaviour
{
#pragma warning disable 649
	[SerializeField] private Image Foreground;
	[SerializeField] private Text Text;
	[SerializeField] private string TextFormat;
#pragma warning restore 649

	public void Show(float cur, float max)
	{
		Foreground.fillAmount = cur / max;
		if (Text != null)
			Text.text = string.Format(TextFormat, cur.Floor(), max.Floor());
	}
}
