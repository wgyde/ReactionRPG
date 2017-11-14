using NSUtils.Exceptions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class UnityExtensions_Direction4
{
	public static Vector2Int ToUnitVector2Int(this Direction4 d4)
	{
		switch (d4)
		{
			case Direction4.N: return new Vector2Int( 0, 1);
			case Direction4.S: return new Vector2Int( 0,-1);
			case Direction4.E: return new Vector2Int( 1, 0);
			case Direction4.W: return new Vector2Int(-1, 0);
			default: throw UnsupportedEnumMemberException.GetGeneric(d4);
		}
	}
}
