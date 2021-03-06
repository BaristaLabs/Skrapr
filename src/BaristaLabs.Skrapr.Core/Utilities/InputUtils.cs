﻿namespace BaristaLabs.Skrapr.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Input = ChromeDevTools.Input;

    public static class InputUtils
    {
        private static Regex m_commandRegex = new Regex(@"(?<Modifier>[!+^#]?)(?:(?<Letter>[^{}])|(?:{(?<Command>.*?)}))", RegexOptions.ExplicitCapture | RegexOptions.Compiled);

        public static IEnumerable<Input.DispatchKeyEventCommand> ConvertInputToKeyEvents(string input)
        {
            foreach (Match result in m_commandRegex.Matches(input))
            {
                if (result.Groups["Letter"].Success)
                    yield return MapLetterToKeyEvent(result.Groups["Modifier"].Value, result.Groups["Letter"].Value);
                else
                    yield return MapCommandToKeyEvent(result.Groups["Modifier"].Value, result.Groups["Command"].Value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Tester here: https://css-tricks.com/snippets/javascript/javascript-keycodes/
        /// </remarks>
        /// <param name="modifier"></param>
        /// <param name="letter"></param>
        /// <returns></returns>
        private static Input.DispatchKeyEventCommand MapLetterToKeyEvent(string modifier, string letter)
        {
            ConsoleKey? keyCode;
            switch (letter)
            {
                case "\b":
                    keyCode = ConsoleKey.Backspace;
                    break;
                case "\t":
                    keyCode = ConsoleKey.Tab;
                    break;
                case "0":
                    keyCode = ConsoleKey.D0;
                    break;
                case "1":
                    keyCode = ConsoleKey.D1;
                    break;
                case "2":
                    keyCode = ConsoleKey.D2;
                    break;
                case "3":
                    keyCode = ConsoleKey.D3;
                    break;
                case "4":
                    keyCode = ConsoleKey.D4;
                    break;
                case "5":
                    keyCode = ConsoleKey.D5;
                    break;
                case "6":
                    keyCode = ConsoleKey.D6;
                    break;
                case "7":
                    keyCode = ConsoleKey.D7;
                    break;
                case "8":
                    keyCode = ConsoleKey.D8;
                    break;
                case "9":
                    keyCode = ConsoleKey.D9;
                    break;
                case " ":
                    keyCode = ConsoleKey.Spacebar;
                    break;
                case ",":
                    keyCode = ConsoleKey.OemComma;
                    break;
                case ".":
                    keyCode = ConsoleKey.OemPeriod;
                    break;
                case ":":
                    keyCode = ConsoleKey.Oem1; //186
                    break;
                case "/":
                    keyCode = ConsoleKey.Oem2;
                    break;
                case "`":
                    keyCode = ConsoleKey.Oem3;
                    break;
                default:
                    keyCode = (ConsoleKey)Enum.Parse(typeof(ConsoleKey), letter.ToUpperInvariant());
                    break;
            }

            var result = new Input.DispatchKeyEventCommand
            {
                Modifiers = GetModifier(modifier),
                Text = letter,
                //Key = letter,
                NativeVirtualKeyCode = (long)(keyCode ?? 0),
                WindowsVirtualKeyCode = (long)(keyCode ?? 0),
                Type = "keyDown",
                Timestamp = DateTimeOffset.Now.ToUniversalTime().ToUnixTimeSeconds(),
            };

            if (result.Modifiers.HasValue && result.Modifiers.Value == 8)
                result.Text = result.Text.ToUpperInvariant();

            return result;
        }

        private static Input.DispatchKeyEventCommand MapCommandToKeyEvent(string modifier, string command)
        {
            var result = new Input.DispatchKeyEventCommand
            {
                Modifiers = GetModifier(modifier),
                Type = "keyDown",
                Timestamp = DateTimeOffset.Now.ToUniversalTime().ToUnixTimeSeconds()
            };

            switch (command)
            {
                case "Enter":
                    result.Type = "rawKeyDown";
                    result.NativeVirtualKeyCode = 13;
                    result.WindowsVirtualKeyCode = 13;
                    break;
                case "!":
                case "+":
                case "^":
                case "#":
                case "{":
                case "}":
                    result.Text = command;
                    break;
            }

            

            return result;
        }

        private static long? GetModifier(string modifier)
        {
            if (String.IsNullOrWhiteSpace(modifier))
                return null;

            switch (modifier.ToUpperInvariant())
            {
                case "!": //Alt
                    return 1;
                case "^": //Ctrl
                    return 2;
                case "#": //Meta/Command/Win/Yada
                    return 4;
                case "+": //Shift
                    return 8;
                default:
                    return 0;
            }
        }
    }
}
