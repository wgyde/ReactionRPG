using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "NewEmpty", menuName = "Custom/POI/Empty")]
public class POI_Road : POI
{
	public override void Visit(Visitee v) => v.Visit(this);
}
