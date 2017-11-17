using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenuAttribute(fileName="NewTown", menuName="Custom/POI/Town")]
public class POI_Town : POI
{
	public override void Visit(Visitee v) => v.Visit(this);
}
