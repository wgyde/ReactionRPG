using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "NewBattle", menuName = "Custom/POI/Battle")]
public class POI_Battle : POI
{
	public override void Visit(Visitee v) => v.Visit(this);
}