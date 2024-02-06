namespace NMM_Logic.CLI.Classes;

[Flags]
public enum BoardPosition
{
    None = 0,

    Upper_Top_Left = 1,
    Upper_Top_Middle = 2,
    Upper_Top_Right = 4,

    Upper_Mid_Left = 8,
    Upper_Mid_Middle = 16,
    Upper_Mid_Right = 32,

    Upper_Bottom_Left = 64,
    Upper_Bottom_Middle = 128,
    Upper_Bottom_Right = 256,

    Left_Mid_Far = 512,
    Left_Mid_Middle = 1024,
    Left_Mid_Center = 2048,

    Right_Mid_Center = 4096,
    Right_Mid_Middle = 8192,
    Right_Mid_Far = 16384,

    Lower_Top_Left = 32768,
    Lower_Top_Middle = 65536,
    Lower_Top_Right = 131072,

    Lower_Mid_Left = 262144,
    Lower_Mid_Middle = 524288,
    Lower_Mid_Right = 1048576,

    Lower_Bottom_Left = 2097152,
    Lower_Bottom_Middle = 4194304,
    Lower_Bottom_Right = 8388608
}
