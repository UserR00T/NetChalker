/*
 * NetChalker
 *   A library that helps with console chalking.
 * (c) UserR00T 2019 - GPLv3
 */

namespace NetChalker
{
    /// <summary>
    /// This contains all possible text casing options.
    /// </summary>
    public enum TextCasing
    {
        /// <summary>
        /// The default casing as provided by the prefix string.
        /// </summary>
        Default,
        /// <summary>
        /// lowercases the whole string.
        /// </summary>
        Lowercase,
        /// <summary>
        /// UPPERCASES THE WHOLE STRING.
        /// </summary>
        Uppercase,
        /// <summary>
        /// Makes the first letter of the string uppercase.
        /// </summary>
        FirstLetterUpper,
        /// <summary>
        /// Title Cases The Whole String.
        /// </summary>
        Titlecase
    }
}