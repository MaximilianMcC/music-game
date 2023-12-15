using System.ComponentModel;
using Raylib_cs;

class Song
{
	// Song information and stuff
	public string Name { get; private set; }
	public string Artist { get; private set; }
	public string Mapper { get; private set; }
	public Difficulty Difficulty { get; private set; }

	// Song assets
	public Texture2D Cover { get; private set; }
	public Music Music { get; private set; }

	// Make a new song thing
	public Song(string name, string artist, string mapper, int difficulty, string coverBase64, string musicBase64)
	{
		// Assign the basic information
		Name = name;
		Artist = artist;
		Mapper = mapper;
		Difficulty = (Difficulty)difficulty;

		// Convert the base64 cover to a RayLib texture
		byte[] coverBytes = Convert.FromBase64String(coverBase64);
		Image coverImage = Raylib.LoadImageFromMemory("png", coverBytes);
		Cover = Raylib.LoadTextureFromImage(coverImage);

		// Convert the base64 music to RayLib music
		byte[] musicBytes = Convert.FromBase64String(musicBase64);
		Music = Raylib.LoadMusicStreamFromMemory("mp3", musicBytes);
	}
}



// TODO: Add `ToString()` type things using attributes
enum Difficulty
{
	EASY = 1,
	NORMAL = 2,
	MEDIUM = 3,
	HARD = 4,
	EXPERT = 5
}



class Note
{
	// TODO: Add timestamp or something
	public int Lane { get; private set; }
	public bool Overdrive { get; private set; }
}