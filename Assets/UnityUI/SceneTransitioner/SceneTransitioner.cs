using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SceneTransitioner : MonoBehaviour
{
#pragma warning disable 649
	[SerializeField] SpriteRenderer FadeoutOverlay;
#pragma warning restore 649

	public static SceneTransitioner Inst { get; private set; }

	private SceneFSM SceneFSM;

	private const float FADE_DURATION = 0.5f;
	private float _FadeLevel;
	private float FadeAlpha
	{
		get { return _FadeLevel; }
		set { _FadeLevel = value.Clamp(0.0f, 1.0f); }
	}

	private IEnumerator TransitionProcessØ;

	public void Transition(SceneData sceneData, Action onCompleteØ = null)
	{
		if (TransitionProcessØ != null)
		{
			Debug.LogError($"Can't transition to {sceneData.Name} because a transition is already underway");
			return;
		}
		TransitionProcessØ = TransitionAsync(sceneData, onCompleteØ);
	}

	private IEnumerator TransitionAsync(SceneData sceneData, Action onLoadØ)
	{
		bool wait = false;

		//fade out
		while (FadeAlpha < 1.0f)
		{
			FadeAlpha += Time.deltaTime / FADE_DURATION;
			yield return null;
		}

		//collect garbage
		GC.Collect();

		//transition
		wait = true;
		SceneFSM.Transition(sceneData, () => {
			wait = false;
			onLoadØ?.Invoke();
		});
		while (wait)
		{
			yield return null;
		}

		//fade in
		while (FadeAlpha > 0.0f)
		{
			FadeAlpha -= Time.deltaTime / FADE_DURATION;
			yield return null;
		}
		
		yield break;
	}

	private void Initialize()
	{
		Inst = this;
		SceneFSM = new SceneFSM();
		SceneFSM.SetInitialScene(SceneCatalog.ContentLoadingScene);
	}

	private void _Update()
	{
		if (TransitionProcessØ != null)
		{
			if (!TransitionProcessØ.MoveNext())
			{
				TransitionProcessØ = null;
			}
		}
	}

	private void ResyncUI()
	{
		FadeoutOverlay.color = FadeoutOverlay.color.WithAlpha(FadeAlpha);
	}

	protected virtual void Awake()
	{
		Initialize();
	}
	
	protected virtual void Update()
	{
		_Update();
		ResyncUI();
	}
}
