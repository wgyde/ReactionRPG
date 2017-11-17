using NSUtils.Exceptions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class POINavigationUI : MonoBehaviour
{
#pragma warning disable 649
	[SerializeField] Text Text;
#pragma warning restore 649

	public enum TNavType
	{
		None,
		Blocked,
		ChooseDirection,
		FollowPath
	}
	public TNavType NavType { get; private set; }

	public POIUIPanel ParentPanel { get; private set; }
	private OverworldAvatar Avatar => ParentPanel.ParentScene.Avatar;

	private bool TryNavigate(KeyCode key, Direction4 dir)
	{
		if (!Input.GetKeyDown(key))
			return false;

		Avatar.NavCrawler.TryJumpTo(Avatar.NavCrawler.Position.Value + dir.ToUnitVector2Int());
		return true;
	}

	private void HandleNavigationInput()
	{
		switch (NavType)
		{
			case TNavType.None:
				break;
			case TNavType.Blocked:
				break;
			case TNavType.ChooseDirection:
				if (TryNavigate(KeyCode.UpArrow, Direction4.N)) { }
				else if (TryNavigate(KeyCode.DownArrow, Direction4.S)) { }
				else if (TryNavigate(KeyCode.RightArrow, Direction4.E)) { }
				else if (TryNavigate(KeyCode.LeftArrow, Direction4.W)) { }
				break;
			case TNavType.FollowPath:
				if (Input.GetKeyDown(KeyCode.Space)) { Avatar.NavCrawler.FollowRandomNoBacktrack(); }
				break;
			default: throw UnsupportedEnumMemberException.GetGeneric(NavType);
		}
	}

	private void UpdateVisuals()
	{
		switch (NavType)
		{
			case TNavType.None: Text.text = "..."; break;
			case TNavType.Blocked: Text.text = "Movement Blocked"; break;
			case TNavType.ChooseDirection: Text.text = "Use Arrows to Move"; break;
			case TNavType.FollowPath: Text.text = "Press Space to Move"; break;
			default: throw UnsupportedEnumMemberException.GetGeneric(NavType);
		}
	}

	public void SetNavType(TNavType navType)
	{
		NavType = navType;
		UpdateVisuals();
	}

	public void Initialize(POIUIPanel parentPanel)
	{
		ParentPanel = parentPanel;
	}

	public void _Update()
	{
		HandleNavigationInput();
	}
}
