using System;


public class ChessBoard {
    private static readonly Cell[] _shifts = new Cell[] {
            new Cell(0, -1), new Cell(0, 1), new Cell(-1, 0), new Cell(1, 0)
        };

    private bool[,] _board;

    private const int _boardSize = 10;

    private Cell[] _figure;

    public ChessBoard(Cell[] figure) {
        _board = new bool[_boardSize, _boardSize];
        _figure = figure;
    }

    public int GetFigurePerimeter() {
        CutOutFigure();

        int perimeter = 0;
        foreach (var cell in _figure) {
            foreach (var shift in _shifts) {
                if (!_board[cell.X + shift.X, cell.Y + shift.Y]) {
                    perimeter++;
                }
            }
        }

        return perimeter;
    }

    private void CutOutFigure() {
        foreach (var cell in _figure) {
            _board[cell.X, cell.Y] = true;
        }
    }
}

public struct Cell {
    public int X { get; set; }

    public int Y { get; set; }

    public Cell(int X, int Y) =>
        (this.X, this.Y) = (X, Y);

    public Cell(int[] cell) =>
        (this.X, this.Y) = (cell[0], cell[1]);
}

public class Program {
    static int[] Input() =>
        Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

    static void Main(string[] args) {
        int cellsCount = int.Parse(Console.ReadLine());
        var figure = new Cell[cellsCount];

        for (int i = 0; i < cellsCount; ++i) {
            figure[i] = new Cell(Input());
        }

        var chessBoard = new ChessBoard(figure);

        Console.WriteLine(chessBoard.GetFigurePerimeter());
    }
}