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

	private class TInnerPool : Pool<T>
	{
		PrefabPool<T> ParentPool;

		public TInnerPool(PrefabPool<T> parentPool)
		{
			ParentPool = parentPool;
		}

		protected override T Create() => ParentPool.gameObject.InstantiateChild(ParentPool.Prefab);
		protected override void Activate(T el) => el.gameObject.SetActive(true);
		protected override void Deactivate(T el) => el.gameObject.SetActive(false);
	}
	private TInnerPool InnerPool;
	private Queue<T> Pool;

	public virtual void Initialize()
	{
		InnerPool = new TInnerPool(this);
		InnerPool.Create(InitialSize);
	}

	public T Take() => InnerPool.Take();
	public void Give(T el) => InnerPool.Give(el);
}