using NSUtils.NSFSM;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class POIUIPanel : MonoBehaviour, POI.Visitee
{
#pragma warning disable 649
	[SerializeField] POIUI BattleUI;
	void POI.Visitee.Visit(POI_Battle poi) => TransitionUI(BattleUI, poi);

	[SerializeField] POIUI CampsiteUI;
	void POI.Visitee.Visit(POI_Campsite poi) => TransitionUI(CampsiteUI, poi);

	[SerializeField] POIUI EmptyUI;
	void POI.Visitee.Visit(POI_Empty poi) => TransitionUI(EmptyUI, poi);

	[SerializeField] POIUI TownUI;
	void POI.Visitee.Visit(POI_Town poi) => TransitionUI(TownUI, poi);
#pragma warning restore 649

	public OverworldScene ParentScene { get; private set; }

	private FSM<POIUI> UIFSM;

	public void Initialize(OverworldScene parentScene)
	{
		ParentScene = parentScene;

		BattleUI.Initialize(this);
		CampsiteUI.Initialize(this);
		EmptyUI.Initialize(this);
		TownUI.Initialize(this);

		UIFSM = new FSM<POIUI>(EmptyUI);
		
		ParentScene.Avatar.NavCrawler.Position.OnValueChanged += OnTileChanged;
		OnTileChanged();

	}

	private void OnTileChanged()
	{
		var newTile = ParentScene.Avatar.NavCrawler.OccupiedTile;
		newTile.POI.Visit(this);
	}
	
	private void TransitionUI<T>(POIUI NewUI, T poi)
	{
		UIFSM.SetState(NewUI);
	}
}
