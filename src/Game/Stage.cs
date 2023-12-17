using System.Numerics;
using Raylib_cs;

class Stage : Scene
{
	private static Song song;
	private int combo;
	private bool[] pressedLanes = new bool[4];
	private float[] laneAnimationCounter = new float[4];


	public Stage(Song selectedSong)
	{
		song = selectedSong;
	}

	public override void Start()
	{
		// Play the song
		Raylib.PlayMusicStream(song.Music);
	}

	public override void Update()
	{
		// Play/update the music
		Raylib.UpdateMusicStream(song.Music);

		

		// Get keyboard input
		// TODO: Do something for holds
		pressedLanes[0] = Raylib.IsKeyPressed(Settings.Lane1) || Raylib.IsKeyPressed(Settings.Lane1Alt);
		pressedLanes[1] = Raylib.IsKeyPressed(Settings.Lane2) || Raylib.IsKeyPressed(Settings.Lane2Alt);
		pressedLanes[2] = Raylib.IsKeyPressed(Settings.Lane3) || Raylib.IsKeyPressed(Settings.Lane3Alt);
		pressedLanes[3] = Raylib.IsKeyPressed(Settings.Lane4) || Raylib.IsKeyPressed(Settings.Lane4Alt);

		// Update the opacity animations
		// TODO: Don't update if holding down
		for (int i = 0; i < 4; i++)
		{
			// Move the opacity closer to 0 (nothing)
			//? 100 is just some random number to speed it up otherwise it takes like 5 minutes to go back to 0
			if (laneAnimationCounter[i] > 0) laneAnimationCounter[i] -= (100 * Raylib.GetFrameTime());

			// Clamp to 0 because sometimes it can become negative
			if (laneAnimationCounter[i] < 0) laneAnimationCounter[i] = 0;
		}
	}

	public override void Render()
	{
		const int padding = 30;
		const int padding2 = padding * 2;
		const int paddingHalf = padding / 2;

		// Draw the background
		// TODO: Move the background around on a sine wave or something
		// TODO: Don't resize every frame
		// TODO: Don't do the resize calculations in Render();
		AssetManager.Assets.StageBackground.Width = Raylib.GetScreenWidth();
		AssetManager.Assets.StageBackground.Height = Raylib.GetScreenHeight();
		Raylib.DrawTexture(AssetManager.Assets.StageBackground, 0, 0, Color.WHITE);

		// Draw the combo
		// TODO: Add text saying "combo" above or below
		Raylib.DrawTextEx(AssetManager.Assets.MainFont, combo.ToString(), Vector2.Zero, 50, (50 / 10), Color.LIME);

		// Draw the notes
		int y = Raylib.GetScreenHeight() - 100;
		int noteWidth = 130;
		int noteHeight = 30;

		// TODO: Don't do every frame. Only calculate when resize.
		int centerX = Raylib.GetScreenWidth() / 2;

		// calculate the x positions of all notes on lanes
		// TODO: Do manually because I don't think that > 4 things will be added
		int[] laneXPositions = new int[4];
		for (int i = 0; i < 4; i++)
		{
			laneXPositions[i] = (centerX - (2 * noteWidth + padding) + i * (noteWidth + padding)) - paddingHalf;
		}

		// Loop through all of the notes and draw them
		for (int i = 0; i < 4; i++)
		{
			// If the current lane is pressed, then draw a filled one with a 
			// animation thingy that fades out the opacity after whatever seconds
			if (pressedLanes[i])
			{
				const float animationAmount = 100f; //? not a time, just a number
				laneAnimationCounter[i] = animationAmount;
			}

			// Fade the opacity of the note down
			if (laneAnimationCounter[i] > 0)
			{
				// Turn the animation counter into a percentage between 0-255
				//? Everything is casted to byte because the constructor can also take in ints and doesn't know if we tryna give it ints or bytes
				byte opacityPercentage = (byte)(((float)laneAnimationCounter[i] / 100) * 255);
				Color color = new Color((byte)255, (byte)255, (byte)255, opacityPercentage);

				// Draw the opacity thingy
				Raylib.DrawRectangleRounded(new Rectangle(laneXPositions[i], y, noteWidth, noteHeight), 1, 1, color);
			}

			// Outline (always shows)
			Raylib.DrawRectangleRoundedLines(new Rectangle(laneXPositions[i], y, noteWidth, noteHeight), 1, 1, 5f, Color.LIME);
		}
	}
}