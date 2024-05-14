using System;

namespace Domain.Exceptions;

public class CantCreateGameException : Exception
{
    public CantCreateGameException() : base() { }
    public CantCreateGameException(string message) : base(message) { }
    public CantCreateGameException(string message, Exception innerException) : base(message, innerException) { }
}
