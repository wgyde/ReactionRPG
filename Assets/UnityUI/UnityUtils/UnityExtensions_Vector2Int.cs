using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class UnityExtensions_Vector2Int
{
	public static Vector3Int ToVector3Int(this Vector2Int v2i) => new Vector3Int(v2i.x, v2i.y, 0);
}
