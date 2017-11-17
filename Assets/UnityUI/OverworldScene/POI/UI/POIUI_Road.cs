using System.Collections.Generic;
using System.Linq;

public class POIUI_Road : GenericPOIUI<POI_Road>
{
	public override void OnEnter()
	{
		base.OnEnter();
		NavUI.SetNavType(POINavigationUI.TNavType.FollowPath);
	}
}
