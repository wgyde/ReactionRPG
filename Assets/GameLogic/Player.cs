using System.Collections.Generic;
using System.Linq;

public class Player
{
	public static Player Inst = new Player();

	public MonsterTeam Team;

	private Player()
	{
		Team = new MonsterTeam();
		Team.Monsters[2].Actions[0] = new BattleAction_Status(MonsterStatus.Inst_Frail) { TargetType = BattleAction.TTargetType.Enemy };
		Team.Monsters[2].Actions[1] = new BattleAction_Status(MonsterStatus.Inst_Inspired) { TargetType = BattleAction.TTargetType.Friendly };
	}
}
