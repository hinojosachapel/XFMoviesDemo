namespace XFMoviesDemo
{
    public interface IPlatformInfo
    {
        bool IsUWPDesktop { get; }
        bool IsUWPMobile { get; }
    }
}