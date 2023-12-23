using System.Numerics;
using Raylib_cs;

class MainMenu : Scene
{
    public override void Start()
    {
        BackgroundManager.BackgroundTexture = AssetManager.Assets.MainMenuBackground;
    }

    public override void Update()
	{
		// Check for if a key is pressed
		if (Raylib.GetKeyPressed() != 0) GameManager.SetScene(new SongSelect());
	}

	public override void Render()
	{
		// Draw the background
		BackgroundManager.RenderBackground();

		// Draw the title text
		float titleFontSize = 120;
		Vector2 textPosition = new Vector2(
			(Raylib.GetScreenWidth() - Raylib.MeasureTextEx(AssetManager.Assets.TitleFont, "press any key to start", titleFontSize, (titleFontSize / 10)).X) / 2,
			Raylib.GetScreenHeight() * 0.30f
		);
		Raylib.DrawTextEx(AssetManager.Assets.TitleFont, "press any key to start", textPosition, titleFontSize, (titleFontSize / 10), Color.BLUE);
	}
}