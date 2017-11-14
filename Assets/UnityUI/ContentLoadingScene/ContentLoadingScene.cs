using System.Collections.Generic;
using UnityEngine;

public class ContentLoadingScene : MonoBehaviour
{
#pragma warning disable 649
	public SpriteArray Sprites;
#pragma warning restore 649

	public static ContentLoadingScene InstØ;

	protected virtual void Awake()
	{
		InstØ = this;
		CatalogManager.LoadAll();
		SceneCatalog.BattleScene.Load();
	}
}
