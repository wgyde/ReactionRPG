using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpriteArray", menuName = "NegativeSpace/SpriteArray", order = 0)]
public class SpriteArray : ScriptableObject
{
#pragma warning disable 649
	public Sprite[] Values;
#pragma warning restore 649
}
