namespace Phonestore.Classes
{
    public enum RamType : ushort
    {
        DDR3,
        LPDDR3,
        DDR4,
        LPDDR4,
        LPDDR4X,
        LPDDR5,
        UNKNOWN
    }

    public static class RamTypeNames
    {
        public static Dictionary<RamType, string> Names = new Dictionary<RamType, string>
        {
            { RamType.DDR3, "DDR3" },
            { RamType.LPDDR3, "LPDDR3" },
            { RamType.DDR4, "DDR4" },
            { RamType.LPDDR4, "LPDDR4" },
            { RamType.LPDDR4X, "LPDDR4X" },
            { RamType.LPDDR5, "LPDDR5" },
            { RamType.UNKNOWN, "Unknown" }
        };
    }
}