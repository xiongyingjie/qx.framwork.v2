using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using qx.permmision.v2.Entity;
using qx.permmision.v2.Interfaces;
using qx.permmision.v2.Repository;
using Qx.Report.Interfaces;
using Qx.Report.Services;
using Qx.Contents.Entity;
using Qx.Contents.Interfaces;
using Qx.Contents.Services;
using Qx.Contents.Repository;
using Qx.Wechat.Entity;
using Qx.Wechat.Repository;
using Qx.Wechat.Interfaces;
using Qx.Wechat.Services;
using Qx.Msg.Interfaces;
using Qx.Msg.Repository;
using Qx.Msg.Services;
using Qx.WorkFlow.Entity;
using Qx.WorkFlow.Interfaces;
using Qx.WorkFlow.Repository;
using Qx.WorkFlow.Services;
using Qx.Account.Interfaces;
using Qx.Account.Services;
using Qx.Order.Entity;
using Qx.Order.Interfaces;
using Qx.Order.Repository;
using Qx.Order.Services;
using Qx.Org.Interfaces;
using Qx.Org.Services;
//using Qx.Permission.Entity;
//using Qx.Permission.Interfaces;
//using Qx.Permission.Repository;
//using Qx.Permission.Services;
using Qx.Tools.Interfaces;
//using IPermissionProvider = Qx.Permission.Interfaces.IPermissionProvider;

