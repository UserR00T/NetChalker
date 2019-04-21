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
    /// <summary>
    /// The main Chalker class.
    /// </summary>
    public class Chalker
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Chalker"/> class.
        /// </summary>
        public Chalker()
        {
            DefaultBackgroundColor = Console.BackgroundColor;
            if (PaddingRight < 0)
                ResetPaddingRight();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Chalker"/> class.
        /// </summary>
        /// <param name="paddingRight">The padding that will be used on the right side of the prefix. Negative values are not allowed.</param>
        public Chalker(int paddingRight) : this()
        {
            PaddingRight = paddingRight;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Chalker"/> class.
        /// </summary>
        /// <param name="casing">The casing method used for the prefix.</param>
        public Chalker(TextCasing casing) : this()
        {
            Casing = casing;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Chalker"/> class.
        /// </summary>
        /// <param name="paddingRight">The padding that will be used on the right side of the prefix. Negative values are not allowed.</param>
        /// <param name="casing">The casing method used for the prefix.</param>
        public Chalker(int paddingRight, TextCasing casing) : this(paddingRight)
        {
            Casing = casing;
        }
        /// <summary>
        /// The casing used in this instance.
        /// </summary>
        public TextCasing Casing { get; set; } = TextCasing.Default;
        /// <summary>
        /// The default background color. (set at construction of instance.)
        /// </summary>
        public ConsoleColor DefaultBackgroundColor { get; set; }
        /// <summary>
        /// The default message types. Can be modified.
        /// </summary>
        public Dictionary<int, MessageTypeData> MessageTypes { get; set; } = new Dictionary<int, MessageTypeData>
        {
            { (int)MessageType.None, new MessageTypeData(ConsoleColor.White, "NONE") },
            { (int)MessageType.Info, new MessageTypeData(ConsoleColor.DarkCyan, "INFO") },
            { (int)MessageType.Error, new MessageTypeData(ConsoleColor.Red, "ERROR") },
            { (int)MessageType.Warning, new MessageTypeData(ConsoleColor.DarkYellow, "WARNING") },
            { (int)MessageType.Success, new MessageTypeData(ConsoleColor.DarkGreen, "SUCCESS") },
            { (int)MessageType.Wait, new MessageTypeData(ConsoleColor.DarkMagenta, "WAIT") }
        };
        /// <summary>
        /// The padding to the right used in this instance.
        /// </summary>
        public int PaddingRight { get; set; } = -1;
        /// <summary>
        /// Should there be a space after the prefix?
        /// </summary>
        public bool AppendSpace { get; set; } = true;
        /// <summary>
        /// Gets the correct casing for the currently set casing method.
        /// </summary>
        /// <param name="str">The string to be properly cased.</param>
        /// <returns>Returns the correctly cased string.</returns>
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
        /// <summary>
        /// Resets the padding to the right to the minimum value.
        /// </summary>
        public void ResetPaddingRight()
        {
            PaddingRight = MessageTypes.Max(x => x.Value.Text.Length) + 1;
        }
        /// <summary>
        /// Outputs the <paramref name="message"/> prefixed with the <see cref="MessageType.Error"/> type.
        /// </summary>
        /// <param name="message">The message to output.</param>
        public void WriteError(string message) => WriteMessage(MessageType.Error, message);
        /// <summary>
        /// Outputs the <paramref name="message"/> prefixed with the <see cref="MessageType.Warning"/> type.
        /// </summary>
        /// <param name="message">The message to output.</param>
        public void WriteWarning(string message) => WriteMessage(MessageType.Wait, message);
        /// <summary>
        /// Outputs the <paramref name="message"/> prefixed with the <see cref="MessageType.Success"/> type.
        /// </summary>
        /// <param name="message">The message to output.</param>
        public void WriteSuccess(string message) => WriteMessage(MessageType.Success, message);
        /// <summary>
        /// Outputs the <paramref name="message"/> prefixed with the <see cref="MessageType.Wait"/> type.
        /// </summary>
        /// <param name="message">The message to output.</param>
        public void WriteWait(string message) => WriteMessage(MessageType.Wait, message);
        /// <summary>
        /// Outputs the <paramref name="message"/> prefixed with the <see cref="MessageType.Info"/> type.
        /// </summary>
        /// <param name="message">The message to output.</param>
        public void WriteMessage(string message) => WriteMessage(MessageType.Info, message);
        /// <summary>
        /// Outputs the <paramref name="message"/> with a specific <see cref="MessageType"/>.
        /// </summary>
        /// <param name="type">The type that will be used.</param>
        /// <param name="message">The message to output.</param>
        public void WriteMessage(MessageType type, string message)
        {
            WriteMessage((int)type, message);
        }
        /// <summary>
        /// Outputs the <paramref name="message"/> with a specific ID found in the <see cref="MessageTypes"/> dictionary.
        /// </summary>
        /// <param name="id">The ID that will be used.</param>
        /// <param name="message">The message to output.</param>
        public void WriteMessage(int id, string message)
        {
            if (!MessageTypes.TryGetValue(id, out var messageType))
                throw new ArgumentOutOfRangeException(nameof(id));
            WriteMessage(messageType.Color, messageType.Text, message);
        }
        /// <summary>
        /// Outputs the <paramref name="message"/> with a specific <see cref="MessageTypeData"/>.
        /// </summary>
        /// <param name="messageTypeData">The <see cref="MessageTypeData"/> that will be used.</param>
        /// <param name="message">The message to output.</param>
        public void WriteMessage(MessageTypeData messageTypeData, string message)
        {
            WriteMessage(messageTypeData.Color, messageTypeData.Text, message);
        }
        /// <summary>
        /// Outputs the <paramref name="message"/> with a specific color and prefix.
        /// </summary>
        /// <param name="color">The background color.</param>
        /// <param name="prefix">The prefix text.</param>
        /// <param name="message">The message to output.</param>
        public void WriteMessage(ConsoleColor color, string prefix, string message)
        {
            Console.BackgroundColor = color;
            Console.Write(" " + GetStringCasing(prefix).PadRight(PaddingRight));
            Console.BackgroundColor = DefaultBackgroundColor;
            Console.WriteLine(AppendSpace ? " " + message : message);
        }
    }
}
