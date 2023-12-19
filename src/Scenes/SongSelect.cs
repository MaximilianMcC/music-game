using System.Numerics;
using Raylib_cs;

class SongSelect : Scene
{
	List<Song> songs = new List<Song>();
	int songSelectionIndex = 0;

	public override void Start()
	{
		// Load all of the songs
		Game.Loading = true;

		string songsPath = "./songs";
		foreach (string currentSongPath in Directory.GetDirectories(songsPath))
		{
			// Check for if the current song directory has all of the
			// Required files (*.song, song.mp3, cover.png)
			bool allFilesExist = Directory.GetFiles(currentSongPath, "*.song").Any() 
				&& File.Exists(Path.Combine(currentSongPath, "song.mp3"))
				&& File.Exists(Path.Combine(currentSongPath, "cover.png"));
			if (allFilesExist == false)
			{
				// TODO: Say exactly what files are missing
				Console.WriteLine($"Error while loading song at '{currentSongPath}'. Missing files");
			}

			// Make a song object
			Song currentSong = new Song();

			// Parse all of the song data
			// TODO: Add comments
			string songFile = Directory.GetFiles(currentSongPath, "*.song")[0];
			string[] lines = File.ReadAllLines(songFile);

			// Keep track of where the song data index starts first
			int songDataStartIndex = 0;

			// Loop through every line and parse to get `property` values
			for (int i = 0; i < lines.Length; i++)
			{
				// Get the current line information
				string[] currentLine = lines[i].Split(":");
				string key = currentLine[0].Trim().ToLower();
				string value = (currentLine.Length > 1) ? currentLine[1].Trim() : ""; //? set to "" if no value

				// Get the current lines property stuff
				switch (key)
				{
					case "name":
						currentSong.Name = value;
						break;

					case "artist":
						currentSong.Artist = value;
						break;

					case "mapper":
						currentSong.Mapper = value;
						break;

					case "difficulty":
						currentSong.Difficulty = (Difficulty)int.Parse(value);
						break;

					case "bpm":
						//? Dividing by 60 gives beats per second
						currentSong.Bpm = float.Parse(value);
						currentSong.Bps = float.Parse(value) / 60;
						break;

					case "music":
						songDataStartIndex = i + 1;
						break;
				}
			}

			// Loop through every note and add it to the song
			List<Note> notes = new List<Note>();

			// Start at song data index to avoid going through all of the properties
			//TODO: Could also do `for (int i = 0; i < lines.Length - songDataStartIndex; i++)`
			for (int i = songDataStartIndex; i < lines.Length; i++)
			{
				// Get the timestamp that the note needs to be played (milliseconds)
				double timestamp = double.Parse(lines[i].Split(":")[0]);

				// Get the note type
				NoteType noteType = (NoteType)lines[i].Split(":")[1][0];

				// Get the lane position
				int lane = int.Parse(lines[i][lines[i].Length - 1].ToString());

				// Make a note from the data
				Note note = new Note(lane, noteType, timestamp);
				notes.Add(note);
			}

			// Add the notes to the song
			currentSong.Notes = notes;

			// Load the cover image and actual music/song
			currentSong.CoverImage = Raylib.LoadTexture(Path.Combine(currentSongPath, "cover.png"));
			currentSong.Music = Raylib.LoadMusicStream(Path.Combine(currentSongPath, "song.mp3"));

			// Add the song to the list of currently loaded songs
			songs.Add(currentSong);
		}

		// Stop loading
		Game.Loading = false;
	}

	public override void Update()
	{
		// Check for if the index is going up or down
		if (Raylib.IsKeyPressed(KeyboardKey.KEY_UP)) songSelectionIndex--;
		if (Raylib.IsKeyPressed(KeyboardKey.KEY_DOWN)) songSelectionIndex++;

		// Check for if the current song is selected
		if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER) || Raylib.IsKeyPressed(KeyboardKey.KEY_KP_ENTER))
		{
			// Load the song
			GameManager.SetScene(new Stage(songs[songSelectionIndex]));
		}

		// Clamp the index to the length of the songs array thing
		if (songSelectionIndex < 0) songSelectionIndex = songs.Count - 1;
		else if (songSelectionIndex > songs.Count - 1) songSelectionIndex = 0;

		// Check for if they wanna go back to main menu for some reason
		if (Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE)) GameManager.SetScene(new MainMenu());
	}

	public override void Render()
	{
		const int padding = 50;
		const int padding2 = padding * 2;
		const int paddingHalf = padding / 2;

		// Draw the background
		// TODO: Don't resize every frame
		// TODO: Don't do the resize calculations in Render();
		AssetManager.Assets.SongSelectBackground.Width = Raylib.GetScreenWidth();
		AssetManager.Assets.SongSelectBackground.Height = Raylib.GetScreenHeight();
		Raylib.DrawTexture(AssetManager.Assets.SongSelectBackground, 0, 0, Color.WHITE);

		// Draw the select song title text thing
		Raylib.DrawTextEx(AssetManager.Assets.TitleFont, "Selecting song rn", new Vector2(20, 20), 50, (50 / 10), Color.RED);

		// Draw all of the songs
		int y = 100;
		for (int i = 0; i < songs.Count; i++)
		{
			// Draw the background
			Raylib.DrawRectangleGradientH(padding, y, Raylib.GetScreenWidth() - padding2, 160, Color.BLACK, Color.DARKBLUE);

			// Draw the song name and artist/mapper
			Raylib.DrawTextEx(AssetManager.Assets.MainFont, songs[i].Name, new Vector2(padding, y + paddingHalf), 30, (10 / 30), Color.WHITE);
			Raylib.DrawTextEx(AssetManager.Assets.MainFont, $"by {songs[i].Artist} & {songs[i].Mapper}", new Vector2(padding, y + paddingHalf + 30), 15, (10 / 15), Color.WHITE);

			// Parse the song difficulty
			string[] difficulties = new string[] { "Easy", "norma l", "merium", "hard" };
			string difficulty = difficulties[(int)songs[i].Difficulty - 1];

			// Draw the song difficulty
			Raylib.DrawTextEx(AssetManager.Assets.MainFont, "difficulty", new Vector2(padding, y + paddingHalf + 80), 20, (10 / 20), Color.WHITE);
			Raylib.DrawTextEx(AssetManager.Assets.MainFont, difficulty, new Vector2(padding, y + paddingHalf + 100), 30, (10 / 30), Color.WHITE);

			// Draw the song cover image
			int coverImageWidth = 200;
			Texture2D coverImage = songs[i].CoverImage;
			coverImage.Width = coverImageWidth;
			coverImage.Height = 160;
			Raylib.DrawTexture(coverImage, Raylib.GetScreenWidth() - padding - coverImageWidth, y, Color.WHITE);

			// Draw an outline if the current song is selected
			if (songSelectionIndex == i)
			{
				Raylib.DrawRectangleLinesEx(new Rectangle(padding - 5, y, Raylib.GetScreenWidth() - padding2 + 10, 165), 5, Color.YELLOW);
			}

			// Increase y for next song
			y += 160 + padding;
		}
	}
}