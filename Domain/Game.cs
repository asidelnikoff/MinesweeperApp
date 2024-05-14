using Domain.Exceptions;
using System;
using System.Linq;

namespace Domain;

public class Game
{
    public Guid Id { get; init; }
    public int Width { get; init; }
    public int Height { get; init; }
    public int MinesCount { get; init; }
    public bool IsCompleted { get; private set; }
    public FieldCell[][] Field => _field.Select(it => it.ToArray()).ToArray();

    FieldCell[][] _field;
    bool[][] _isMinesSet;

    public Game(int width, int height, int minesCount)
    {
        if (width <= 0 || height <= 0)
        {
            throw new CantCreateGameException("Width and Height must be greater than 0");
        }

        if (width * height <= minesCount)
        {
            throw new CantCreateGameException("Number of Mines should be less than Width*Height");
        }

        Id = Guid.NewGuid();

        IsCompleted = false;

        Width = width;
        Height = height;
        MinesCount = minesCount;

        _field = new FieldCell[height][];
        _isMinesSet = new bool[height][];
        for (int i = 0; i < height; i++)
        {
            _field[i] = new FieldCell[width];
            _isMinesSet[i] = new bool[width];
            for (int j = 0; j < width; j++)
            {
                _field[i][j] = FieldCell.None;
                _isMinesSet[i][j] = false;
            }
        }
        GenerateRandomField();
    }

    public void MakeTurn(int row, int col)
    {
        if (IsCompleted)
        {
            throw new GameCompletedException(Id);
        }

        if (_field[row][col] != FieldCell.None)
        {
            throw new CellAlreadyCheckedException(row, col);
        }

        OpenCell(row, col);

        bool isWin = IsWin();
        if (_isMinesSet[row][col] || isWin)
        {
            CompleteGame(isWin);
        }
    }

    private static (int x, int y)[] _directions = new (int, int)[]
    {
            (0, 1),
            (0, -1),
            (1, 0),
            (-1, 0),
            (1, 1),
            (1, -1),
            (-1, 1),
            (-1, -1)
    };
    private void OpenCell(int row, int col)
    {
        if (row < 0 || row >= Height
            || col < 0 || col >= Width)
        {
            return;
        }

        if (_isMinesSet[row][col])
        {
            return;
        }

        if (_field[row][col] != FieldCell.None)
        {
            return;
        }

        var cellValue = FieldCell.Zero;

        foreach (var dir in _directions)
        {
            int nX = col + dir.x;
            int nY = row + dir.y;

            if (nX >= 0 && nX < Width
                && nY >= 0 && nY < Height)
            {
                if (_isMinesSet[nY][nX])
                {
                    cellValue++;
                }
            }
        }

        _field[row][col] = cellValue;

        if (cellValue == FieldCell.Zero)
        {
            foreach (var dir in _directions)
            {
                int nX = col + dir.x;
                int nY = row + dir.y;

                OpenCell(nY, nX);
            }
        }
    }

    private void CompleteGame(bool isWin)
    {
        IsCompleted = true;
        ShowField();

        var mineCell = isWin ? FieldCell.M : FieldCell.X;
        ShowMines(mineCell);
    }

    private void ShowField()
    {
        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                if (_field[i][j] == FieldCell.None)
                {
                    OpenCell(i, j);
                }
            }
        }
    }

    private void ShowMines(FieldCell mineCell)
    {
        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                if (_isMinesSet[i][j])
                {
                    _field[i][j] = mineCell;
                }
            }
        }
    }

    private bool IsWin()
    {
        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                if (_field[i][j] == FieldCell.None && !_isMinesSet[i][j])
                {
                    return false;
                }
            }
        }

        return true;
    }

    private void GenerateRandomField()
    {
        int minesToSet = MinesCount;
        while (minesToSet > 0)
        {
            int row = Random.Shared.Next(Height);
            int col = Random.Shared.Next(Width);

            if (!_isMinesSet[row][col])
            {
                _isMinesSet[row][col] = true;
                minesToSet--;
            }
        }
    }
}
