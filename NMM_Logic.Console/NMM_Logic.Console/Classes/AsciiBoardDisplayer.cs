/*
 
1 -------------- 2 --------------- 3
|                |                 |
|    4  -------- 5  --------- 6    |
|    |           |            |    |
|    |    7 ---- 8 ---- 9     |    |
|    |    |             |     |    |
10-- 11-- 12            13-- 14-- 15
|    |    |             |     |    |
|    |    16 --- 17 --- 18    |    |
|    |           |            |    |
|    19 -------- 20 -------- 21    |
|                |                 |
22 ------------- 23 -------------- 24

*/

namespace NMM_Logic.CLI.Classes;

internal static class AsciiBoardDisplayer
{
    public static void OutputToCLI(BoardState boardState)
    {
        OutputUpperTopLine(boardState.PlayerPositions);
        OutputUpperMidLine(boardState.PlayerPositions);
        OutputUpperBottomLine(boardState.PlayerPositions);
    }

    private static void OutputUpperTopLine(IDictionary<Player, BoardPosition> positions)
    {
        OutputNumber(BoardPosition.Upper_Top_Left, positions);
        Console.Write(" -------------- ");
        OutputNumber(BoardPosition.Upper_Top_Middle, positions);
        Console.Write(" --------------- ");
        OutputNumber(BoardPosition.Upper_Top_Right, positions);
        Console.WriteLine("\n|                |                 |");
    }

    private static void OutputUpperMidLine(IDictionary<Player, BoardPosition> positions)
    {
        Console.Write("|    ");
        OutputNumber(BoardPosition.Upper_Mid_Left, positions);
        Console.Write("  -------- ");
        OutputNumber(BoardPosition.Upper_Mid_Middle, positions);
        Console.Write("  --------- ");
        OutputNumber(BoardPosition.Upper_Mid_Right, positions);
        Console.Write("    |");
        Console.WriteLine("\n|    |           |            |    |");
    }

    private static void OutputUpperBottomLine(IDictionary<Player, BoardPosition> positions)
    {
        Console.Write("|    |    ");
        OutputNumber(BoardPosition.Upper_Bottom_Left, positions);
        Console.Write(" ---- ");
        OutputNumber(BoardPosition.Upper_Bottom_Middle, positions);
        Console.Write(" ---- ");
        OutputNumber(BoardPosition.Upper_Bottom_Right, positions);
        Console.Write("     |    |");
        Console.WriteLine("\n|    |    |             |     |    |");
    }

    private static void OutputNumber(BoardPosition boardPosition, IDictionary<Player, BoardPosition> positions)
    {
        var outputString = GetOutputNumberFromBoardPosition(boardPosition);
        var playerAtPosition = GetPlayerAtPosition(boardPosition, positions);

        _ = playerAtPosition switch
        {
            Player.White => ToggleWhiteOnBlack(),
            Player.Black => ToggleBlackOnWhite(),
            _ => ToggleBlueOnBlack()
        };
            
        Console.Write(outputString);
        ToggleWhiteOnBlack();
    }

    private static bool ToggleWhiteOnBlack()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Black;
        return true;
    }
    private static bool ToggleBlackOnWhite()
    {
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.White;
        return true;
    }
    private static bool ToggleBlueOnBlack()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.BackgroundColor = ConsoleColor.Black;
        return true;
    }

    // Look... I know this excessive, inefficient and generally stupid but I am on a binary vibe the now
    private static string GetOutputNumberFromBoardPosition(BoardPosition boardPosition) =>
        (32 - Convert.ToString((int)boardPosition, 2).PadLeft(32, '0').IndexOf('1')).ToString();

    private static Player? GetPlayerAtPosition(BoardPosition position, IDictionary<Player, BoardPosition> positions) =>
        (positions[Player.White] & position) == position 
            ? Player.White
            : (positions[Player.Black] & position) == position 
            ? Player.Black
            : null;
}



