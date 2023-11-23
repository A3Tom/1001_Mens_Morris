namespace NMM_Logic.CLI.Extensions;
internal static class IntegerExtensions
{
    // Full Credit to this answer: https://stackoverflow.com/a/1333011
    // What an absolute fucking beast of a solve. Nice one mate, cheers
    public static int GetSetFlagCount(this int flagValue)
    {
        int flagsSetCount = 0;

        while (flagValue != 0)
        {
            flagValue &= flagValue - 1;
            flagsSetCount++;
        }

        return flagsSetCount;
    }
}
