using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class UnityExtensions_Color
{
	public static Color WithAlpha(this Color c, float a) => new Color(c.r, c.g, c.b, a);
}
