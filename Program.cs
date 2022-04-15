namespace CordleSharp
{
    public class Program
    {
        private static string allowedLetters = "QWERTYUIOPASDFGHJKLZXCVBNM";
        private static Dictionary<Char, LetterColor> coloredLetters = new Dictionary<Char, LetterColor>();
        public static void Main(string[] args)
        {
            //PossibleWords is used for generating the winning word.
            //Both PossibleWords and AllowedWords are used for checking if the players input is valid.
            var possibleWordsFile = File.ReadAllLines(Directory.GetCurrentDirectory() + "/PossibleWords.txt");
            var allowedWordsFile = File.ReadAllLines(Directory.GetCurrentDirectory() + "/AllowedWords.txt");
            List<String> PossibleWords = new List<string>(possibleWordsFile);
            List<String> AllowedWords = new List<string>(allowedWordsFile);
            Random random = new Random();

            // string TheWinningWord = "eblbe";
            string TheWinningWord = PossibleWords[random.Next(1, PossibleWords.Count() - 1)];
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("_ _ _ _ _");
                Console.WriteLine("         ");
            }
            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(0, 2 * 6);
                foreach (Char letter in allowedLetters)
                {
                    if (!coloredLetters.ContainsKey(letter))
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else {
                        Console.BackgroundColor = (ConsoleColor)coloredLetters[letter];
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write(letter);
                    Console.Write(" ");
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(0, i * 2);
                Boolean next = false;
                string inputWord = String.Empty;
                var cursorPositon = Console.GetCursorPosition();
                while (next == false)
                {
                    cursorPositon = Console.GetCursorPosition();
                    ConsoleKeyInfo input = Console.ReadKey();
                    switch (input.Key)
                    {
                        case ConsoleKey.Enter:
                            if (AllowedWords.Contains(inputWord.ToLower()) || PossibleWords.Contains(inputWord.ToLower()))
                            {
                                ColoredLetter[] coloredWord = new ColoredLetter[] { null, null, null, null, null };
                                var winningWord = TheWinningWord.ToUpper();
                                for (int j = 0; j < 5; j++)
                                {
                                    if (inputWord[j] == winningWord[j])
                                    {
                                        coloredWord[j] = new ColoredLetter(inputWord[j], LetterColor.GREEN);
                                        winningWord = winningWord.Remove(j, 1).Insert(j, " ");
                                    }
                                    else if (winningWord.Contains(inputWord[j]))
                                    {
                                        coloredWord[j] = new ColoredLetter(inputWord[j], LetterColor.YELLOW);
                                        int index = winningWord.IndexOf(inputWord[j]);
                                        winningWord = winningWord.Remove(index, 1).Insert(index, " ");
                                    }
                                    else
                                    {
                                        coloredWord[j] = new ColoredLetter(inputWord[j], LetterColor.GRAY);
                                    }
                                }
                                Console.SetCursorPosition(0, i * 2);
                                Console.ForegroundColor = ConsoleColor.Black;
                                foreach (var letter in coloredWord)
                                {
                                    Console.BackgroundColor = (ConsoleColor)letter.LetterColor;
                                    Console.Write(letter.Letter + " ");
                                    if (!coloredLetters.ContainsKey(letter.Letter))
                                    {
                                        coloredLetters.Add(letter.Letter, letter.LetterColor);
                                    }
                                    else if (coloredLetters[letter.Letter] == LetterColor.GRAY)
                                    {
                                        coloredLetters[letter.Letter] = letter.LetterColor;
                                    }
                                    else if (coloredLetters[letter.Letter] == LetterColor.YELLOW && letter.LetterColor == LetterColor.GREEN)
                                    {
                                        coloredLetters[letter.Letter] = LetterColor.GREEN;
                                    }

                                }
                                next = true;
                                //TODO: CHECK IF CORRECT
                            }
                            else
                            {
                                Console.SetCursorPosition(cursorPositon.Left, cursorPositon.Top);
                            }
                            break;
                        case ConsoleKey.Backspace:
                            if (String.IsNullOrEmpty(inputWord))
                            {
                                continue;
                            }
                            cursorPositon = Console.GetCursorPosition();
                            inputWord = inputWord.Remove(inputWord.Length - 1);
                            Console.SetCursorPosition(cursorPositon.Left - 1, cursorPositon.Top);
                            Console.Write("_");
                            Console.SetCursorPosition(cursorPositon.Left - 1, cursorPositon.Top);
                            break;
                        default:
                            if (inputWord.Length >= 5)
                            {
                                cursorPositon = Console.GetCursorPosition();
                                Console.SetCursorPosition(cursorPositon.Left - 1, cursorPositon.Top);
                                Console.Write("  ");
                                Console.SetCursorPosition(cursorPositon.Left - 1, cursorPositon.Top);
                                continue;
                            }
                            cursorPositon = Console.GetCursorPosition();
                            Console.SetCursorPosition(cursorPositon.Left - 1, cursorPositon.Top);
                            if (allowedLetters.Contains(((char)input.Key)))
                            {
                                inputWord += ((char)input.Key);
                                Console.Write((char)input.Key + " ");
                            }
                            else
                            {
                                Console.Write("_");
                                Console.SetCursorPosition(cursorPositon.Left - 1, cursorPositon.Top);
                            }
                            break;
                    }
                    cursorPositon = Console.GetCursorPosition();
                    Console.SetCursorPosition(cursorPositon.Left, cursorPositon.Top);
                }
            }
            Console.ReadKey();
        }
    }
}