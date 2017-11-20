using System.Collections.Generic;
using System.Linq;
using UnityEngine.Assertions;

public class PersistentData
{
	public static PersistentData Inst;

	private PersistentData() { }

	public static void Load()
	{
		Assert.IsNull(Inst);
		Inst = new PersistentData();
	}

	public int WinCount = 0;
	public int BattleCount = 0;
}
