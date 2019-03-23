/*
 * NetChalker
 *   A library that helps with console chalking.
 * (c) UserR00T 2019 - GPLv3
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChalker
{
    public class Chalker
    {
        public Chalker()
        {
            DefaultBackgroundColor = Console.BackgroundColor;
            if (PaddingRight < 0)
                ResetPaddingRight();
        }
        public Chalker(int paddingRight) : this()
        {
            PaddingRight = paddingRight;
        }
        public Chalker(TextCasing casing) : this()
        {
            Casing = casing;
        }
        public Chalker(int paddingRight, TextCasing casing) : this(paddingRight)
        {
            Casing = casing;
        }

        public TextCasing Casing { get; set; } = TextCasing.Default;
        public ConsoleColor DefaultBackgroundColor { get; set; }
        public Dictionary<int, MessageTypeData> MessageTypes { get; set; } = new Dictionary<int, MessageTypeData>
        {
            { (int)MessageType.None, new MessageTypeData(ConsoleColor.White, "NONE") },
            { (int)MessageType.Info, new MessageTypeData(ConsoleColor.DarkCyan, "INFO") },
            { (int)MessageType.Error, new MessageTypeData(ConsoleColor.Red, "ERROR") },
            { (int)MessageType.Warning, new MessageTypeData(ConsoleColor.DarkYellow, "WARNING") },
            { (int)MessageType.Success, new MessageTypeData(ConsoleColor.DarkGreen, "SUCCESS") },
            { (int)MessageType.Wait, new MessageTypeData(ConsoleColor.DarkMagenta, "WAIT") }
        };
        public int PaddingRight { get; set; } = -1;
        public bool AppendSpace { get; set; } = true;

        public string GetStringCasing(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;
            switch (Casing)
            {
                case TextCasing.Lowercase:
                    return str.ToLower();
                case TextCasing.Uppercase:
                    return str.ToUpper();
                case TextCasing.FirstLetterUpper:
                    return char.ToUpper(str[0]) + str.Substring(1).ToLower();
                case TextCasing.Titlecase:
                    return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
                default:
                    return str;
            }
        }
        public void ResetPaddingRight()
        {
            PaddingRight = MessageTypes.Max(x => x.Value.Text.Length) + 1;
        }

        public void WriteError(string message) => WriteMessage(MessageType.Error, message);
        public void WriteWarning(string message) => WriteMessage(MessageType.Wait, message);
        public void WriteSuccess(string message) => WriteMessage(MessageType.Success, message);
        public void WriteWait(string message) => WriteMessage(MessageType.Info, message);
        public void WriteMessage(string message) => WriteMessage(MessageType.Info, message);
        public void WriteMessage(MessageType type, string message)
        {
            WriteMessage((int)type, message);
        }
        public void WriteMessage(int id, string message)
        {
            if (!MessageTypes.TryGetValue(id, out var messageType))
                throw new ArgumentOutOfRangeException(nameof(id));
            WriteMessage(messageType.Color, messageType.Text, message);
        }
        public void WriteMessage(MessageTypeData messageTypeData, string message)
        {
            WriteMessage(messageTypeData.Color, messageTypeData.Text, message);
        }
        public void WriteMessage(ConsoleColor color, string prefix, string message)
        {
            Console.BackgroundColor = color;
            Console.Write(" " + GetStringCasing(prefix).PadRight(PaddingRight));
            Console.BackgroundColor = DefaultBackgroundColor;
            Console.WriteLine(AppendSpace ? " " + message : message);
        }
    }
}
