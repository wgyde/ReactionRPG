using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NavTile_ComponentList))]
public class Inspector_NavTile_ComponentList : Editor
{
	NavTile_ComponentList Target => (NavTile_ComponentList)target;

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		if (GUILayout.Button("Refresh"))
			Target.Refresh();
	}
}
