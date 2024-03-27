using NMM_Logic.CLI.Classes;

namespace NMM_Logic.Classes;

public record Move(BoardPosition DestinationTile, BoardPosition? SourceTile = null);