namespace Qx.Tools.Ioc.Unity
{
    public static class UnityIoc
    {
        public static void Register(List<Type> controllers)
        {
            //Container
            IUnityContainer container = new UnityContainer();
            //Register controllers
            controllers.ForEach(c => container.RegisterType(c));
            //Register Services
            RegisterServices(container);
            //Resolver
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        static void RegisterServices(IUnityContainer container)
        {
          
         

            #region Order

            container.RegisterType<IRepository<order_item>, OrderItemRepository>();
            container.RegisterType<IRepository<order>, OrderRepository>();
            container.RegisterType<IRepository<order_state>, OrderStatuRepository>();
            container.RegisterType<IRepository<order_type>, OrderTypeRepository>();
            container.RegisterType<IRepository<r_product>, R_ProductsRepository>();
            container.RegisterType<IRepository<r_user>, R_UsersRepository>();
            container.RegisterType<IRepository<sell_consultant>, SellConsultantRepository>();
            container.RegisterType<IRepository<shopping_cart>, ShoppingCartRepository>();

            #endregion


            #region Permission Repository
            //container.RegisterType<IRepository<button>, ButtonRepository>();
            //container.RegisterType<IRepository<menu>, MenuRepository>();
            //container.RegisterType<IRepository<role_button_forbid >, RoleButtonForbidRepository>();
            //container.RegisterType<IRepository<role_menu>, RoleMenuRepository>();
            //container.RegisterType<IRepository<role>, RoleRepository>();
            //container.RegisterType<IRepository<Qx.Permission.Entity.permission_user>, Qx.Permission.Repository.UserRepository>();
            //container.RegisterType<IRepository<user_role>, UserRoleRepository>();
            //container.RegisterType<IRepository<menu_extension>, MenuExtensionRepository>();
            //container.RegisterType<IPermissionProvider, PermissionProvider>();


            #endregion

            #region Permission V2 Repository
            container.RegisterType<IRepository<qx.permmision.v2.Entity.button>, qx.permmision.v2.Repository.ButtonRepository>();
            container.RegisterType<IRepository<qx.permmision.v2.Entity.menu>, qx.permmision.v2.Repository.MenuRepository>();
            container.RegisterType<IRepository<qx.permmision.v2.Entity.role_button_forbid>, qx.permmision.v2.Repository.RoleButtonForbidRepository>();
            container.RegisterType<IRepository<qx.permmision.v2.Entity.role_menu>, qx.permmision.v2.Repository.RoleMenuRepository>();
            container.RegisterType<IRepository<qx.permmision.v2.Entity.role>, qx.permmision.v2.Repository.RoleRepository>();
            container.RegisterType<IRepository<qx.permmision.v2.Entity.permission_user>, qx.permmision.v2.Repository.UserRepository>();
            container.RegisterType<IRepository<qx.permmision.v2.Entity.user_role>, qx.permmision.v2.Repository.UserRoleRepository>();
            container.RegisterType<IRepository<qx.permmision.v2.Entity.data_filter>, qx.permmision.v2.Repository.DataFilterRepository>();
            container.RegisterType<IRepository<qx.permmision.v2.Entity.filter_script>, qx.permmision.v2.Repository.FilterScriptRepository>();

            


            container.RegisterType<IRepository<qx.permmision.v2.Entity.user_group>, qx.permmision.v2.Repository.UserGroupRepository>();
            container.RegisterType<IRepository<qx.permmision.v2.Entity.user_group_relation>, qx.permmision.v2.Repository.UserGroupRelationRepository>();
            container.RegisterType<IRepository<qx.permmision.v2.Entity.role_group>, qx.permmision.v2.Repository.RoleGroupRepository>();
            container.RegisterType<IRepository<qx.permmision.v2.Entity.role_group_relation>, qx.permmision.v2.Repository.RoleGroupRelationRepository>();

            container.RegisterType<IRepository<orgnization> , qx.permmision.v2.Repository.OrgnizationRepository>();
             container.RegisterType<IRepository<orgnization_position> , qx.permmision.v2.Repository.OrgnizationPositionRepository>();
             container.RegisterType<IRepository<orgnization_type> , qx.permmision.v2.Repository.OrgnizationTypeRepository>();
             container.RegisterType<IRepository<position> , qx.permmision.v2.Repository.PositionRepository>();
             container.RegisterType<IRepository<position_type> , qx.permmision.v2.Repository.PositionTypeRepository>();
             container.RegisterType<IRepository<user_orgnization> , qx.permmision.v2.Repository.UserOrgnizationRepository>();
             container.RegisterType<IRepository<user_position> , qx.permmision.v2.Repository.UserPositionRepository>();


        container.RegisterType<qx.permmision.v2.Interfaces.IPermmisionService, qx.permmision.v2.Services.PermissionServices>();
            container.RegisterType<qx.permmision.v2.Interfaces.IPermissionProvider, qx.permmision.v2.Services.PermissionProvider>();




            #endregion


            #region Contents Repository
            container.RegisterType<IReportServices, ReportServices>();
            container.RegisterType<IRepository<content_column_value>, ContentColumnValueRepository>();
            container.RegisterType<IRepository<content_table_design>, ContentTableDesignRepository>();
            container.RegisterType<IRepository<content_table_query>, ContentTableQueryRepository>();
            container.RegisterType<IRepository<content_type>, ContentTypeRepository>();
            container.RegisterType<IRepository<conlumn_type>, ColumnTypeRepository>();
            container.RegisterType<IRepository<data_type>, DataTypeRepository>();
            container.RegisterType<IRepository<page_control_type>, PageControlTypeRepository>();


            container.RegisterType<IRepository<content_column_design>, ContentColumnDesignRepository>();
            container.RegisterType<IContents, ContentService>();

            #endregion

            #region Website Repository
            container.RegisterType<IRepository<column_design>, ColumnDesignRepository>();

            container.RegisterType<IRepository<column_tempelate>, ColumnTempelateRepository>();

            container.RegisterType<IRepository<librarys>, LibrarysRepository>();

            #endregion





            #region Wechat  Repository
            container.RegisterType<IRepository<ImageMsg>, ImageMsgRepository>();
            container.RegisterType<IRepository<LinkMsg>, LinkMsgRepository>();
            container.RegisterType<IRepository<LocationEvent>, LocationEventRepository>();
            container.RegisterType<IRepository<LocationMsg>, LocationMsgRepository>();
            container.RegisterType<IRepository<Log>, LogRepository>();
            container.RegisterType<IRepository<MenuEvent>, MenuEventRepository>();
            container.RegisterType<IRepository<NewsMsgItem>, NewsMsgItemRepository>();
            container.RegisterType<IRepository<ReplyImageMsg>, ReplyImageMsgRepository>();
            container.RegisterType<IRepository<ReplyMusicMsg>, ReplyMusicMsgRepository>();
            container.RegisterType<IRepository<ReplyNewsMsg>, ReplyNewsMsgRepository>();
            container.RegisterType<IRepository<ReplySetup>, ReplySetupRepository>();
            container.RegisterType<IRepository<ReplyTextMsg>, ReplyTextMsgRepository>();
            container.RegisterType<IRepository<ReplyVideoMsg>, ReplyVideoMsgRepository>();
            container.RegisterType<IRepository<ReplyVoiceMsg>, ReplyVoiceMsgRepository>();
            container.RegisterType<IRepository<ShortVideoMsg>, ShortVideoMsgRepository>();
            container.RegisterType<IRepository<SubscribeEvent>, SubscribeEventRepository>();
            container.RegisterType<IRepository<SystemSetup>, SystemSetupRepository>();
            container.RegisterType<IRepository<TextMsg>, TextMsgRepository>();
            container.RegisterType<IRepository<Token>, TokenRepository>();
            container.RegisterType<IRepository<VideoMsg>, VideoMsgRepository>();
            container.RegisterType<IRepository<VoiceMsg>, VoiceMsgRepository>();
            container.RegisterType<IRepository<ReplyMsg>, ReplyMsgRepository>();
            //失物招领
            //container.RegisterType<ILostAndFoundServices, LostAndFoundServices>();
           // container.RegisterType<IWeChatBll, WeChatBll>();

            
            #endregion

            #region Provider
            //container.RegisterType<IInvoicingProvider, InvoicingProvider>();
            //container.RegisterType<IEmployeeProvider, EmployeeProvider>();
           // container.RegisterType<IPermissionProvider, PermissionProvider>();
           // container.RegisterType<IProductProvider, InvoicingProductProvider>();
            container.RegisterType<IAccountProvider, AccountProvider>();
            container.RegisterType<IOrderProvider, OrderProvider>();
            //container.RegisterType<IMemberProvider, MemberProvider>();
           // container.RegisterType<IFastOrg, Qx.Tools.Ioc.Unity.FastCarProvider>();
            container.RegisterType<IOrgProvider, OrgProvider>();
           



            #endregion

            #region Service
            container.RegisterType<IContents, ContentService>();
            //container.RegisterType<IMemberServices,MemberServices>();
            //container.RegisterType<IInvoicingServices, InvoicingServices>();
            container.RegisterType<IAccountPayService, AccountPayService>();
            container.RegisterType<IOrderService, OrderService>();
            container.RegisterType<IReportServices, ReportServices>();
        //    container.RegisterType<IStockRightServices, StockRightServices>();
          //  container.RegisterType<IPermission, PermissionServices>();
            container.RegisterType<IOrg, OrgServices>();
            //container.RegisterType<IProfitServices, ProfitServices>();
            // container.RegisterType<ITaskServices, TaskServices>();


            #endregion

            #region R Provider

            container.RegisterType<IWechatServices, WechatServices>();
            //container.RegisterType<IInvoicingPermissionOrder, InvoicingPermissionOrder>();
            //container.RegisterType<IInvoicingPermission, InvoicingPermission>();

            //container.RegisterType<IRServieces, RServieces>();
            //container.RegisterType<IAccountOrg, AccountOrg>();
            //container.RegisterType<IAccountFastCarOrg, AccountFastCarOrg>();
            //container.RegisterType<IAccountMember, AccountMember>();
            //container.RegisterType<IEmployeeOrg, EmployeeOrg>();
            //container.RegisterType<IVipCardProvider, VipCardProvider>();
            //container.RegisterType<IEmployeePermission, EmployeePermission>();
            //container.RegisterType<IAccountMemberVipCard, AccountMemberVipCard>();
            //container.RegisterType<IAccountInvoicingOrderProduct, AccountInvoicingOrderProduct>();
            //container.RegisterType<IMemberPermission,MemberPermission>();
            //container.RegisterType<IBonusOrg, BonusOrg>();
            //container.RegisterType<IInvoicingOrg, InvoicingOrg>();
            //container.RegisterType<ICreditCardInvoicing, CreditCardInvoicing>();
            //container.RegisterType<IMemberMsg, MemberMsg>();            
            #endregion

        

            #region Qx.Msg
            container.RegisterType<IMsgProvider, MsgProvider>();
            container.RegisterType<IMsgService, MsgService>();
            container.RegisterType<IRepository<Qx.Msg.Entity.contact>, ContactRepository>();
            container.RegisterType<IRepository<Qx.Msg.Entity.msg_group>, GroupRepository>();
            container.RegisterType<IRepository<Qx.Msg.Entity.group_member>, Qx.Msg.Repository.GroupMemberRepository>();
            container.RegisterType<IRepository<Qx.Msg.Entity.in_state>, InStateRepository>();
            container.RegisterType<IRepository<Qx.Msg.Entity.msg>, MsgRepository>();
            container.RegisterType<IRepository<Qx.Msg.Entity.msg_collection>, MsgCollectionRepository>();
            container.RegisterType<IRepository<Qx.Msg.Entity.crew_limite_type>, CrewLimiteTypeRepository>();
            container.RegisterType<IRepository<Qx.Msg.Entity.msg_send_record>, MsgSendRecordRepository>();
            container.RegisterType<IRepository<Qx.Msg.Entity.msg_type>, MsgTypeRepository>();
            container.RegisterType<IRepository<Qx.Msg.Entity.out_state>, OutStateRepository>();
            container.RegisterType<IRepository<Qx.Msg.Entity.timer_msg>, TimerMsgRepository>();
            container.RegisterType<IRepository<Qx.Msg.Entity.sms_send_record>, SmsSendRecordRepository>();
            container.RegisterType<IRepository<Qx.Msg.Entity.msg_user>, Qx.Msg.Repository.UserRepository>();
            #endregion

            #region Qx.WorkFlow
           container.RegisterType<IWorkFlowProvider, WorkFlowProvider>();
           container.RegisterType<IWorkFlowService, WorkFlowService>();
           container.RegisterType<IRepository<ConvertCondition>, ConvertConditionRepository>();
           container.RegisterType<IRepository<NodeRelation>, NodeRelationRepository>();
           container.RegisterType<IRepository<Node>, NodeRepository>();
           container.RegisterType<IRepository<WorkFlowInstance>, WorkFlowInstanceRepository>();
           container.RegisterType<IRepository<WorkFlow.Entity.WorkFlow>, WorkFlowRepository>();
          
            #endregion
        }

    }
}
