using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class UnityExtensions_Vector3Int
{
	public static Vector2Int ToVector2Int(this Vector3Int v3i) => new Vector2Int(v3i.x, v3i.y);
}
