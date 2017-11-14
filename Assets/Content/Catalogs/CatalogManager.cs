using System.Collections.Generic;
using UnityEngine;

public static class CatalogManager
{
	public static void LoadAll()
	{
		SpriteCatalog.Catalog.Inst.OfferLoad();
	}
}
