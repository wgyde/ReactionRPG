using System.Collections.Generic;
using UnityEngine;

public class MonsterStatus
{
	#region instances
	public static MonsterStatus Inst_NoStatus = new MonsterStatus(new Color(0.0f, 0.0f, 0.0f, 0.0f));
	#endregion

	public readonly Color Color;

	private MonsterStatus(Color color)
	{
		Color = color;
	}
}
