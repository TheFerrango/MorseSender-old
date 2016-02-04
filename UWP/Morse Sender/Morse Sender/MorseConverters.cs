namespace Morse_Sender
{
	public static class MorseConverters
  {
    private static string Char2Morse(char c)
    {
      string morseChar = "";
      switch (c)
      {
        case 'a': morseChar = ".-"; break;
        case 'b': morseChar = "-..."; break;
        case 'c': morseChar = "-.-."; break;
        case 'd': morseChar = "-.."; break;
        case 'e': morseChar = "."; break;
        case 'f': morseChar = "..-."; break;
        case 'g': morseChar = "--."; break;
        case 'h': morseChar = "...."; break;
        case 'i': morseChar = ".."; break;
        case 'j': morseChar = ".---"; break;
        case 'k': morseChar = "-.-"; break;
        case 'l': morseChar = ".-.."; break;
        case 'm': morseChar = "--"; break;
        case 'n': morseChar = "-."; break;
        case 'o': morseChar = "---"; break;
        case 'p': morseChar = ".--."; break;
        case 'q': morseChar = "--.-"; break;
        case 'r': morseChar = ".-."; break;
        case 's': morseChar = "..."; break;
        case 't': morseChar = "-"; break;
        case 'u': morseChar = "..-"; break;
        case 'v': morseChar = "...-"; break;
        case 'w': morseChar = ".--"; break;
        case 'x': morseChar = "-..-"; break;
        case 'y': morseChar = "-.--"; break;
        case 'z': morseChar = "--.."; break;
        case '0': morseChar = "-----"; break;
        case '1': morseChar = ".----"; break;
        case '2': morseChar = "..---"; break;
        case '3': morseChar = "...--"; break;
        case '4': morseChar = "....-"; break;
        case '5': morseChar = "....."; break;
        case '6': morseChar = "-...."; break;
        case '7': morseChar = "--..."; break;
        case '8': morseChar = "---.."; break;
        case '9': morseChar = "----."; break;
        case '.': morseChar = ".-.-"; break;
        case ',': morseChar = "--..--"; break;
        case '?': morseChar = "..--.."; break;
        case ' ': morseChar = " / "; break;
        default: morseChar = ""; break;
      }

      return morseChar + " ";

    }

    private static string Morse2Char(string letter)
    {
      string morseChar = "";
      switch (letter)
      {
        case ".-": morseChar = "a"; break;
        case "-...": morseChar = "b"; break;
        case "-.-.": morseChar = "c"; break;
        case "-..": morseChar = "d"; break;
        case ".": morseChar = "e"; break;
        case "..-.": morseChar = "f"; break;
        case "--.": morseChar = "g"; break;
        case "....": morseChar = "h"; break;
        case "..": morseChar = "i"; break;
        case ".---": morseChar = "j"; break;
        case "-.-": morseChar = "k"; break;
        case ".-..": morseChar = "l"; break;
        case "--": morseChar = "m"; break;
        case "-.": morseChar = "n"; break;
        case "---": morseChar = "o"; break;
        case ".--.": morseChar = "p"; break;
        case "--.-": morseChar = "q"; break;
        case ".-.": morseChar = "r"; break;
        case "...": morseChar = "s"; break;
        case "-": morseChar = "t"; break;
        case "..-": morseChar = "u"; break;
        case "...-": morseChar = "v"; break;
        case ".--": morseChar = "w"; break;
        case "-..-": morseChar = "x"; break;
        case "-.--": morseChar = "y"; break;
        case "--..": morseChar = "z"; break;
        case "-----": morseChar = "0"; break;
        case ".----": morseChar = "1"; break;
        case "..---": morseChar = "2"; break;
        case "...--": morseChar = "3"; break;
        case "....-": morseChar = "4"; break;
        case ".....": morseChar = "5"; break;
        case "-....": morseChar = "6"; break;
        case "--...": morseChar = "7"; break;
        case "---..": morseChar = "8"; break;
        case "----.": morseChar = "9"; break;
        case ".-.-": morseChar = "."; break;
        case "--..--": morseChar = ","; break;
        case "..--..": morseChar = "?"; break;
      }
      return morseChar;
    }

    public static string ConvertToText(string toConvert)
    {
      string finale = "";
      string[] words = toConvert.Split('/');
      for (int i = 0; i < words.Length; i++)
        finale += MorseToWord(words[i]);
      return finale;
    }

    private static string MorseToWord(string p)
    {
      string finale = "";
      string[] lettere = p.Split(' ');
      foreach (string s in lettere)
        finale += Morse2Char(s);
      return finale + " ";
    }

    public static string ConvertToMorse(string toConvert)
    {
      toConvert = toConvert.ToLower();
      string encoded = "";
      foreach (char cara in toConvert)
      {
        encoded += Char2Morse(cara);
      }
      return encoded;
    }
  }
}
