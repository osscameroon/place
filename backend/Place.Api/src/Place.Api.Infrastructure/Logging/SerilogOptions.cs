using System.Collections.Generic;

/// <summary>
/// Represents the configuration options for Serilog logging within the application.
/// </summary>
internal sealed class SerilogOptions
{
    /// <summary>
    /// Gets or sets the minimum log level. Logs below this level will be ignored.
    /// </summary>
    public string Level { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the console logging options.
    /// </summary>
    public ConsoleOptions Console { get; set; } = new();

    /// <summary>
    /// Gets or sets the file logging options.
    /// </summary>
    public FileOptions File { get; set; } = new();

    /// <summary>
    /// Gets or sets the Seq logging options.
    /// </summary>
    public SeqOptions Seq { get; set; } = new();

    /// <summary>
    /// Gets or sets the collection of paths to exclude from logging.
    /// </summary>
    public IEnumerable<string>? ExcludePaths { get; set; }

    /// <summary>
    /// Gets or sets the collection of properties to exclude from logs.
    /// </summary>
    public IEnumerable<string>? ExcludeProperties { get; set; }

    /// <summary>
    /// Gets or sets the log level overrides for specific namespaces or classes.
    /// </summary>
    public Dictionary<string, string> Overrides { get; set; } = new();

    /// <summary>
    /// Gets or sets the additional tags to be included with each log entry.
    /// </summary>
    public Dictionary<string, object> Tags { get; set; } = new();

    /// <summary>
    /// Represents the console logging specific options.
    /// </summary>
    public sealed class ConsoleOptions
    {
        /// <summary>
        /// Gets or sets a value indicating whether console logging is enabled.
        /// </summary>
        public bool Enabled { get; set; }
    }

    /// <summary>
    /// Represents the file logging specific options.
    /// </summary>
    public sealed class FileOptions
    {
        /// <summary>
        /// Gets or sets a value indicating whether file logging is enabled.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the path where log files will be written.
        /// </summary>
        public string Path { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the interval at which log files are rotated.
        /// </summary>
        public string Interval { get; set; } = string.Empty;
    }

    /// <summary>
    /// Represents the Seq logging specific options.
    /// </summary>
    public sealed class SeqOptions
    {
        /// <summary>
        /// Gets or sets a value indicating whether Seq logging is enabled.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the URL of the Seq server.
        /// </summary>
        public string Url { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the API key for the Seq server, if required.
        /// </summary>
        public string ApiKey { get; set; } = string.Empty;
    }
}
