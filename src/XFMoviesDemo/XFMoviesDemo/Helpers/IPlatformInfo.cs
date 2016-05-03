namespace XFMoviesDemo
{
    // Sometimes Device.OS is not enough.
    // Though this project only uses IsUWPDesktop and IsWinRT, I leave the whole definition here
    // as a general solution.
    public interface IPlatformInfo
    {
        bool IsUWPDesktop { get; }
        bool IsUWPMobile { get; }
        bool IsWinPhone { get; }
        bool IsWinRT { get; }
    }
}
