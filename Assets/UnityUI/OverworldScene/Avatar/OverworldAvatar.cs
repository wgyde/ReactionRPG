using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OverworldAvatar : MonoBehaviour
{
#pragma warning disable 649
	[SerializeField] Vector2Int StartingPosition;
#pragma warning restore 649

	public OverworldScene ParentScene { get; private set; }
	public NavTileCrawler NavCrawler { get; private set; }

	public void Initialize(OverworldScene parentScene)
	{
		ParentScene = parentScene;
		NavCrawler = new NavTileCrawler(parentScene.NavTilemap, StartingPosition);
	}

	private bool TryMove(KeyCode key, Direction4 dir)
	{
		if (!Input.GetKeyDown(key))
			return false;

		NavCrawler.TryJumpTo(NavCrawler.Position.Value + dir.ToUnitVector2Int());
		return true;
	}

	protected virtual void Update()
	{
		transform.position = NavCrawler.WorldPosition;

		if (TryMove(KeyCode.UpArrow, Direction4.N)) { }
		else if (TryMove(KeyCode.DownArrow, Direction4.S)) { }
		else if (TryMove(KeyCode.RightArrow, Direction4.E)) { }
		else if (TryMove(KeyCode.LeftArrow, Direction4.W)) { }
		else if (Input.GetKeyDown(KeyCode.Space)) { NavCrawler.FollowRandomNoBacktrack(); }
	}
}
