using NSUtils.Exceptions;
using System.Collections.Generic;

public enum Direction2
{
	L,
	R
}

public static class Direction2Extensions
{
	public static Direction2 GetOpposite(this Direction2 d2)
	{
		switch (d2)
		{
			case Direction2.L: return Direction2.R;
			case Direction2.R: return Direction2.L;
			default: throw UnsupportedEnumMemberException.GetGeneric(d2);
		}
	}
}
