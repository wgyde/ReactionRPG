using NSUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class UnityExtensions_float
{
	public static Vector2 ToNormalVector2(this float angleDeg)
	{
		return new Vector2(
			angleDeg.CosDeg(),
			angleDeg.SinDeg()
		);
	}
}
