using System.Collections.Generic;
using UnityEngine;

public abstract class Catalog<TKey, TValue>
{

	private bool Initialized = false;
	protected Dictionary<TKey, TValue> Assets;

	public TValue this[TKey key]
	{
		get
		{
			if (!Assets.ContainsKey(key))
			{
				Debug.LogError($"Catalog {this} does not contain an entry for key {key}");
				return default(TValue);
			}
			return Assets[key];
		}
		protected set
		{
			Assets[key] = value;
		}
	}

	public void OfferLoad()
	{
		if (Initialized) return;
		Assets = new Dictionary<TKey, TValue>();
		Load();
		Initialized = true;
	}

	protected abstract void Load();
}
