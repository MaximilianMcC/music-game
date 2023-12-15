using System.Text;

class Program
{
	public static void Main(string[] args)
	{
		// Debug convert to base64 thingy
		// TODO: Remove for production and make a standalone program for making songs
		if (args.Length == 1)
		{
			// Get the bytes of the provided thing, then convert to base64
			byte[] bytes = File.ReadAllBytes(args[0]);
			string base64 = Convert.ToBase64String(bytes);
			Console.WriteLine(base64);

			// Quit and don't run the game
			return;
		}

		Game.Run();
	}
} 