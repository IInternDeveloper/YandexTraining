using System;


public class BishopsRooks {
    private string[] _board;
    private bool[,] _attackedCells;
    private int _boardSize;

    public BishopsRooks(string[] board, int boardSize) {
        _board = board;
        _attackedCells = new bool[boardSize, boardSize];
        _boardSize = boardSize;
    }

    public int UnattackedCount() {
        DetectAttackedCells();

        int unattackedCount = 0;
        for (int i = 0; i < _attackedCells.GetLength(0); ++i) {
            for (int j = 0; j < _attackedCells.GetLength(1); ++j) {
                if (!_attackedCells[i, j]) {
                    unattackedCount++;
                }
            }
        }

        return unattackedCount;
    }

    private void DetectAttackedCells() {
        for (int i = 0; i < _boardSize; ++i) {
            for (int j = 0; j < _boardSize; ++j) {
                if (_board[i][j] == 'B') {
                    AttackedByBishop(i, j);
                }
                if (_board[i][j] == 'R') {
                    AttackedByRook(i, j);
                }
            }
        }
    }

    private void AttackedByBishop(int i, int j) {
        _attackedCells[i, j] = true;

        Movement(i, j, -1, -1);
        Movement(i, j, 1, 1);
        Movement(i, j, -1, 1);
        Movement(i, j, 1, -1);
    }

    private void AttackedByRook(int i, int j) {
        _attackedCells[i, j] = true;

        Movement(i, j, 0, -1);
        Movement(i, j, 0, 1);
        Movement(i, j, -1, 0);
        Movement(i, j, 1, 0);
    }

    private void Movement(int i, int j, int ir, int jr) {
        for (int di = i + ir, dj = j + jr; Inside(di, dj); di += ir, dj += jr) {
            if (_board[di][dj] != '*') {
                break;
            }
            _attackedCells[di, dj] = true;
        }
    }

    private bool Inside(int i, int j) =>
        (i >= 0 && i < _boardSize) && (j >= 0 && j < _boardSize);
}

public class Program {
    static void Main(string[] args) {
        const int boardSize = 8;
        var board = new string[boardSize];
        for (int i = 0; i < boardSize; ++i) {
            board[i] = Console.ReadLine()[..8];
        }

        var bishopsRooks = new BishopsRooks(board, boardSize);

        Console.WriteLine(bishopsRooks.UnattackedCount());
    }
}