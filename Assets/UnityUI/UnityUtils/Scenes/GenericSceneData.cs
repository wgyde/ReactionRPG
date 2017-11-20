using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class GenericSceneData<TController> : SceneData
where TController : MonoBehaviour
{
	public TController Controller { get; private set; }

	public GenericSceneData(string name) : base(name) { }

	private TController GetController()
	{
		Assert.IsTrue(Scene.isLoaded);
		var roots = Scene.GetRootGameObjects();
		Assert.IsTrue(roots.Length == 1);
		var controller = roots[0].GetComponent<TController>();
		Assert.IsNotNull(controller);
		return controller;
	}

	protected override void OnLoaded()
	{
		base.OnLoaded();
		Controller = GetController();
	}
}
