using System.Collections.Generic;
using System.Linq;

public class POIUI_Campsite : GenericPOIUI<POI_Campsite>
{
	public override void OnEnter()
	{
		base.OnEnter();
		NavUI.SetNavType(POINavigationUI.TNavType.ChooseDirection);
	}
}
