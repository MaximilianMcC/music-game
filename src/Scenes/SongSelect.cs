using Raylib_cs;

class SongSelect : Scene
{

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
				string key = currentLine[0].Trim();
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

					case "duration":
						currentSong.Duration = float.Parse(value);
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
				// Get an array of notes on the current row
				// TODO: Sort into lanes or something idk. Also introduce timing somewhere
				char[] noteLine = lines[i].ToCharArray();
				
				// Get all of the notes
				const int lanes = 4;
				for (int j = 0; j < lanes; j++)
				{
					Note note = new Note(j, noteLine[j]);
					notes.Add(note);
				}
			}
		}

		// Stop loading
		Game.Loading = false;
	}

	public override void Update()
	{
		
	}

	public override void Render()
	{

	}
}