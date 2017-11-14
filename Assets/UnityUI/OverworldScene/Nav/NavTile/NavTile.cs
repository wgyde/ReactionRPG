using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NavTile : MonoBehaviour
{
#pragma warning disable 649
	[SerializeField] SpriteRenderer SpriteRenderer;
	[SerializeField] public POI POI;
	[SerializeField] public Vector2Int Position;
#pragma warning restore 649

	public NavGrid ParentTilemap { get; private set; }

	public void Initialize(NavGrid parentTilemap)
	{
		ParentTilemap = parentTilemap;
		ResyncUI();
	}

	public void SnapToCell()
	{
		var Grid = GetComponentInParent<Grid>();
		if (Grid == null)
		{
			Debug.LogError("Can't find a grid in parent");
		}
		else
		{
			Vector3Int cellPosition = Grid.WorldToCell(transform.position);
			Position = cellPosition.ToVector2Int();
			transform.position = Grid.GetCellCenterWorld(cellPosition);
		}
	}

	public void ResyncUI()
	{
		SpriteRenderer.sprite = POI.Sprite;
		SpriteRenderer.color = POI.Color;
	}
}
