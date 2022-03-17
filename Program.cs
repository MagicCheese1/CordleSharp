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
        }
    }
}