using Raylib_cs;

class Settings
{
	// Lane stuff
	// TODO: Add a way to change settings, or setting presets
	public static KeyboardKey Lane1 { get; private set; } = KeyboardKey.KEY_D;
	public static KeyboardKey Lane2 { get; private set; } = KeyboardKey.KEY_F;
	public static KeyboardKey Lane3 { get; private set; } = KeyboardKey.KEY_J;
	public static KeyboardKey Lane4 { get; private set; } = KeyboardKey.KEY_K;
}