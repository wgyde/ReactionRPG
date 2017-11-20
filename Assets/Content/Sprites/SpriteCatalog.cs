using System;
using System.Collections.Generic;
using UnityEngine;

public class SpriteCatalog
{
	public enum ID
	{
		BoxMonster_Outline,
		BoxMonster_Fill,
		BoxProjectile_Outline,
		BoxProjectile_Fill
	}

	public class Catalog : Catalog<ID, Sprite>
	{
		public static Catalog Inst = new Catalog();

		protected override void Load()
		{
			var sprites = ContentLoadingScene.Inst.Sprites;

			ID key;
			foreach (var sprite in sprites.Values)
			{
				if (Enum.TryParse(sprite.name, out key))
					this[key] = sprite;
				else
					Debug.LogError($"Could not find a key for \"{sprite.name}\"");
			}
		}
	}
}

public static class SpriteCatalogIDExtensions
{
	public static Sprite GetAsset(this SpriteCatalog.ID id) => SpriteCatalog.Catalog.Inst[id];
}