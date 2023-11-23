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
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        OutputUpperTopLine(boardState.PlayerPositions);
        OutputUpperMidLine(boardState.PlayerPositions);
        OutputUpperBottomLine(boardState.PlayerPositions);
        OutputMiddleLine(boardState.PlayerPositions);
        OutputLowerTopLine(boardState.PlayerPositions);
        OutputLowerMidLine(boardState.PlayerPositions);
        OutputLowerBottomLine(boardState.PlayerPositions);
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
        Console.Write(" ---------  ");
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

    private static void OutputMiddleLine(IDictionary<Player, BoardPosition> positions)
    {
        OutputNumber(BoardPosition.Left_Mid_Far, positions);
        Console.Write("-- ");
        OutputNumber(BoardPosition.Left_Mid_Middle, positions);
        Console.Write("-- ");
        OutputNumber(BoardPosition.Left_Mid_Center, positions);
        Console.Write("            ");
        OutputNumber(BoardPosition.Right_Mid_Center, positions);
        Console.Write("-- ");
        OutputNumber(BoardPosition.Right_Mid_Middle, positions);
        Console.Write("-- ");
        OutputNumber(BoardPosition.Right_Mid_Far, positions);
        Console.WriteLine("\n|    |    |             |     |    |");
    }

    private static void OutputLowerTopLine(IDictionary<Player, BoardPosition> positions)
    {
        Console.Write("|    |    ");
        OutputNumber(BoardPosition.Lower_Top_Left, positions);
        Console.Write(" --- ");
        OutputNumber(BoardPosition.Lower_Top_Middle, positions);
        Console.Write(" --- ");
        OutputNumber(BoardPosition.Lower_Top_Right, positions);
        Console.Write("    |    |");
        Console.WriteLine("\n|    |           |            |    |");
    }

    private static void OutputLowerMidLine(IDictionary<Player, BoardPosition> positions)
    {
        Console.Write("|    ");
        OutputNumber(BoardPosition.Lower_Mid_Left, positions);
        Console.Write(" -------- ");
        OutputNumber(BoardPosition.Lower_Mid_Middle, positions);
        Console.Write(" -------- ");
        OutputNumber(BoardPosition.Lower_Mid_Right, positions);
        Console.Write("    |");
        Console.WriteLine("\n|                |                 |");
    }

    private static void OutputLowerBottomLine(IDictionary<Player, BoardPosition> positions)
    {
        OutputNumber(BoardPosition.Lower_Bottom_Left, positions);
        Console.Write(" ------------- ");
        OutputNumber(BoardPosition.Lower_Bottom_Middle, positions);
        Console.Write(" -------------- ");
        OutputNumber(BoardPosition.Lower_Bottom_Right, positions);
        Console.Write("\n");
    }

    private static void OutputNumber(BoardPosition boardPosition, IDictionary<Player, BoardPosition> positions)
    {
        var playerAtPosition = GetPlayerAtPosition(boardPosition, positions);
        var outputString = BuildOutputSymbol(boardPosition, playerAtPosition);

        _ = ToggleRelevantColourScheme(playerAtPosition);
        Console.Write(outputString);
        _ = ToggleWhitePlayerColours();
    }

    private static bool ToggleRelevantColourScheme(Player? playerAtPosition) => 
        playerAtPosition switch
        {
            Player.White => ToggleWhitePlayerColours(),
            Player.Black => ToggleBlackPlayerColours(),
            _ => ToggleUnoccupiedColours()
        };

    private static bool ToggleWhitePlayerColours()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Black;
        return true;
    }
    private static bool ToggleBlackPlayerColours()
    {
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.White;
        return true;
    }
    private static bool ToggleUnoccupiedColours()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.BackgroundColor = ConsoleColor.Black;
        return true;
    }

    private static string BuildOutputSymbol(BoardPosition boardPosition, Player? player) =>
        player switch
        {
            Player.White => "●",
            Player.Black => "●",
            _ => GetOutputNumberFromBoardPosition(boardPosition)
        };

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



