using NSUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NavTileCrawler
{
	private Vector2Int PrevPosition = new Vector2Int(int.MaxValue, int.MaxValue);
	public ObservableValue<Vector2Int> Position { get; private set; } = new ObservableValue<Vector2Int>();
	public readonly NavGrid NavTilemap;

	public NavTile OccupiedTile => NavTilemap.GetTile(Position.Value);
	public Vector3 WorldPosition => NavTilemap.Grid.GetCellCenterWorld(Position.Value.ToVector3Int());

	public NavTileCrawler(NavGrid tilemap, Vector2Int startPosition)
	{
		NavTilemap = tilemap;
		if (!TryJumpTo(startPosition))
			throw new InvalidOperationException($"can't jump to NavTile at {startPosition}");
	}

	public Vector2Int GetAdjacentPosition(Direction4 d4) => Position.Value + d4.ToUnitVector2Int();
	public bool CanOccupy(Vector2Int newPosition) => NavTilemap.GetTile(newPosition) != null;
	public bool TryJumpTo(Vector2Int newPosition)
	{
		if (!CanOccupy(newPosition))
		{
			return false;
		}
		PrevPosition = Position.Value;
		Position.Value = newPosition;
		return true;
	}

	public bool FollowRandomNoBacktrack()
	{
		foreach(var d4 in EnumUtils.IterateEnum<Direction4>())
		{
			var adj = GetAdjacentPosition(d4);
			if (adj == PrevPosition) continue;
			if (TryJumpTo(adj)) return true;
		}
		return false;
	}
}
