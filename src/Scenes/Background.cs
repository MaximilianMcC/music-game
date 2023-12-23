using System.Security.Cryptography.X509Certificates;
using Raylib_cs;

class BackgroundManager
{
	// TODO: Add getter and setter to backgroundTexture
	public static Texture2D BackgroundTexture;

	public static void RenderBackground()
	{
		//! It's ok to get the screen size every frame, however setting
		//! the size of the texture may be inefficient so doing like this
		// Get the current background sizes
		int currentWidth = Raylib.GetScreenWidth();
		int currentHeight = Raylib.GetScreenHeight();

		// Check for if the background size has changed
		if (BackgroundTexture.Width != currentWidth) BackgroundTexture.Width = currentWidth;
		if (BackgroundTexture.Height != currentHeight) BackgroundTexture.Height = currentHeight;

		// Render the background
		Raylib.DrawTexture(BackgroundTexture, 0, 0, Color.WHITE);
	}
}