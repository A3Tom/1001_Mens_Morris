using NMM_Logic.CLI.Classes;
using NMM_Logic.CLI.Extensions;

namespace NMM_Logic.CLI.Solvers;
internal class MovingTileSolver : BoardSolver
{
    internal override bool HasTriggeredRemovalPhase(BoardPosition playerCurrentPositions, BoardPosition destination) =>
        PossibleCombinations
            .Where(combinations => combinations.HasFlag(destination))
            .Select(matches => matches & (playerCurrentPositions | destination))
            .Any(matches => ((int)matches).GetSetFlagCount() == 3);

    internal override bool IsValidMove(IDictionary<Player, BoardPosition> playerPositions, BoardPosition destination, BoardPosition? sourceTile)
    {
        return true;
    }

    internal override bool IsValidRemoval(BoardPosition opponentCurrentPositions, BoardPosition chosenTile)
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
}
