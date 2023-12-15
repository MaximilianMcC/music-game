using Raylib_cs;

class Game
{
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
		
	}

	// Runs every frame
	private static void Update()
	{
		// Check for what game screen is visible
		switch (GameManager.Screen)
		{
			
		}
	}

	// Runs after every update frame
	private static void Render()
	{
		Raylib.BeginDrawing();
		Raylib.ClearBackground(Color.MAGENTA);

		Raylib.DrawText("among us in real lf", 0, 0, 30, Color.WHITE);

		Raylib.EndDrawing();
	}
}