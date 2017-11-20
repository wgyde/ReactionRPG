using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

//used to store GenericSceneData<T> in a common variable
public class SceneData
{
	public string Name { get; private set; }
	public Scene Scene { get; private set; }
	public GameObject Root { get; private set; }

	public SceneData(string name)
	{
		Name = name;
	}

	private GameObject FindRoot()
	{
		Assert.IsTrue(Scene.isLoaded);
		var roots = Scene.GetRootGameObjects();
		Assert.IsTrue(roots.Length == 1);
		return roots[0];
	}

	protected virtual void OnLoaded() { }

	public void Load(Action onComplete = null)
	{
		if (Scene.isLoaded)
		{
			Debug.LogError("Scene is already loaded");
			return;
		}

		var op = SceneManager.LoadSceneAsync(Name, LoadSceneMode.Additive);
		op.completed += (_) => {
			Scene = SceneManager.GetSceneByName(Name);
			Assert.IsTrue(Scene.isLoaded);
			Root = FindRoot();
			OnLoaded();
			onComplete?.Invoke();
		};
	}

	public void Unload(Action onComplete = null)
	{
		if (!Scene.isLoaded)
		{
			Debug.LogError("Scene is already unloaded");
			return;
		}
		Root.SetActive(false);
		var op = SceneManager.UnloadSceneAsync(Scene.buildIndex);
		op.completed += (_) => {
			Assert.IsTrue(!Scene.isLoaded);
			onComplete?.Invoke();
		};
	}
}
