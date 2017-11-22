using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UI_HeadlessActionInvoker
{
	private class InvocationUI : IDisposable
	{
		public readonly UI_HeadlessActionInvoker ParentInvokerUI;
		private BattleActionInvocation Invocation;
		private SpriteRenderer Renderer;
		public bool IsFinished => Invocation.IsFinished;
		private FieldUI FieldUI => ParentInvokerUI.ParentScene.FieldUI;

		public InvocationUI(UI_HeadlessActionInvoker parentInvokerUI, BattleActionInvocation invocation)
		{
			ParentInvokerUI = parentInvokerUI;
			Invocation = invocation;

			Renderer = PrefabPool_Sprite.Inst.Take();
			Renderer.color = Invocation.Action.Color;
			Renderer.sprite = SpriteCatalog.Catalog.Inst[SpriteCatalog.ID.BoxProjectile_Fill];
		}

		public void ResyncUI()
		{
			Vector3 startLocation = FieldUI.GetUI(Invocation.Source).Frame.center;
			Vector3 endLocation = FieldUI.GetUI(Invocation.Target).Frame.center;
			Renderer.transform.position = Vector3.Lerp(
				startLocation,
				endLocation,
				Invocation.Progress / Invocation.Action.Duration
			);
		}

		public void Dispose()
		{
			PrefabPool_Sprite.Inst.Give(Renderer);
		}
	}
	private List<InvocationUI> InvocationUIs;

	public readonly BattleScene ParentScene;
	public HeadlessBattleActionInvoker ActionInvoker => ParentScene.Battle.ActionInvoker;

	public UI_HeadlessActionInvoker(BattleScene parentScene)
	{
		ParentScene = parentScene;
		InvocationUIs = new List<InvocationUI>();
		ActionInvoker.OnInvocationAdded += OnInvocationAdded;
	}

	private void OnInvocationAdded(BattleActionInvocation invocation)
	{
		InvocationUIs.Add(new InvocationUI(this, invocation));
	}

	public void ResyncUI()
	{
		for (int i = InvocationUIs.Count - 1; i >= 0; --i)
		{
			var el = InvocationUIs[i];

			if (el.IsFinished)
			{
				el.Dispose();
				InvocationUIs.RemoveAt(i);
				continue;
			}

			el.ResyncUI();
		}
		InvocationUIs.ForEach(el => el.ResyncUI());
		InvocationUIs.RemoveAll(el => el.IsFinished);
	}
}
