using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentLoadingScene : MonoBehaviour
{
#pragma warning disable 649
	public SpriteArray Sprites;
	[SerializeField] Image SceneFadout;
#pragma warning restore 649

	public static ContentLoadingScene Inst;

	protected virtual void Awake()
	{
		Inst = this;

		CatalogManager.LoadAll();
		PersistentData.Load();
		
		gameObject.SetActive(false);
		SceneTransitioner.Inst.Transition(SceneCatalog.BattleSelectScene);
	}

	protected virtual void OnDestroy()
	{
		Inst = null;
	}
}
