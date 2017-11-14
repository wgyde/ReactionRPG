using NSUtils.NSFSM;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class POIUI : MonoBehaviour, FSMState
{
	public POIUIPanel ParentPanel { get; private set; }

	public void Initialize(POIUIPanel parentPanel)
	{
		ParentPanel = parentPanel;
		gameObject.SetActive(false);
	}

	public void OnEnter()
	{
		gameObject.SetActive(true);
	}

	public void OnExit()
	{
		gameObject.SetActive(false);
	}
}
