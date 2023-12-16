using Raylib_cs;

class AssetManager
{
	private static string assets = "./assets/";

	// Load all of the stuff that the game needs
	// (fonts and whatnot)
	public static void LoadRequiredAssets()
	{
		// Load the loading screen and say that we are
		// loading once the loading screen is loaded
		// (need the loading screen to be loaded to show
		// the loading screen for when loading other stuff)
		Assets.LoadingScreen = Raylib.LoadTexture(assets + "loading.png");
		Game.Loading = true;

		// Load the fonts
		Assets.TitleFont = Raylib.LoadFont(assets + "fonts/BERNHC.TTF");
		Assets.MainFont = Raylib.LoadFont(assets + "fonts/STENCIL.TTF");

		// Load the backgrounds
		Assets.MainMenuBackground = Raylib.LoadTexture(assets + "background/main-menu.png");
		Assets.SongSelectBackground = Raylib.LoadTexture(assets + "background/song-select.png");

		// Finished loading
		Game.Loading = false;
	}

	// TODO: Make it protected setter for everything
	public class Assets
	{
		// Loading screen
		public static Texture2D LoadingScreen;

		// Fonts
		public static Font TitleFont;
		public static Font MainFont;

		// Backgrounds
		public static Texture2D MainMenuBackground;
		public static Texture2D SongSelectBackground;
	}
}