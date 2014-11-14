using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Logger
/// </summary>
public static class Logger
{

    //private static string timestampFormat = "dd-MM-yyyy HH:mm:ss";

    private static string logName = "KonsernwebErrors";

    public static void Log(LogEntry logEntry)
    {
        string[] arr = new string[4];
        arr[0] = logEntry.Type.ToString();
        arr[1] = logEntry.Classname;
        arr[2] = logEntry.Severity.ToString();
        arr[3] = logEntry.Message;

        WAF.Data.WAFLog.Insert(logName, arr);
    }
}

public enum LogEntryType
{
    ExternalSystem, Input, Data
}

public enum LogEntrySeverity
{
    Error, Warning
}

public class LogEntry
{

    public LogEntryType Type { get; set; }
    public LogEntrySeverity Severity { get; set; }
    public string Classname { get; set; }
    public string Message { get; set; }

    public LogEntry(LogEntryType type, LogEntrySeverity severity, string classname, string message)
    {
        this.Type = type;
        this.Severity = severity;
        this.Classname = classname;
        this.Message = message;
    }
}