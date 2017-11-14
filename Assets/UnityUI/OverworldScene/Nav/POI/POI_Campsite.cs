using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "NewCampsite", menuName = "Custom/POI/Campsite")]
public class POI_Campsite : POI
{
	public override bool Transit => false;
	public override void Visit(Visitee v) => v.Visit(this);
}
