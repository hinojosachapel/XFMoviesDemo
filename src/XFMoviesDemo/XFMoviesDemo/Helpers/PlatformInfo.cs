namespace XFMoviesDemo
{
    public class PlatformInfo : IPlatformInfo
    {
        public bool IsUWPDesktop { get; private set; }
        public bool IsUWPMobile { get; private set; }

        public PlatformInfo(bool isUWPDesktop, bool isUWPMobile)
        {
            IsUWPDesktop = isUWPDesktop;
            IsUWPMobile = isUWPMobile;
        }
    }
}
