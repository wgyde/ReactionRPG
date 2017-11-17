using NSUtils.NSFSM;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class POIUI : MonoBehaviour, FSMState
{
	public POI CurrentPOI { get; protected set; }
	public POIUIPanel ParentPanel { get; private set; }
	public POINavigationUI NavUI => ParentPanel.NavUI;

	public void Initialize(POIUIPanel parentPanel)
	{
		ParentPanel = parentPanel;
		gameObject.SetActive(false);
	}

	public virtual void _Update() { }

	public virtual void OnEnter()
	{
		Assert.IsNotNull(CurrentPOI);
		gameObject.SetActive(true);
	}

	public virtual void OnExit()
	{
		gameObject.SetActive(false);
		CurrentPOI = null;
		NavUI.SetNavType(POINavigationUI.TNavType.None);
	}
}
