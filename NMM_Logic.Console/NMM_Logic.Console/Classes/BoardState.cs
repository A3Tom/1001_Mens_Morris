namespace NMM_Logic.Console.Classes;

// This is mad verbose, I needed to get this down first so I could visualise flags properly
internal class BoardState
{
    public byte[][] Board = GenerateFreshBoard();

    public byte[] UpperTopRow => Board[0];
    public byte[] UpperMidRow => Board[1];
    public byte[] UpperBottomRow => Board[2];

    public byte[] MidLeftRow => Board[3];
    public byte[] MidRightRow => Board[4];

    public byte[] LowerTopRow => Board[5];
    public byte[] LowerMidRow => Board[6];
    public byte[] LowerBottomRow => Board[7];

    public byte[] LeftFarColumn => [UpperTopRow[0], MidLeftRow[0], LowerBottomRow[0]];
    public byte[] LeftMidColumn => [UpperMidRow[0], MidLeftRow[1], LowerMidRow[0]];
    public byte[] LeftNearColumn => [UpperBottomRow[0], MidLeftRow[2], LowerTopRow[0]];

    public byte[] UpperMidColumn => [UpperTopRow[1], UpperMidRow[1], UpperBottomRow[1]];
    public byte[] LowerMidColumn => [LowerTopRow[1], LowerMidRow[1], LowerBottomRow[1]];

    public byte[] RightFarColumn => [UpperTopRow[2], MidRightRow[2], LowerBottomRow[2]];
    public byte[] RightMidColumn => [UpperMidRow[2], MidRightRow[1], LowerMidRow[2]];
    public byte[] RightNearColumn => [UpperBottomRow[2], MidRightRow[2], LowerTopRow[2]];

    private static byte[][] GenerateFreshBoard() =>
    [
        [0, 0, 0],
        [0, 0, 0],
        [0, 0, 0],
        [0, 0, 0],
        [0, 0, 0],
        [0, 0, 0],
        [0, 0, 0],
        [0, 0, 0]
    ];
}
