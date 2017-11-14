using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ComponentList<T> : MonoBehaviour
where T : MonoBehaviour
{
	public T[] Elements;

	public virtual void Refresh()
	{
		PopulateFromChildren();
	}

	protected void PopulateFromChildren()
	{
		Elements = new T[transform.childCount];
		for (int i = 0; i < transform.childCount; ++i)
		{
			GameObject child = transform.GetChild(i).gameObject;
			T element = child.GetComponent<T>();
			if (element == null)
				Debug.LogError($"child {child.name} does not have component {typeof(T).ToString()}");
			Elements[i] = element;
		}
	}
}
