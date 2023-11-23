namespace NMM_Logic.CLI.Classes;
internal static class BoardPositionMap
{
    public static Dictionary<BoardPosition, byte[]> Coordinates = new()
    {
        { BoardPosition.Upper_Top_Left,         [7,1] },
        { BoardPosition.Upper_Top_Middle,       [7,4] },
        { BoardPosition.Upper_Top_Right,        [7,7] },

        { BoardPosition.Upper_Mid_Left,         [6,2] },
        { BoardPosition.Upper_Mid_Middle,       [6,4] },
        { BoardPosition.Upper_Mid_Right,        [6,6] },

        { BoardPosition.Upper_Bottom_Left,      [5,3] },
        { BoardPosition.Upper_Bottom_Middle,    [5,4] },
        { BoardPosition.Upper_Bottom_Right,     [5,5] },


        { BoardPosition.Left_Mid_Far,           [4,1] },
        { BoardPosition.Left_Mid_Middle,        [4,2] },
        { BoardPosition.Left_Mid_Center,        [4,3] },

        { BoardPosition.Right_Mid_Center,       [4,5] },
        { BoardPosition.Right_Mid_Middle,       [4,6] },
        { BoardPosition.Right_Mid_Far,          [4,7] },


        { BoardPosition.Lower_Top_Left,         [3,3] },
        { BoardPosition.Lower_Top_Middle,       [3,4] },
        { BoardPosition.Lower_Top_Right,        [3,5] },

        { BoardPosition.Lower_Mid_Left,         [2,2] },
        { BoardPosition.Lower_Mid_Middle,       [2,4] },
        { BoardPosition.Lower_Mid_Right,        [2,6] },

        { BoardPosition.Lower_Bottom_Left,      [1,1] },
        { BoardPosition.Lower_Bottom_Middle,    [1,4] },
        { BoardPosition.Lower_Bottom_Right,     [1,7] },
    };
}
