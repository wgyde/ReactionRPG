using System.Collections.Generic;
using UnityEngine;

public class MonsterStatus
{
	#region instances
	public static MonsterStatus Inst_NoStatus = new MonsterStatus(new Color(0.0f, 0.0f, 0.0f, 0.0f));
	public static MonsterStatus Inst_Frail = new MonsterStatus(new Color(1.0f, 0.0f, 1.0f, 1.0f));
	public static MonsterStatus Inst_Inspired = new MonsterStatus(new Color(1.0f, 1.0f, 0.0f, 1.0f));
	#endregion

	public readonly Color Color;

	private MonsterStatus(Color color)
	{
		Color = color;
	}
}
