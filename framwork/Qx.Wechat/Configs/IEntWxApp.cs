namespace qx.wechat.Configs
{
    public interface IEntWxApp
    {
        string AppId { get; }
        string AppSecret { get; }
        string Host { get; }
        string FrontHost { get; }
    }
}