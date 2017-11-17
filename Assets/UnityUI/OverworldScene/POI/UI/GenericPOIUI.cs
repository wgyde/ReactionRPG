using System.Collections.Generic;
using System.Linq;

public class GenericPOIUI<TPOI> : POIUI
where TPOI : POI
{
	public new TPOI CurrentPOI => (TPOI)base.CurrentPOI;
	public void SetPOI(TPOI value) => base.CurrentPOI = value;
}
