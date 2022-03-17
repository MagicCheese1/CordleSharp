namespace CordleSharp {
    public class Program {
        private static string allowedLetters = "QWERTYUIOPASDFGHJKLZXCVBNM";
        public static void Main (string[] args) {
            //PossibleWords is used for generating the winning word.
            //Both PossibleWords and AllowedWords are used for checking if the players input is valid.
            var possibleWordsFile = File.ReadAllLines ("L:/CordleSharp/PossibleWords.txt");
            var allowedWordsFile = File.ReadAllLines ("L:/CordleSharp/AllowedWords.txt");
            List<String> PossibleWords = new List<string> (possibleWordsFile);
            List<String> AllowedWords = new List<string> (allowedWordsFile);
            Random random = new Random ();

            // string TheWinningWord = "eblbe";
            string TheWinningWord = PossibleWords[random.Next (1, PossibleWords.Count () - 1)];
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear ();
            Console.SetCursorPosition (0, 0);
            for (int i = 0; i < 6; i++) {
                Console.WriteLine ("_ _ _ _ _");
                Console.WriteLine ("         ");
            }
        }
    }
}