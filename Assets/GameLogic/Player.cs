using System.Collections.Generic;
using System.Linq;

public class Player
{
	public static Player Inst = new Player();

	public MonsterTeam Team;

	private Player()
	{
		Team = new MonsterTeam();
	}
}
