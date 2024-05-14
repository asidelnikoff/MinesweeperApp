using System;

namespace Domain.Exceptions;

public class CellAlreadyCheckedException : Exception
{
    public int Row { get; init; }
    public int Column { get; init; }

    public CellAlreadyCheckedException(int row, int col) : base()
    {
        Row = row;
        Column = col;
    }
    public CellAlreadyCheckedException(int row, int col, string message) : base(message)
    {
        Row = row;
        Column = col;
    }
    public CellAlreadyCheckedException(
        int row,
        int col,
        string message,
        Exception innerException) : base(message, innerException)
    {
        Row = row;
        Column = col;
    }
}
