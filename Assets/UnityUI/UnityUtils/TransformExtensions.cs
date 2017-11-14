using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensions
{
	public static void SetLossyScale(this Transform transform, Vector3 scale)
	{
		if (transform.parent == null)
			transform.localScale = scale;
		else
			transform.localScale = new Vector3(
				scale.x / transform.parent.lossyScale.x,
				scale.y / transform.parent.lossyScale.y,
				scale.z / transform.parent.lossyScale.z
			);
	}
}
