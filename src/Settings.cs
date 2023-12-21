using Raylib_cs;

class Settings
{
	// Lane stuff
	// TODO: Add a way to change settings, or setting presets
	public static KeyboardKey Lane1 { get; private set; } = KeyboardKey.KEY_D;
	public static KeyboardKey Lane2 { get; private set; } = KeyboardKey.KEY_F;
	public static KeyboardKey Lane3 { get; private set; } = KeyboardKey.KEY_J;
	public static KeyboardKey Lane4 { get; private set; } = KeyboardKey.KEY_K;

	// Alternative lane settings
	// TODO: Add a way to change settings, or setting presets
	public static KeyboardKey Lane1Alt { get; private set; } = KeyboardKey.KEY_F8;
	public static KeyboardKey Lane2Alt { get; private set; } = KeyboardKey.KEY_F7;
	public static KeyboardKey Lane3Alt { get; private set; } = KeyboardKey.KEY_F6;
	public static KeyboardKey Lane4Alt { get; private set; } = KeyboardKey.KEY_F5;

	// General keys
	public static KeyboardKey Back { get; private set; } = KeyboardKey.KEY_ESCAPE;

	// Options
	public static float SongVolume { get; set; } = 0.1f;
}