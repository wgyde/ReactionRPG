using NSUtils.Exceptions;
using System.Collections.Generic;
using UnityEngine;

public class FieldUI_Monster : MonoBehaviour
{
#pragma warning disable 649
	[SerializeField] FillBar HPBar;
#pragma warning restore 649

	public FieldUI_BattleTeam ParentBattleTeamUI { get; private set; }
	public int Index { get; private set; }
	public Rect Frame { get; private set; }

	public FieldUI FieldUI => ParentBattleTeamUI.ParentFieldUI;
	public BattleSlot_Monster MonsterSlot => ParentBattleTeamUI.BattleTeam.MonsterSlots[Index];
	public Monster Monster => MonsterSlot.Monster;

	private SpriteRenderer MonsterRenderer;
	private SpriteRenderer MonsterStatusRenderer;

	private SpriteRenderer ProjectileØ;
	private bool Invoking => ProjectileØ != null;

	public void Initialize(FieldUI_BattleTeam parentBattleTeamUI, int index)
	{
		ParentBattleTeamUI = parentBattleTeamUI;
		Index = index;

		Frame = GetComponent<RectTransform>().GetWorldRect();

		#region place monster sprite
		MonsterRenderer = FieldUI.SpritePool.Take();
		MonsterRenderer.sprite = SpriteCatalog.ID.BoxMonster_Fill.GetAsset();
		MonsterRenderer.transform.position = new Vector3(Frame.center.x, Frame.center.y, 0.0f);
		MonsterRenderer.color = new Color(0.4f, 0.6f, 0.6f, 1.0f);

		MonsterStatusRenderer = FieldUI.SpritePool.Take();
		MonsterStatusRenderer.sprite = SpriteCatalog.ID.BoxMonster_Outline.GetAsset();
		MonsterStatusRenderer.transform.position = new Vector3(Frame.center.x, Frame.center.y, 0.0f);
		#endregion
	}

	private void ResyncActionInvocationUI()
	{
		if (Invoking && !MonsterSlot.Invoking)
		{
			FieldUI.SpritePool.Give(ProjectileØ);
			ProjectileØ = null;
		}
		else if (!Invoking && MonsterSlot.Invoking)
		{
			ProjectileØ = FieldUI.SpritePool.Take();
			ProjectileØ.sprite = SpriteCatalog.ID.BoxProjectile_Fill.GetAsset();
			ProjectileØ.color = MonsterSlot.CurrentInvocationØ.Action.Color;
		}

		if (Invoking)
		{
			Vector3 startLocation = FieldUI.GetUI(MonsterSlot.CurrentInvocationØ.Source).Frame.center;
			Vector3 endLocation = FieldUI.GetUI(MonsterSlot.CurrentInvocationØ.Target).Frame.center;
			ProjectileØ.transform.position = Vector3.Lerp(
				startLocation,
				endLocation,
				MonsterSlot.CurrentInvocationØ.Progress / MonsterSlot.CurrentInvocationØ.Action.Duration
			);
		}
	}

	public void ResyncUI()
	{
		ResyncActionInvocationUI();
		HPBar.Show(Monster.HPCur, Monster.HPMax);
		MonsterStatusRenderer.color = Monster.CurrentStatus.Color;
	}
}
