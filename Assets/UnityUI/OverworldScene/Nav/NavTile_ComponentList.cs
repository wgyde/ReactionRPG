using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NavTile_ComponentList : ComponentList<NavTile>
{
#pragma warning disable 649
	[SerializeField] Grid Grid;
#pragma warning restore 649

	public override void Refresh()
	{
		base.Refresh();
		foreach (var navTile in Elements)
		{
			navTile.SnapToCell();
			navTile.gameObject.name = $"{navTile.Position.x}_{navTile.Position.y}_{navTile.POI.Name}";
			navTile.transform.position = Grid.GetCellCenterWorld(navTile.Position.ToVector3Int());
			navTile.ResyncUI();
		}
	}
}