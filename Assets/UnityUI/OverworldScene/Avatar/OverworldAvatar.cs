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

	public void _Update()
	{
		transform.position = NavCrawler.WorldPosition;
	}
}
