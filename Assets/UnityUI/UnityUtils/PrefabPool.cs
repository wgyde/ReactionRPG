using System;
using System.Collections.Generic;
using UnityEngine;

public class PrefabPool<T> : MonoBehaviour
where T : Component
{
#pragma warning disable 649
	[SerializeField] private T Prefab;
	[SerializeField] private int InitialSize = 10;
#pragma warning restore 649

	private Queue<T> Pool;

	public void Initialize()
	{
		Pool = new Queue<T>();
		Create(InitialSize);
	}

	private void Activate(T instance)
	{
		instance.gameObject.SetActive(true);
	}

	private void Deactivate(T instance)
	{
		instance.gameObject.SetActive(false);
	}

	public T Take()
	{
		if (Pool.Count == 0)
		{
			Debug.LogWarning($"Pool \"{this}\" is out of instances. Creating {10} more.");
			Create(10);
		}
		var instance = Pool.Dequeue();
		Activate(instance);
		return instance;
	}

	public void Give(T instance)
	{
		Deactivate(instance);
		Pool.Enqueue(instance);
	}

	private void Create(int count)
	{
		for (int i=0; i<count; ++i)
			Give(gameObject.InstantiateChild(Prefab));
	}
}