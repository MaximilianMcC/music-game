using System.ComponentModel;
using Raylib_cs;

class Song
{
	// Song information and stuff
	public string Name { get; set; }
	public string Artist { get; set; }
	public string Mapper { get; set; }
	public Difficulty Difficulty { get; set; }
	public float Duration { get; set; }

	// Song assets
	public Texture2D CoverImage { get; set; }
	public Music Music { get; set; }

	// Actual song
	public List<Note> Notes { get; set; }
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


// TODO: Split up the song into "sections" for loading/unloading groups of notes. Performance shouldn't be an issue though
class Note
{
	// TODO: Add timestamp or something
	public int Lane { get; private set; }
	public NoteType? Type { get; private set; }

	public Note(int lane, char noteType)
	{
		// Set the lane
		Lane = lane;

		// Parse the note type
		switch (noteType)
		{
			case '#':
				Type = NoteType.NORMAL;
				break;
			
			case '@':
				Type = NoteType.OVERDRIVE;
				break;

			case '$':
				Type = NoteType.HOLD;
				break;
			
			// Nothing/empty
			// `.` is used in file, but it can be anything
			default:
				Type = null;
				break;
		}
	}
}

// TODO: Add map to the note characters in file. Could set value to the note ascii value, but sounds kinda dodgy
enum NoteType
{
	NORMAL,
	OVERDRIVE,
	HOLD
}