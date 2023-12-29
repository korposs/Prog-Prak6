namespace Phonestore.Classes
{

    public enum OsType : ushort
    {
        ANDROID,
        IOS,
        WINDOWS_MOBILE,
        GRAPHENE_OS,
        UNKNOWN
    }

    public static class OsTypeNames
    {
        public static Dictionary<OsType, string> Names = new Dictionary<OsType, string>
        {
            { OsType.ANDROID, "Android" },
            { OsType.IOS, "iOS" },
            { OsType.WINDOWS_MOBILE, "Windows Mobile" },
            { OsType.GRAPHENE_OS, "Graphene OS" },
            { OsType.UNKNOWN, "Unknown" }
        };
    }
}