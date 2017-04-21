using System.Data.Entity;
using Qx.Wechat.Configs;


namespace Qx.Wechat.Entity
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
            : base(Setting.ConnectionString)
        {
        }
        public virtual DbSet<ImageMsg> ImageMsgs { get; set; }
        public virtual DbSet<LinkMsg> LinkMsgs { get; set; }
        public virtual DbSet<LocationEvent> LocationEvents { get; set; }
        public virtual DbSet<LocationMsg> LocationMsgs { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<MenuEvent> MenuEvents { get; set; }
        public virtual DbSet<NewsMsgItem> NewsMsgItems { get; set; }
        public virtual DbSet<ReplyImageMsg> ReplyImageMsgs { get; set; }
        public virtual DbSet<ReplyMsg> ReplyMsgs { get; set; }
        public virtual DbSet<ReplyMusicMsg> ReplyMusicMsgs { get; set; }
        public virtual DbSet<ReplyNewsMsg> ReplyNewsMsgs { get; set; }
        public virtual DbSet<ReplySetup> ReplySetups { get; set; }
        public virtual DbSet<ReplyTextMsg> ReplyTextMsgs { get; set; }
        public virtual DbSet<ReplyVideoMsg> ReplyVideoMsgs { get; set; }
        public virtual DbSet<ReplyVoiceMsg> ReplyVoiceMsgs { get; set; }
        public virtual DbSet<ShortVideoMsg> ShortVideoMsgs { get; set; }
        public virtual DbSet<SubscribeEvent> SubscribeEvents { get; set; }
        public virtual DbSet<SystemSetup> SystemSetups { get; set; }
        public virtual DbSet<TextMsg> TextMsgs { get; set; }
        public virtual DbSet<Token> Tokens { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<VideoMsg> VideoMsgs { get; set; }
        public virtual DbSet<VoiceMsg> VoiceMsgs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImageMsg>()
                .Property(e => e.MsgId)
                .IsUnicode(false);

            modelBuilder.Entity<ImageMsg>()
                .Property(e => e.ToUserName)
                .IsUnicode(false);

            modelBuilder.Entity<ImageMsg>()
                .Property(e => e.FromUserName)
                .IsUnicode(false);

            modelBuilder.Entity<ImageMsg>()
                .Property(e => e.CreateTime)
                .IsUnicode(false);

            modelBuilder.Entity<ImageMsg>()
                .Property(e => e.MsgType)
                .IsUnicode(false);

            modelBuilder.Entity<ImageMsg>()
                .Property(e => e.PicUrl)
                .IsUnicode(false);

            modelBuilder.Entity<ImageMsg>()
                .Property(e => e.MediaId)
                .IsUnicode(false);

            modelBuilder.Entity<LinkMsg>()
                .Property(e => e.MsgId)
                .IsUnicode(false);

            modelBuilder.Entity<LinkMsg>()
                .Property(e => e.ToUserName)
                .IsUnicode(false);

            modelBuilder.Entity<LinkMsg>()
                .Property(e => e.FromUserName)
                .IsUnicode(false);

            modelBuilder.Entity<LinkMsg>()
                .Property(e => e.CreateTime)
                .IsUnicode(false);

            modelBuilder.Entity<LinkMsg>()
                .Property(e => e.MsgType)
                .IsUnicode(false);

            modelBuilder.Entity<LinkMsg>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<LinkMsg>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<LinkMsg>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<LocationEvent>()
                .Property(e => e.EventId)
                .IsUnicode(false);

            modelBuilder.Entity<LocationEvent>()
                .Property(e => e.ToUserName)
                .IsUnicode(false);

            modelBuilder.Entity<LocationEvent>()
                .Property(e => e.FromUserName)
                .IsUnicode(false);

            modelBuilder.Entity<LocationEvent>()
                .Property(e => e.CreateTime)
                .IsUnicode(false);

            modelBuilder.Entity<LocationEvent>()
                .Property(e => e.MsgType)
                .IsUnicode(false);

            modelBuilder.Entity<LocationEvent>()
                .Property(e => e.Event)
                .IsUnicode(false);

            modelBuilder.Entity<LocationEvent>()
                .Property(e => e.Latitude)
                .IsUnicode(false);

            modelBuilder.Entity<LocationEvent>()
                .Property(e => e.Longitude)
                .IsUnicode(false);

            modelBuilder.Entity<LocationEvent>()
                .Property(e => e.Precision)
                .IsUnicode(false);

            modelBuilder.Entity<LocationMsg>()
                .Property(e => e.MsgId)
                .IsUnicode(false);

            modelBuilder.Entity<LocationMsg>()
                .Property(e => e.ToUserName)
                .IsUnicode(false);

            modelBuilder.Entity<LocationMsg>()
                .Property(e => e.FromUserName)
                .IsUnicode(false);

            modelBuilder.Entity<LocationMsg>()
                .Property(e => e.CreateTime)
                .IsUnicode(false);

            modelBuilder.Entity<LocationMsg>()
                .Property(e => e.MsgType)
                .IsUnicode(false);

            modelBuilder.Entity<LocationMsg>()
                .Property(e => e.Location_X)
                .IsUnicode(false);

            modelBuilder.Entity<LocationMsg>()
                .Property(e => e.Location_Y)
                .IsUnicode(false);

            modelBuilder.Entity<LocationMsg>()
                .Property(e => e.Scale)
                .IsUnicode(false);

            modelBuilder.Entity<LocationMsg>()
                .Property(e => e.Label)
                .IsUnicode(false);

            modelBuilder.Entity<Log>()
                .Property(e => e.LogId)
                .IsUnicode(false);

            modelBuilder.Entity<Log>()
                .Property(e => e.Contents)
                .IsUnicode(false);

            modelBuilder.Entity<MenuEvent>()
                .Property(e => e.EventId)
                .IsUnicode(false);

            modelBuilder.Entity<MenuEvent>()
                .Property(e => e.ToUserName)
                .IsUnicode(false);

            modelBuilder.Entity<MenuEvent>()
                .Property(e => e.FromUserName)
                .IsUnicode(false);

            modelBuilder.Entity<MenuEvent>()
                .Property(e => e.CreateTime)
                .IsUnicode(false);

            modelBuilder.Entity<MenuEvent>()
                .Property(e => e.MsgType)
                .IsUnicode(false);

            modelBuilder.Entity<MenuEvent>()
                .Property(e => e.Event)
                .IsUnicode(false);

            modelBuilder.Entity<MenuEvent>()
                .Property(e => e.EventKey)
                .IsUnicode(false);

            modelBuilder.Entity<NewsMsgItem>()
                .Property(e => e.NewsMsgItemId)
                .IsUnicode(false);

            modelBuilder.Entity<NewsMsgItem>()
                .Property(e => e.ReplyMsgId)
                .IsUnicode(false);

            modelBuilder.Entity<NewsMsgItem>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<NewsMsgItem>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<NewsMsgItem>()
                .Property(e => e.PicUrl)
                .IsUnicode(false);

            modelBuilder.Entity<NewsMsgItem>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyImageMsg>()
                .Property(e => e.ReplyMsgId)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyImageMsg>()
                .Property(e => e.MediaId)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyImageMsg>()
                .HasOptional(e => e.ReplyMsg)
                .WithRequired(e => e.ReplyImageMsg)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ReplyMsg>()
                .Property(e => e.ReplyMsgId)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyMsg>()
                .Property(e => e.ToUserName)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyMsg>()
                .Property(e => e.FromUserName)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyMsg>()
                .Property(e => e.CreateTime)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyMsg>()
                .Property(e => e.MsgType)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyMusicMsg>()
                .Property(e => e.ReplyMsgId)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyMusicMsg>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyMusicMsg>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyMusicMsg>()
                .Property(e => e.MusicURL)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyMusicMsg>()
                .Property(e => e.HQMusicUrl)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyMusicMsg>()
                .Property(e => e.ThumbMediaId)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyMusicMsg>()
                .HasOptional(e => e.ReplyMsg)
                .WithRequired(e => e.ReplyMusicMsg)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ReplyNewsMsg>()
                .Property(e => e.ReplyMsgId)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyNewsMsg>()
                .HasMany(e => e.NewsMsgItems)
                .WithOptional(e => e.ReplyNewsMsg)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ReplyNewsMsg>()
                .HasOptional(e => e.ReplyMsg)
                .WithRequired(e => e.ReplyNewsMsg)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ReplySetup>()
                .Property(e => e.ReplySetupId)
                .IsUnicode(false);

            modelBuilder.Entity<ReplySetup>()
                .Property(e => e.KeyWord)
                .IsUnicode(false);

            modelBuilder.Entity<ReplySetup>()
                .Property(e => e.ReplyMsgId)
                .IsUnicode(false);

            modelBuilder.Entity<ReplySetup>()
                .Property(e => e.ReplyTypeId)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyTextMsg>()
                .Property(e => e.ReplyMsgId)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyTextMsg>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyTextMsg>()
                .HasOptional(e => e.ReplyMsg)
                .WithRequired(e => e.ReplyTextMsg)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ReplyVideoMsg>()
                .Property(e => e.ReplyMsgId)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyVideoMsg>()
                .Property(e => e.MediaId)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyVideoMsg>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyVideoMsg>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyVideoMsg>()
                .HasOptional(e => e.ReplyMsg)
                .WithRequired(e => e.ReplyVideoMsg)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ReplyVoiceMsg>()
                .Property(e => e.ReplyMsgId)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyVoiceMsg>()
                .Property(e => e.MediaId)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyVoiceMsg>()
                .HasOptional(e => e.ReplyMsg)
                .WithRequired(e => e.ReplyVoiceMsg)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ShortVideoMsg>()
                .Property(e => e.MsgId)
                .IsUnicode(false);

            modelBuilder.Entity<ShortVideoMsg>()
                .Property(e => e.ToUserName)
                .IsUnicode(false);

            modelBuilder.Entity<ShortVideoMsg>()
                .Property(e => e.FromUserName)
                .IsUnicode(false);

            modelBuilder.Entity<ShortVideoMsg>()
                .Property(e => e.CreateTime)
                .IsUnicode(false);

            modelBuilder.Entity<ShortVideoMsg>()
                .Property(e => e.MsgType)
                .IsUnicode(false);

            modelBuilder.Entity<ShortVideoMsg>()
                .Property(e => e.MediaId)
                .IsUnicode(false);

            modelBuilder.Entity<ShortVideoMsg>()
                .Property(e => e.ThumbMediaId)
                .IsUnicode(false);

            modelBuilder.Entity<SubscribeEvent>()
                .Property(e => e.EventId)
                .IsUnicode(false);

            modelBuilder.Entity<SubscribeEvent>()
                .Property(e => e.ToUserName)
                .IsUnicode(false);

            modelBuilder.Entity<SubscribeEvent>()
                .Property(e => e.FromUserName)
                .IsUnicode(false);

            modelBuilder.Entity<SubscribeEvent>()
                .Property(e => e.CreateTime)
                .IsUnicode(false);

            modelBuilder.Entity<SubscribeEvent>()
                .Property(e => e.MsgType)
                .IsUnicode(false);

            modelBuilder.Entity<SubscribeEvent>()
                .Property(e => e.Event)
                .IsUnicode(false);

            modelBuilder.Entity<SubscribeEvent>()
                .Property(e => e.EventKey)
                .IsUnicode(false);

            modelBuilder.Entity<SubscribeEvent>()
                .Property(e => e.Ticket)
                .IsUnicode(false);

            modelBuilder.Entity<SystemSetup>()
                .Property(e => e.WECHAT_HOST)
                .IsUnicode(false);

            modelBuilder.Entity<SystemSetup>()
                .Property(e => e.APP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SystemSetup>()
                .Property(e => e.APP_SECRET)
                .IsUnicode(false);

            modelBuilder.Entity<TextMsg>()
                .Property(e => e.MsgId)
                .IsUnicode(false);

            modelBuilder.Entity<TextMsg>()
                .Property(e => e.ToUserName)
                .IsUnicode(false);

            modelBuilder.Entity<TextMsg>()
                .Property(e => e.FromUserName)
                .IsUnicode(false);

            modelBuilder.Entity<TextMsg>()
                .Property(e => e.CreateTime)
                .IsUnicode(false);

            modelBuilder.Entity<TextMsg>()
                .Property(e => e.MsgType)
                .IsUnicode(false);

            modelBuilder.Entity<TextMsg>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<Token>()
                .Property(e => e.TokenId)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.OpenID)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Sex)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.IDCardNo)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.StuNo)
                .IsUnicode(false);

            modelBuilder.Entity<VideoMsg>()
                .Property(e => e.MsgId)
                .IsUnicode(false);

            modelBuilder.Entity<VideoMsg>()
                .Property(e => e.ToUserName)
                .IsUnicode(false);

            modelBuilder.Entity<VideoMsg>()
                .Property(e => e.FromUserName)
                .IsUnicode(false);

            modelBuilder.Entity<VideoMsg>()
                .Property(e => e.CreateTime)
                .IsUnicode(false);

            modelBuilder.Entity<VideoMsg>()
                .Property(e => e.MsgType)
                .IsUnicode(false);

            modelBuilder.Entity<VideoMsg>()
                .Property(e => e.MediaId)
                .IsUnicode(false);

            modelBuilder.Entity<VideoMsg>()
                .Property(e => e.ThumbMediaId)
                .IsUnicode(false);

            modelBuilder.Entity<VoiceMsg>()
                .Property(e => e.MsgId)
                .IsUnicode(false);

            modelBuilder.Entity<VoiceMsg>()
                .Property(e => e.ToUserName)
                .IsUnicode(false);

            modelBuilder.Entity<VoiceMsg>()
                .Property(e => e.FromUserName)
                .IsUnicode(false);

            modelBuilder.Entity<VoiceMsg>()
                .Property(e => e.CreateTime)
                .IsUnicode(false);

            modelBuilder.Entity<VoiceMsg>()
                .Property(e => e.MsgType)
                .IsUnicode(false);

            modelBuilder.Entity<VoiceMsg>()
                .Property(e => e.MediaId)
                .IsUnicode(false);

            modelBuilder.Entity<VoiceMsg>()
                .Property(e => e.Format)
                .IsUnicode(false);
        }
    }
}
