using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "NewEmpty", menuName = "Custom/POI/Empty")]
public class POI_Empty : POI
{
	public override bool Transit => true;
	public override void Visit(Visitee v) => v.Visit(this);
}
