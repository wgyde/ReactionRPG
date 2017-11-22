using System.Collections.Generic;
using System.Linq;

public class BattlingMonster
{
	private const float SP_PER_SECOND = 0.5f;

	public readonly BattlingMonsterTeam ParentBattlingTeam;
	public readonly int Index;
	
	public Monster Monster => ParentBattlingTeam.Team.Monsters[Index];

	#region monster status
	public float SPMax => 3;
	private float _SPCur = 0;
	public float SPCur
	{
		get { return _SPCur; }
		set { _SPCur = value.Clamp(0, SPMax); }
	}

	public MonsterStatus CurrentStatus = MonsterStatus.Inst_NoStatus;
	#endregion

	public BattlingMonster(BattlingMonsterTeam parentBattlingTeam, int index)
	{
		ParentBattlingTeam = parentBattlingTeam;
		Index = index;
	}

	public void InvokeAction(BattleAction action, int targetPosition)
	{
		if (ParentBattlingTeam.ActionCooldownActivated) return;
		var actionInvoker = ParentBattlingTeam.ParentBattle.ActionInvoker;
		var invocation = action.Invoke(this, targetPosition);
		actionInvoker.AddInvocation(invocation);
		ParentBattlingTeam.ActivateCooldown();
	}

	public void Step(float dt)
	{
		//gain sp
		float spDelta = MathUtils.Min(
			SPMax - SPCur,
			ParentBattlingTeam.SPCur,
			dt * SP_PER_SECOND
		);
		SPCur += spDelta;
		ParentBattlingTeam.SPCur -= spDelta;
	}
}
