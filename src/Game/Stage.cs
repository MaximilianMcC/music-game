using System.Numerics;
using Raylib_cs;

class Stage : Scene
{
	// Song stuff
	private static Song song;
	private const int lanes = 4;
	private bool ended = false;

	// Input stuff
	private bool[] pressedLanes = new bool[4];
	private float[] laneAnimationCounter = new float[4];

	// Timing related stuff
	private double previousTime;

	// Note stuff
	private List<Note> spawnedNotes = new List<Note>();
	private int noteIndex;

	// Scoring stuff
	private int combo = 0;
	private int scoreMultiplier = 1;
	private bool overdrive = false;

	public Stage(Song selectedSong)
	{
		song = selectedSong;
	}

	public override void Start()
	{
		// Play the song
		Raylib.PlayMusicStream(song.Music);
		previousTime = Raylib.GetTime();
	}

	public override void Update()
	{
		// Play/update the music
		Raylib.UpdateMusicStream(song.Music);



		// Get the current time
		double currentTime = Raylib.GetTime();

		// Get the time that the next beat should happen
		double nextBeatTime = previousTime + (1 / song.Bps);

		// Spawn in the next row of notes every beat
		// by checking for if the current time is over the 
		// expected time for the next beat to be played
		if (currentTime >= nextBeatTime)
		{
			previousTime = nextBeatTime;
			Console.WriteLine("Beat");
			
			// Spawn in the next row of notes
			for (int i = 0; i < lanes; i++)
			{
				int index = noteIndex + i;

				// Check for if we have reached the end of the song and do nothing
				if (index >= song.Notes.Count)
				{
					// TODO: Actually do something when the song has ended
					ended = true;
					continue;
				}

				// Add in the note like normal
				spawnedNotes.Add(song.Notes[index]);
			}
			noteIndex += 4;
		}


		// TODO: Could do this all in a single for loop
		// Move all of the loaded in notes downwards
		// at the rate of the songs bpm so the speed
		// is synced with the audio
		foreach (Note note in spawnedNotes)
		{
			
		}


		// TODO: Could do this all in a single for loop
		// Check for if the note was pressed, and in which collision/scoring box


		// TODO: Could do this all in a single for loop
		// Check for if the note is off the screen. if it is
		// then remove it from the spawned notes list.











		// Get keyboard input
		// TODO: Do something for holds
		pressedLanes[0] = Raylib.IsKeyPressed(Settings.Lane1) || Raylib.IsKeyPressed(Settings.Lane1Alt);
		pressedLanes[1] = Raylib.IsKeyPressed(Settings.Lane2) || Raylib.IsKeyPressed(Settings.Lane2Alt);
		pressedLanes[2] = Raylib.IsKeyPressed(Settings.Lane3) || Raylib.IsKeyPressed(Settings.Lane3Alt);
		pressedLanes[3] = Raylib.IsKeyPressed(Settings.Lane4) || Raylib.IsKeyPressed(Settings.Lane4Alt);

		// Update the opacity animations
		// TODO: Don't update if holding down
		for (int i = 0; i < lanes; i++)
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

		// Draw the combo text
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
		int[] laneXPositions = new int[lanes];
		for (int i = 0; i < lanes; i++)
		{
			laneXPositions[i] = (centerX - (2 * noteWidth + padding) + i * (noteWidth + padding)) - paddingHalf;
		}

		// Draw the falling notes
		for (int i = 0; i < spawnedNotes.Count; i++)
		{
			Raylib.DrawRectangle(laneXPositions[spawnedNotes[i].Lane - 1], (int)spawnedNotes[i].Y, noteWidth, noteHeight, Color.BEIGE);
		}

		// Loop through all of the bottom notes and draw them
		for (int i = 0; i < lanes; i++)
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