namespace qx.wechat.Configs
{
    public interface IWxApp
    {
        string AppId { get; }
        string AppSecret { get; }
        string Host { get; }
        string HostReturnNotify { get; }
        string FrontHost { get; }
        string UrlAccessToken { get; }
        string UrlAuthorize { get; }
        string UrlRefreshToken { get; }
        string UrlUserinfo { get; }

   

    }
}