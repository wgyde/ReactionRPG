using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class POI : ScriptableObject
{
#pragma warning disable 649
	[SerializeField] public string Name;
	[SerializeField] public Sprite Sprite;
	[SerializeField] public Color Color;
#pragma warning restore 649

	public abstract bool Transit { get; }

	public interface Visitee
	{
		void Visit(POI_Battle poi);
		void Visit(POI_Campsite poi);
		void Visit(POI_Empty poi);
		void Visit(POI_Town poi);
	}

	public abstract void Visit(Visitee v);
}
