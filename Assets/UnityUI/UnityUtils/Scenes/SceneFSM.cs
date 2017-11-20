using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SceneFSM
{
	private SceneData CurrentScene;

	private void Enter(SceneData sceneData, Action onCompleteØ)
	{
		sceneData.Load(() => {
			CurrentScene = sceneData;
			onCompleteØ?.Invoke();
		});
	}
	
	private void Exit(Action onCompleteØ)
	{
		CurrentScene.Unload(() => {
			CurrentScene = null;
			onCompleteØ?.Invoke();
		});
	}

	public void SetInitialScene(SceneData sceneData, Action onCompleteØ = null)
	{
		Enter(sceneData, onCompleteØ);
	}

	public void Transition(SceneData sceneData, Action onCompleteØ = null)
	{
		Exit(() => { Enter(sceneData, onCompleteØ); });
	}
}
