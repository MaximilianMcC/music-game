class GameManager
{
	public static GameScreen Screen { get; set; }
}

enum GameScreen
{
	MAIN_MENU,
	SETTINGS_MENU,

	SONG_SELECT_MENU,

	GAME,
	GAME_RESULTS
}