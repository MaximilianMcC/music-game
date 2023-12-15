using System.Numerics;
using Raylib_cs;

class Game
{
	public static bool Loading = false;

	public static void Run()
	{
		// Make raylib window
		Raylib.InitWindow(800, 600, "music gaem");
		Raylib.SetWindowState(ConfigFlags.FLAG_WINDOW_RESIZABLE);
		Raylib.SetTargetFPS(144);
		Raylib.SetExitKey(KeyboardKey.KEY_NULL);

		// Main game loop
		Start();
		while (Raylib.WindowShouldClose() == false)
		{
			Update();
			Render();
		}
	}

	// Runs before the first frame is rendered
	private static void Start()
	{
		// Load everything that is required
		AssetManager.LoadRequiredAssets();

		// Put the player on the main menu
		GameManager.Screen = GameScreen.MAIN_MENU;
	}

	// Runs every frame
	private static void Update()
	{
		// Check for what game screen is visible
		switch (GameManager.Screen)
		{
			case GameScreen.MAIN_MENU:
				MainMenu.Update();
				break;
		}
	}

	// Runs after every update frame
	private static void Render()
	{
		Raylib.BeginDrawing();
		Raylib.ClearBackground(Color.MAGENTA);

		// Check for if the game is loading
		if (Loading)
		{
			// Show the loading screen
			// TODO: Don't set the width and height every frame. Do in a listener or something
			AssetManager.Assets.LoadingScreen.Width = Raylib.GetScreenWidth();
			AssetManager.Assets.LoadingScreen.Height = Raylib.GetScreenHeight();
			Raylib.DrawTexture(AssetManager.Assets.LoadingScreen, 0, 0, Color.WHITE);

			// End early
			//! This is the only time where this should be done
			Raylib.EndDrawing();
			return;
		}

		// Check for what game screen is visible
		switch (GameManager.Screen)
		{
			case GameScreen.MAIN_MENU:
				MainMenu.Render();
				break;
		}

		Raylib.EndDrawing();
	}
}