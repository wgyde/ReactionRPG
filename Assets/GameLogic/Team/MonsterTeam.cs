using System.Collections.Generic;
using System.Linq;

public class MonsterTeam
{
	public Monster[] Monsters = new Monster[3];

	public MonsterTeam()
	{
		for (int i=0; i<Monsters.Length; ++i)
		{
			Monsters[i] = new Monster();
		}
	}

	public void ResetMonsterState()
	{
		foreach (var monster in Monsters)
			monster.ResetVolatileState();
	}
}
