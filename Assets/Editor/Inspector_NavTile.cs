using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NavTile))]
public class Inspector_NavTile : Editor
{
	NavTile Target => (NavTile)target;
	
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		if (GUILayout.Button("OverwritePosition"))
		{
			Target.SnapToCell();
		}
	}
}
