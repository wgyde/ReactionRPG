using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class OverworldScene : MonoBehaviour
{
#pragma warning disable 649
	public NavGrid NavTilemap;
	public OverworldAvatar Avatar;
	public POIUIPanel POIUIPanel;
#pragma warning restore 649

	private void Initialize()
	{
		NavTilemap.Initialize(this);
		Avatar.Initialize(this);
		POIUIPanel.Initialize(this);
	}

	private void _Update()
	{
		Avatar._Update();
		POIUIPanel._Update();
	}

	protected virtual void Awake()
	{
		Initialize();
	}

	protected virtual void Update()
	{
		_Update();
	}
}
