using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Morse_sender
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
      
      return morseChar;

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
