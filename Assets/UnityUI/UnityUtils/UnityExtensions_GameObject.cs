using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class UnityExtensions_GameObject
{
	public static T InstantiateChild<T>(this GameObject parent, T prefab)
	where T : Component
	{
		var child = GameObject.Instantiate(prefab.gameObject);
		child.transform.SetParent(parent.transform);
		child.transform.localScale = prefab.transform.localScale;
		return child.GetComponent<T>();
	}
}
