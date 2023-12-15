using System.Numerics;
using Raylib_cs;

class MainMenu
{
	public static void Update()
	{
		// Check for if a key is pressed
		if (Raylib.GetKeyPressed() != 0) GameManager.Screen = GameScreen.SONG_SELECT_MENU;
	}

	public static void Render()
	{
		// Draw the background
		// TODO: Don't resize every frame
		// TODO: Don't do the resize calculations in Render();
		AssetManager.Assets.MainMenuBackground.Width = Raylib.GetScreenWidth();
		AssetManager.Assets.MainMenuBackground.Height = Raylib.GetScreenHeight();
		Raylib.DrawTexture(AssetManager.Assets.MainMenuBackground, 0, 0, Color.WHITE);

		// Draw the title text
		float titleFontSize = 120;
		Vector2 textPosition = new Vector2(
			(Raylib.GetScreenWidth() - Raylib.MeasureTextEx(AssetManager.Assets.TitleFont, "press any key to start", titleFontSize, (titleFontSize / 10)).X) / 2,
			Raylib.GetScreenHeight() * 0.30f
		);
		Raylib.DrawTextEx(AssetManager.Assets.TitleFont, "press any key to start", textPosition, titleFontSize, (titleFontSize / 10), Color.BLUE);
	}
}