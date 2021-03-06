﻿using System.Collections.Generic;
using UnityEngine;

//purpose is to make subclassing more convenient
public abstract class BattleActionInvocation_Generic<TAction> : BattleActionInvocation
where TAction : BattleAction
{
	public new TAction Action;

	public BattleActionInvocation_Generic(TAction action, BattlingMonster source, BattlingMonster target) : base(action, source, target)
	{
		Action = action;
	}
}
