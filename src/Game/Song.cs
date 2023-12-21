using System.ComponentModel;
using Raylib_cs;

class Song
{
	// Song information and stuff
	public string Name { get; set; }
	public string Artist { get; set; }
	public string Mapper { get; set; }
	
	public Difficulty Difficulty { get; set; }
	public float Bpm { get; set; }              //? Beats per minute
	public float Bps { get; set; }             //? Beats per second
	public float RowsPerBeat { get; set; }

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
	public int Lane { get; private set; }
	public NoteType? Type { get; set; }
	public float Y { get; set; }
	public bool Pressed { get; set; }

	public Note(int lane, NoteType noteType)
	{
		// Set everything
		Lane = lane;
		Type = noteType;
		Pressed = false;
	}
}

enum NoteType
{
	NORMAL = '#',
	OVERDRIVE = '@',
	HOLD = '$',

	NONE = '.',
}