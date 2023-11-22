using NMM_Logic.Console.Classes;

namespace NMM_Logic.Console.Solvers;
internal class MovingTileSolver : BoardSolver
{
    internal override bool HasTriggeredRemovalPhase(BoardPosition currentPositions, BoardPosition destination) =>
        PossibleCombinations
            .Where(combinations => combinations.HasFlag(destination))
            .Select(matches => matches & (currentPositions | destination))
            .Any(matches => GetSetFlagCount((int)matches) == 3);

    internal override bool IsValidMove(BoardState boardState, BoardPosition destination)
    {
        throw new NotImplementedException();
    }

    internal override bool MoveTile(BoardState board, BoardPosition source, BoardPosition destination)
    {
        throw new NotImplementedException();
    }

    private static readonly BoardPosition[] PossibleCombinations =
        [
            BoardPosition.Upper_Top_Left | BoardPosition.Upper_Top_Middle | BoardPosition.Upper_Top_Right,
            BoardPosition.Upper_Mid_Left | BoardPosition.Upper_Mid_Middle | BoardPosition.Upper_Mid_Right,
            BoardPosition.Upper_Bottom_Left | BoardPosition.Upper_Bottom_Middle | BoardPosition.Upper_Bottom_Right,

            BoardPosition.Left_Mid_Far | BoardPosition.Left_Mid_Middle | BoardPosition.Left_Mid_Center,
            BoardPosition.Right_Mid_Far | BoardPosition.Right_Mid_Middle | BoardPosition.Right_Mid_Center,

            BoardPosition.Lower_Top_Left | BoardPosition.Lower_Top_Middle | BoardPosition.Lower_Top_Right,
            BoardPosition.Lower_Mid_Left | BoardPosition.Lower_Mid_Middle | BoardPosition.Lower_Mid_Right,
            BoardPosition.Lower_Bottom_Left | BoardPosition.Lower_Bottom_Middle | BoardPosition.Lower_Bottom_Right,

            BoardPosition.Upper_Top_Left | BoardPosition.Left_Mid_Far | BoardPosition.Lower_Bottom_Left,
            BoardPosition.Upper_Mid_Left | BoardPosition.Left_Mid_Middle | BoardPosition.Lower_Mid_Left,
            BoardPosition.Upper_Bottom_Left | BoardPosition.Left_Mid_Center | BoardPosition.Lower_Top_Left,

            BoardPosition.Upper_Top_Right | BoardPosition.Right_Mid_Far | BoardPosition.Lower_Bottom_Right,
            BoardPosition.Upper_Mid_Right | BoardPosition.Right_Mid_Middle | BoardPosition.Lower_Mid_Right,
            BoardPosition.Upper_Bottom_Right | BoardPosition.Right_Mid_Center | BoardPosition.Lower_Top_Right,

            BoardPosition.Upper_Top_Middle | BoardPosition.Upper_Mid_Middle | BoardPosition.Upper_Bottom_Middle,
            BoardPosition.Lower_Top_Middle | BoardPosition.Lower_Mid_Middle | BoardPosition.Lower_Bottom_Middle
        ];

    // Full Credit to this answer: https://stackoverflow.com/a/1333011
    // What an absolute fucking beast of a solve. Nice one mate, cheers
    private static int GetSetFlagCount(int lValue)
    {
        int iCount = 0;

        while (lValue != 0)
        {
            lValue &= (lValue - 1);
            iCount++;
        }

        return iCount;
    }
}
