using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneCatalog
{
	public static readonly SceneData<BattleScene> BattleScene = new SceneData<BattleScene>("BattleScene");
	public static readonly SceneData<BattleSelectScene> BattleSelectScene = new SceneData<BattleSelectScene>("BattleSelectScene");
	public static readonly SceneData<ContentLoadingScene> ContentLoadingScene = new SceneData<ContentLoadingScene>("ContentLoadingScene");
	public static readonly SceneData<OverworldScene> OverworldScene = new SceneData<OverworldScene>("OverworldScene");
}
