using Raylib_cs;

class SongSelect : Scene
{

    public override void Start()
    {
        // Load all of the songs
		Game.Loading = true;

		string songsPath = "./songs";
		foreach (string songFile in Directory.GetFiles(songsPath))
		{
			// Ignore anything that isn't a song file
			if (!songFile.EndsWith(".song")) continue;

			// Parse all of the song data
			string[] songData = File.ReadAllLines(songFile);
			for (int i = 0; i < songData.Length; i++)
			{
				string line = songData[i];

				// Check for if the current line is a comment
				// and ignore/skip over it
				// TODO: Check for if the line contains an inline comment
				if (line.StartsWith("#")) continue;

				// Get the song name
				string name = "";
				if (line.StartsWith("name:")) name = line.Split(":")[1].Trim();

				// Get the song artist
				string artist = "";
				if (line.StartsWith("artist:")) artist = line.Split(":")[1].Trim();

				// Get the song mapper
				string mapper = "";
				if (line.StartsWith("artist:")) mapper = line.Split(":")[1].Trim();

				// Get the song difficulty
				int difficulty = 0;
				if (line.StartsWith("difficulty:")) difficulty = int.Parse(line.Split(":")[1].Trim());

				// Get the song cover
				string cover = "";
				if (line.StartsWith("cover:")) cover = line.Split(":")[1].Trim();

				// Get thr song music
				string music = "";
				if (line.StartsWith("music:")) music = line.Split(":")[1].Trim();

				// Check for if we have all of the required data. If we do
				// then we can start parsing the song notes/beatmap
				bool informationGathered = name != "" && mapper != "" && difficulty != 0 && cover != "" && music != "";
				if (informationGathered)
				{
					// Make the song object
					Song song = new Song(name, artist, mapper, difficulty, cover, music);

					// Loop through each note and get its time, lane, and type.
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