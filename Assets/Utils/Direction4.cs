using NSUtils.Exceptions;
using System.Collections.Generic;
using UnityEngine;

public enum Direction4
{
	N,
	S,
	E,
	W
}

public static class Direction4Extensions
{
	public static Direction4 GetOpposite(this Direction4 d4)
	{
		switch (d4)
		{
			case Direction4.N: return Direction4.S;
			case Direction4.S: return Direction4.N;
			case Direction4.E: return Direction4.W;
			case Direction4.W: return Direction4.E;
			default: throw UnsupportedEnumMemberException.GetGeneric(d4);
		}
	}
}