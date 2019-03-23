/*
 * NetChalker
 *   A library that helps with console chalking.
 * (c) UserR00T 2019 - GPLv3
 */

using System;

namespace NetChalker
{
    /// <summary>
    /// The struct that will be used as prefix.
    /// </summary>
    public struct MessageTypeData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageTypeData"/> class.
        /// </summary>
        /// <param name="color">The color that will be used for the background.</param>
        /// <param name="text">The text.</param>
        public MessageTypeData(ConsoleColor color, string text)
        {
            Color = color;
            Text = text;
        }
        /// <summary>
        /// The background color.
        /// </summary>
        public ConsoleColor Color { get; set; }
        /// <summary>
        /// The prefix text.
        /// </summary>
        public string Text { get; set; }
    }
}
