class GameManager
{
	private static Scene currentScene;

	public static void SetScene(Scene scene)
	{
		// Run the start method a single time
		scene.Start();
		currentScene = scene;
	}

	public static void UpdateCurrentScene()
	{
		currentScene.Update();
	}

	public static void RenderCurrentScene()
	{
		currentScene.Render();
	}
}