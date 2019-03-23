/*
 * NetChalker
 *   A library that helps with console chalking.
 * (c) UserR00T 2019 - GPLv3
 */

using System;

namespace NetChalker
{
    public struct MessageTypeData
    {
        public MessageTypeData(ConsoleColor color, string text)
        {
            Color = color;
            Text = text;
        }
        public ConsoleColor Color { get; set; }
        public string Text { get; set; }
    }
}
