

using Microsoft.EntityFrameworkCore;
using Qx.Tools;

namespace qx.wechat.Entity
{
    public partial class MyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(DbUtility.SqlSeverConnString("qx.wechat"));
        }
        public virtual DbSet<ImageMsgs> ImageMsgs { get; set; }
        public virtual DbSet<LinkMsgs> LinkMsgs { get; set; }
        public virtual DbSet<LocationEvents> LocationEvents { get; set; }
        public virtual DbSet<LocationMsgs> LocationMsgs { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<MenuEvents> MenuEvents { get; set; }
        public virtual DbSet<NewsMsgItems> NewsMsgItems { get; set; }
        public virtual DbSet<reply_template_msg> reply_template_msg { get; set; }
        public virtual DbSet<ReplyImageMsgs> ReplyImageMsgs { get; set; }
        public virtual DbSet<ReplyMsgs> ReplyMsgs { get; set; }
        public virtual DbSet<ReplyMusicMsgs> ReplyMusicMsgs { get; set; }
        public virtual DbSet<ReplyNewsMsgs> ReplyNewsMsgs { get; set; }
        public virtual DbSet<ReplySetups> ReplySetups { get; set; }
        public virtual DbSet<ReplyTextMsgs> ReplyTextMsgs { get; set; }
        public virtual DbSet<ReplyVideoMsgs> ReplyVideoMsgs { get; set; }
        public virtual DbSet<ReplyVoiceMsgs> ReplyVoiceMsgs { get; set; }
        public virtual DbSet<ShortVideoMsgs> ShortVideoMsgs { get; set; }
        public virtual DbSet<SubscribeEvents> SubscribeEvents { get; set; }
        public virtual DbSet<SystemSetups> SystemSetups { get; set; }
        public virtual DbSet<template> template { get; set; }
        public virtual DbSet<template_type> template_type { get; set; }
        public virtual DbSet<templatedata> templatedata { get; set; }
        public virtual DbSet<TextMsgs> TextMsgs { get; set; }
        public virtual DbSet<Tokens> Tokens { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<VideoMsgs> VideoMsgs { get; set; }
        public virtual DbSet<VoiceMsgs> VoiceMsgs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImageMsgs>()
                .Property(e => e.MsgId)
                .IsUnicode(false);

            modelBuilder.Entity<ImageMsgs>()
                .Property(e => e.ToUserName)
                .IsUnicode(false);

            modelBuilder.Entity<ImageMsgs>()
                .Property(e => e.FromUserName)
                .IsUnicode(false);

            modelBuilder.Entity<ImageMsgs>()
                .Property(e => e.CreateTime)
                .IsUnicode(false);

            modelBuilder.Entity<ImageMsgs>()
                .Property(e => e.MsgType)
                .IsUnicode(false);

            modelBuilder.Entity<ImageMsgs>()
                .Property(e => e.PicUrl)
                .IsUnicode(false);

            modelBuilder.Entity<ImageMsgs>()
                .Property(e => e.MediaId)
                .IsUnicode(false);

            modelBuilder.Entity<LinkMsgs>()
                .Property(e => e.MsgId)
                .IsUnicode(false);

            modelBuilder.Entity<LinkMsgs>()
                .Property(e => e.ToUserName)
                .IsUnicode(false);

            modelBuilder.Entity<LinkMsgs>()
                .Property(e => e.FromUserName)
                .IsUnicode(false);

            modelBuilder.Entity<LinkMsgs>()
                .Property(e => e.CreateTime)
                .IsUnicode(false);

            modelBuilder.Entity<LinkMsgs>()
                .Property(e => e.MsgType)
                .IsUnicode(false);

            modelBuilder.Entity<LinkMsgs>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<LinkMsgs>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<LinkMsgs>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<LocationEvents>()
                .Property(e => e.EventId)
                .IsUnicode(false);

            modelBuilder.Entity<LocationEvents>()
                .Property(e => e.ToUserName)
                .IsUnicode(false);

            modelBuilder.Entity<LocationEvents>()
                .Property(e => e.FromUserName)
                .IsUnicode(false);

            modelBuilder.Entity<LocationEvents>()
                .Property(e => e.CreateTime)
                .IsUnicode(false);

            modelBuilder.Entity<LocationEvents>()
                .Property(e => e.MsgType)
                .IsUnicode(false);

            modelBuilder.Entity<LocationEvents>()
                .Property(e => e.Event)
                .IsUnicode(false);

            modelBuilder.Entity<LocationEvents>()
                .Property(e => e.Latitude)
                .IsUnicode(false);

            modelBuilder.Entity<LocationEvents>()
                .Property(e => e.Longitude)
                .IsUnicode(false);

            modelBuilder.Entity<LocationEvents>()
                .Property(e => e.Precision)
                .IsUnicode(false);

            modelBuilder.Entity<LocationMsgs>()
                .Property(e => e.MsgId)
                .IsUnicode(false);

            modelBuilder.Entity<LocationMsgs>()
                .Property(e => e.ToUserName)
                .IsUnicode(false);

            modelBuilder.Entity<LocationMsgs>()
                .Property(e => e.FromUserName)
                .IsUnicode(false);

            modelBuilder.Entity<LocationMsgs>()
                .Property(e => e.CreateTime)
                .IsUnicode(false);

            modelBuilder.Entity<LocationMsgs>()
                .Property(e => e.MsgType)
                .IsUnicode(false);

            modelBuilder.Entity<LocationMsgs>()
                .Property(e => e.Location_X)
                .IsUnicode(false);

            modelBuilder.Entity<LocationMsgs>()
                .Property(e => e.Location_Y)
                .IsUnicode(false);

            modelBuilder.Entity<LocationMsgs>()
                .Property(e => e.Scale)
                .IsUnicode(false);

            modelBuilder.Entity<LocationMsgs>()
                .Property(e => e.Label)
                .IsUnicode(false);

            modelBuilder.Entity<Logs>()
                .Property(e => e.LogId)
                .IsUnicode(false);

            modelBuilder.Entity<Logs>()
                .Property(e => e.Contents)
                .IsUnicode(false);

            modelBuilder.Entity<MenuEvents>()
                .Property(e => e.EventId)
                .IsUnicode(false);

            modelBuilder.Entity<MenuEvents>()
                .Property(e => e.ToUserName)
                .IsUnicode(false);

            modelBuilder.Entity<MenuEvents>()
                .Property(e => e.FromUserName)
                .IsUnicode(false);

            modelBuilder.Entity<MenuEvents>()
                .Property(e => e.CreateTime)
                .IsUnicode(false);

            modelBuilder.Entity<MenuEvents>()
                .Property(e => e.MsgType)
                .IsUnicode(false);

            modelBuilder.Entity<MenuEvents>()
                .Property(e => e.Event)
                .IsUnicode(false);

            modelBuilder.Entity<MenuEvents>()
                .Property(e => e.EventKey)
                .IsUnicode(false);

            modelBuilder.Entity<NewsMsgItems>()
                .Property(e => e.NewsMsgItemId)
                .IsUnicode(false);

            modelBuilder.Entity<NewsMsgItems>()
                .Property(e => e.ReplyMsgId)
                .IsUnicode(false);

            modelBuilder.Entity<NewsMsgItems>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<NewsMsgItems>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<NewsMsgItems>()
                .Property(e => e.PicUrl)
                .IsUnicode(false);

            modelBuilder.Entity<NewsMsgItems>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<reply_template_msg>()
                .Property(e => e.ReplyMsgId)
                .IsUnicode(false);

            modelBuilder.Entity<reply_template_msg>()
                .Property(e => e.TemplateId)
                .IsUnicode(false);

            modelBuilder.Entity<reply_template_msg>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyImageMsgs>()
                .Property(e => e.ReplyMsgId)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyImageMsgs>()
                .Property(e => e.MediaId)
                .IsUnicode(false);

  

            modelBuilder.Entity<ReplyMsgs>()
                .Property(e => e.ReplyMsgId)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyMsgs>()
                .Property(e => e.ToUserName)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyMsgs>()
                .Property(e => e.FromUserName)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyMsgs>()
                .Property(e => e.CreateTime)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyMsgs>()
                .Property(e => e.MsgType)
                .IsUnicode(false);

    

            modelBuilder.Entity<ReplyMusicMsgs>()
                .Property(e => e.ReplyMsgId)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyMusicMsgs>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyMusicMsgs>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyMusicMsgs>()
                .Property(e => e.MusicURL)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyMusicMsgs>()
                .Property(e => e.HQMusicUrl)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyMusicMsgs>()
                .Property(e => e.ThumbMediaId)
                .IsUnicode(false);

         

            modelBuilder.Entity<ReplyNewsMsgs>()
                .Property(e => e.ReplyMsgId)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyNewsMsgs>()
                .HasMany(e => e.NewsMsgItems);


     

            modelBuilder.Entity<ReplySetups>()
                .Property(e => e.ReplySetupId)
                .IsUnicode(false);

            modelBuilder.Entity<ReplySetups>()
                .Property(e => e.KeyWord)
                .IsUnicode(false);

            modelBuilder.Entity<ReplySetups>()
                .Property(e => e.ReplyMsgId)
                .IsUnicode(false);

            modelBuilder.Entity<ReplySetups>()
                .Property(e => e.ReplyTypeId)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyTextMsgs>()
                .Property(e => e.ReplyMsgId)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyTextMsgs>()
                .Property(e => e.Content)
                .IsUnicode(false);

         

            modelBuilder.Entity<ReplyVideoMsgs>()
                .Property(e => e.ReplyMsgId)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyVideoMsgs>()
                .Property(e => e.MediaId)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyVideoMsgs>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyVideoMsgs>()
                .Property(e => e.Description)
                .IsUnicode(false);

          

            modelBuilder.Entity<ReplyVoiceMsgs>()
                .Property(e => e.ReplyMsgId)
                .IsUnicode(false);

            modelBuilder.Entity<ReplyVoiceMsgs>()
                .Property(e => e.MediaId)
                .IsUnicode(false);

          

            modelBuilder.Entity<ShortVideoMsgs>()
                .Property(e => e.MsgId)
                .IsUnicode(false);

            modelBuilder.Entity<ShortVideoMsgs>()
                .Property(e => e.ToUserName)
                .IsUnicode(false);

            modelBuilder.Entity<ShortVideoMsgs>()
                .Property(e => e.FromUserName)
                .IsUnicode(false);

            modelBuilder.Entity<ShortVideoMsgs>()
                .Property(e => e.CreateTime)
                .IsUnicode(false);

            modelBuilder.Entity<ShortVideoMsgs>()
                .Property(e => e.MsgType)
                .IsUnicode(false);

            modelBuilder.Entity<ShortVideoMsgs>()
                .Property(e => e.MediaId)
                .IsUnicode(false);

            modelBuilder.Entity<ShortVideoMsgs>()
                .Property(e => e.ThumbMediaId)
                .IsUnicode(false);

            modelBuilder.Entity<SubscribeEvents>()
                .Property(e => e.EventId)
                .IsUnicode(false);

            modelBuilder.Entity<SubscribeEvents>()
                .Property(e => e.ToUserName)
                .IsUnicode(false);

            modelBuilder.Entity<SubscribeEvents>()
                .Property(e => e.FromUserName)
                .IsUnicode(false);

            modelBuilder.Entity<SubscribeEvents>()
                .Property(e => e.CreateTime)
                .IsUnicode(false);

            modelBuilder.Entity<SubscribeEvents>()
                .Property(e => e.MsgType)
                .IsUnicode(false);

            modelBuilder.Entity<SubscribeEvents>()
                .Property(e => e.Event)
                .IsUnicode(false);

            modelBuilder.Entity<SubscribeEvents>()
                .Property(e => e.EventKey)
                .IsUnicode(false);

            modelBuilder.Entity<SubscribeEvents>()
                .Property(e => e.Ticket)
                .IsUnicode(false);

            modelBuilder.Entity<SystemSetups>()
                .Property(e => e.APP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SystemSetups>()
                .Property(e => e.WECHAT_HOST)
                .IsUnicode(false);

            modelBuilder.Entity<SystemSetups>()
                .Property(e => e.APP_SECRET)
                .IsUnicode(false);

            modelBuilder.Entity<template>()
                .Property(e => e.TemplateID)
                .IsUnicode(false);

            modelBuilder.Entity<template>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<template>()
                .Property(e => e.TemplateTypeID)
                .IsUnicode(false);

            modelBuilder.Entity<template>()
                .Property(e => e.Contents)
                .IsUnicode(false);

            modelBuilder.Entity<template>()
                .Property(e => e.Example)
                .IsUnicode(false);

           

            modelBuilder.Entity<template_type>()
                .Property(e => e.TemplateTypeID)
                .IsUnicode(false);

            modelBuilder.Entity<template_type>()
                .Property(e => e.Name)
                .IsUnicode(false);

           

            modelBuilder.Entity<templatedata>()
                .Property(e => e.TemplatedataID)
                .IsUnicode(false);

            modelBuilder.Entity<templatedata>()
                .Property(e => e.TemplateID)
                .IsUnicode(false);

            modelBuilder.Entity<templatedata>()
                .Property(e => e.Value)
                .IsUnicode(false);

            modelBuilder.Entity<templatedata>()
                .Property(e => e.Color)
                .IsUnicode(false);

            modelBuilder.Entity<TextMsgs>()
                .Property(e => e.MsgId)
                .IsUnicode(false);

            modelBuilder.Entity<TextMsgs>()
                .Property(e => e.ToUserName)
                .IsUnicode(false);

            modelBuilder.Entity<TextMsgs>()
                .Property(e => e.FromUserName)
                .IsUnicode(false);

            modelBuilder.Entity<TextMsgs>()
                .Property(e => e.CreateTime)
                .IsUnicode(false);

            modelBuilder.Entity<TextMsgs>()
                .Property(e => e.MsgType)
                .IsUnicode(false);

            modelBuilder.Entity<TextMsgs>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<Tokens>()
                .Property(e => e.TokenId)
                .IsUnicode(false);

            modelBuilder.Entity<Tokens>()
                .Property(e => e.APP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<Tokens>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.OpenID)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Sex)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.IDCardNo)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.StuNo)
                .IsUnicode(false);

            modelBuilder.Entity<VideoMsgs>()
                .Property(e => e.MsgId)
                .IsUnicode(false);

            modelBuilder.Entity<VideoMsgs>()
                .Property(e => e.ToUserName)
                .IsUnicode(false);

            modelBuilder.Entity<VideoMsgs>()
                .Property(e => e.FromUserName)
                .IsUnicode(false);

            modelBuilder.Entity<VideoMsgs>()
                .Property(e => e.CreateTime)
                .IsUnicode(false);

            modelBuilder.Entity<VideoMsgs>()
                .Property(e => e.MsgType)
                .IsUnicode(false);

            modelBuilder.Entity<VideoMsgs>()
                .Property(e => e.MediaId)
                .IsUnicode(false);

            modelBuilder.Entity<VideoMsgs>()
                .Property(e => e.ThumbMediaId)
                .IsUnicode(false);

            modelBuilder.Entity<VoiceMsgs>()
                .Property(e => e.MsgId)
                .IsUnicode(false);

            modelBuilder.Entity<VoiceMsgs>()
                .Property(e => e.ToUserName)
                .IsUnicode(false);

            modelBuilder.Entity<VoiceMsgs>()
                .Property(e => e.FromUserName)
                .IsUnicode(false);

            modelBuilder.Entity<VoiceMsgs>()
                .Property(e => e.CreateTime)
                .IsUnicode(false);

            modelBuilder.Entity<VoiceMsgs>()
                .Property(e => e.MsgType)
                .IsUnicode(false);

            modelBuilder.Entity<VoiceMsgs>()
                .Property(e => e.MediaId)
                .IsUnicode(false);

            modelBuilder.Entity<VoiceMsgs>()
                .Property(e => e.Format)
                .IsUnicode(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}
