using NSUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class floatExtensions
{
	public static Vector2 ToNormalVector2(this float degrees)
	{
		return new Vector2(
			degrees.CosDeg(),
			degrees.SinDeg()
		);
	}
}
