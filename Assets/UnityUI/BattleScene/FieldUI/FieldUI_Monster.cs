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
	public BattlingMonster BattlingMonster => ParentBattleTeamUI.BattlingMonsterTeam.BattlingMonsters[Index];

	private SpriteRenderer MonsterRenderer;
	private SpriteRenderer MonsterStatusRenderer;

	public void Initialize(FieldUI_BattleTeam parentBattleTeamUI, int index)
	{
		ParentBattleTeamUI = parentBattleTeamUI;
		Index = index;

		Frame = GetComponent<RectTransform>().GetWorldRect();

		#region place monster sprite
		MonsterRenderer = PrefabPool_Sprite.Inst.Take();
		MonsterRenderer.sprite = SpriteCatalog.ID.BoxMonster_Fill.GetAsset();
		MonsterRenderer.transform.position = new Vector3(Frame.center.x, Frame.center.y, 0.0f);
		MonsterRenderer.color = new Color(0.4f, 0.6f, 0.6f, 1.0f);

		MonsterStatusRenderer = PrefabPool_Sprite.Inst.Take();
		MonsterStatusRenderer.sprite = SpriteCatalog.ID.BoxMonster_Outline.GetAsset();
		MonsterStatusRenderer.transform.position = new Vector3(Frame.center.x, Frame.center.y, 0.0f);
		#endregion
	}

	public void ResyncUI()
	{
		HPBar.Show(BattlingMonster.SPCur, BattlingMonster.SPMax);
		MonsterStatusRenderer.color = BattlingMonster.CurrentStatus.Color;
	}
}
