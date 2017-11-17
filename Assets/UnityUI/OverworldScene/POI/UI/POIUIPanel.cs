using NSUtils.NSFSM;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class POIUIPanel : MonoBehaviour, POI.Visitee
{
#pragma warning disable 649
	[SerializeField] POIUI_Battle BattleUI;
	void POI.Visitee.Visit(POI_Battle poi) => TransitionUI(BattleUI, poi);

	[SerializeField] POIUI_Campsite CampsiteUI;
	void POI.Visitee.Visit(POI_Campsite poi) => TransitionUI(CampsiteUI, poi);

	[SerializeField] POIUI_Road EmptyUI;
	void POI.Visitee.Visit(POI_Road poi) => TransitionUI(EmptyUI, poi);

	[SerializeField] POIUI_Town TownUI;
	void POI.Visitee.Visit(POI_Town poi) => TransitionUI(TownUI, poi);

	[SerializeField] public POINavigationUI NavUI;
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
		
		NavUI.Initialize(this);

		UIFSM = new FSM<POIUI>(null);
		
		ParentScene.Avatar.NavCrawler.Position.OnValueChanged += OnTileChanged;
		OnTileChanged();

	}

	public void _Update()
	{
		UIFSM.CurrentState._Update();
		NavUI._Update();
	}

	private void OnTileChanged()
	{
		var newTile = ParentScene.Avatar.NavCrawler.OccupiedTile;
		newTile.POI.Visit(this);
	}
	
	private void TransitionUI<TPOI>(GenericPOIUI<TPOI> NewUI, TPOI poi)
	where TPOI : POI
	{
		UIFSM.SetState(null);
		NewUI.SetPOI(poi);
		UIFSM.SetState(NewUI);
	}
}
