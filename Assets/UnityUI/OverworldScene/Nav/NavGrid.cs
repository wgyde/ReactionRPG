using NSUtils;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Tilemaps;

public class NavGrid : MonoBehaviour
{
#pragma warning disable 649
	public NavTile_ComponentList TileList;
	public Grid Grid;
#pragma warning restore 649
	
	public OverworldScene ParentScene { get; private set; }

	public static readonly Vector2Int Bounds = new Vector2Int(13, 11);
	private NavTile[,] TileGrid;

	public bool IsInBounds(Vector2Int pos) => 
		pos.x.IsBetween(0, Bounds.x)
		&& pos.y.IsBetween(0, Bounds.y)
	;

	public NavTile GetTile(Vector2Int pos) => TileGrid[pos.x, pos.y];
	private void SetTile(Vector2Int pos, NavTile value) => TileGrid[pos.x, pos.y] = value;

	private void PopulateTileGrid()
	{
		TileGrid = new NavTile[Bounds.x, Bounds.y];
		foreach (var tile in TileList.Elements)
		{
			if (GetTile(tile.Position) != null)
			{
				Debug.LogError($"There are two tiles at position {tile.Position}");
				continue;
			}

			SetTile(tile.Position, tile);
		}
	}

	public void Initialize(OverworldScene parentScene)
	{
		ParentScene = parentScene;
		PopulateTileGrid();
	}
}
