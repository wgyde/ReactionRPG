using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PrefabPool_Sprite : PrefabPool<SpriteRenderer>
{
	public static PrefabPool_Sprite Inst;

	public override void Initialize()
	{
		base.Initialize();
		Assert.IsNull(Inst);
		Inst = this;
	}

	protected virtual void OnDestroy()
	{
		Assert.AreEqual(this, Inst);
		Inst = null;
	}
}