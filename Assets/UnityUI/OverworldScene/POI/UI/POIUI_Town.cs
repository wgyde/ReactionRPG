using System.Collections.Generic;
using System.Linq;

public class POIUI_Town : GenericPOIUI<POI_Town>
{
	public override void OnEnter()
	{
		base.OnEnter();
		NavUI.SetNavType(POINavigationUI.TNavType.ChooseDirection);
	}
}
