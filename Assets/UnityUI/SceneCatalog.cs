using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneCatalog
{
	public static readonly GenericSceneData<BattleScene> BattleScene = new GenericSceneData<BattleScene>("BattleScene");
	public static readonly GenericSceneData<BattleSelectScene> BattleSelectScene = new GenericSceneData<BattleSelectScene>("BattleSelectScene");
	public static readonly GenericSceneData<OverworldScene> OverworldScene = new GenericSceneData<OverworldScene>("OverworldScene");
	public static readonly GenericSceneData<ContentLoadingScene> ContentLoadingScene = new GenericSceneData<ContentLoadingScene>("ContentLoadingScene");
}
