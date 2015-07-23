using System;

public class UUnitAssertException : Exception
{
    public object expected;
    public object received;
    public string message;

    public UUnitAssertException(string message)
        : base(message)
    {
        this.message = message;
    }

    public UUnitAssertException(object expected, object received, string message)
        : base("[UUnit] - Assert Failed - Expected: " + expected + " Received: " + received + "\n\t\t(" + message + ")")
    {
        this.expected = (expected == null) ? "null" : expected;
        this.received = (received == null) ? "null" : received;
        this.message = (message == null) ? "" : message;
    }

    public UUnitAssertException(object expected, object received)
        : base("[UUnit] - Assert Failed - Expected: " + expected + " Received: " + received)
    {
        this.expected = (expected == null) ? "null" : expected;
        this.received = (received == null) ? "null" : received;
    }

}