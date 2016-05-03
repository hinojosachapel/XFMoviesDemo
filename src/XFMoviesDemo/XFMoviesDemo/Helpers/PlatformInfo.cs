namespace XFMoviesDemo
{
    public class PlatformInfo : IPlatformInfo
    {
        public bool IsUWPDesktop { get; private set; }
        public bool IsUWPMobile { get; private set; }
        public bool IsWinPhone { get; private set; }
        public bool IsWinRT { get; private set; }

        public PlatformInfo(bool isUWPDesktop, bool isUWPMobile, bool isWinPhone, bool isWinRT)
        {
            IsUWPDesktop = isUWPDesktop;
            IsUWPMobile = isUWPMobile;
            IsWinPhone = isWinPhone;
            IsWinRT = isWinRT;
        }
    }
}
