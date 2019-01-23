using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageInfo
{
	Faction.Side side;
	Action callback;

	public DamageInfo( Faction.Side side, Action callback )
	{
		this.side = side;
		this.callback = callback;
	}
}
