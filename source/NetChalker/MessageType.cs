/*
 * NetChalker
 *   A library that helps with console chalking.
 * (c) UserR00T 2019 - GPLv3
 */

namespace NetChalker
{
    /// <summary>
    /// All possible message types. These can be changed if needed.
    /// </summary>
    public enum MessageType
    {
        // Why do I have to make summary's for these kinda things? C'mon man

        /// <summary>
        /// None
        /// </summary>
        None,
        /// <summary>
        /// Error
        /// </summary>
        Error,
        /// <summary>
        /// Info
        /// </summary>
        Info,
        /// <summary>
        /// Warning
        /// </summary>
        Warning,
        /// <summary>
        /// Success
        /// </summary>
        Success,
        /// <summary>
        /// Wait
        /// </summary>
        Wait
    }
}
