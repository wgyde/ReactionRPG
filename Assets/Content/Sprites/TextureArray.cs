using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TextureArray", menuName = "NegativeSpace/TextureArray", order = 0)]
public class TextureArray : ScriptableObject
{
#pragma warning disable 649
	public Texture2D[] Textures;
#pragma warning restore 649
}
