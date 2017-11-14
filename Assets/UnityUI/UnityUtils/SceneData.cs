using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class SceneData<TController> where TController : MonoBehaviour
{
	private string Name;

	public Scene Scene { get; private set; }

	public SceneData(string name)
	{
		Name = name;
	}

	public TController GetController()
	{
		Assert.IsTrue(Scene.isLoaded);
		var roots = Scene.GetRootGameObjects();
		Assert.IsTrue(roots.Length == 1);
		var controller = roots[0].GetComponent<TController>();
		Assert.IsNotNull(controller);
		return controller;
	}

	public void Load(Action<TController> onLoad = null)
	{
		if (Scene.isLoaded) return;

		//Thanks for the codebarf, Unity...
		if (onLoad != null)
		{
			UnityEngine.Events.UnityAction<Scene, LoadSceneMode> onLoad2 = null;
			onLoad2 = (scene, _) =>
			{
				if (scene.name != Name) return;
				Scene = SceneManager.GetSceneByName(Name);
				SceneManager.sceneLoaded -= onLoad2;
				onLoad(GetController());
			};
			SceneManager.sceneLoaded += onLoad2;
		}
		
		SceneManager.LoadScene(Name);
	}
}
