using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class POIUI_Battle : GenericPOIUI<POI_Battle>
{
	public override void OnEnter()
	{
		base.OnEnter();
		NavUI.SetNavType(POINavigationUI.TNavType.Blocked);
	}

	public override void _Update()
	{
		base._Update();
		if (Input.GetKeyDown(KeyCode.Q))
			NavUI.SetNavType(POINavigationUI.TNavType.FollowPath);
	}
}
