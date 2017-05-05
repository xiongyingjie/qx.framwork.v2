using System.Collections.Generic;
using System.Linq;
using qx.permmision.v2.Models;
using Web.Models;

namespace Web.Domain
{
    public class Data
    {
        public IEnumerable<Navbar> navbarItems()
        {
            var menu = new List<Navbar>();
            #region 自定义

            //menu.Add(new Navbar { Id = 122222, nameOption = "工作台", controller = "Home", action = "Index", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 0 });
             
            //menu.Add(new Navbar { Id = 1, nameOption = "会员管理(快车)", imageClass = "fa fa-bar-chart-o fa-fw", status = true, isParent = true, parentId = 0 });
            //menu.Add(new Navbar { Id = 11, nameOption = "会员列表", area = "FastCar", controller = "Admin", action = "VIPList", status = true, isParent = false, parentId = 1 });

            //menu.Add(new Navbar { Id = 2, nameOption = "车辆管理(管理员)", imageClass = "fa fa-bar-chart-o fa-fw", status = true, isParent = true, parentId = 0 });
            //menu.Add(new Navbar { Id = 21, nameOption = "车辆列表(管理员)", area = "FastCar", controller = "Admin", action = "CarList", status = true, isParent = false, parentId = 2 });
            //menu.Add(new Navbar { Id = 22, nameOption = "车品牌管理(管理员)", area = "FastCar", controller = "Admin", action = "CarBrand", status = true, isParent = false, parentId = 2 });
            //menu.Add(new Navbar { Id = 23, nameOption = "车类型管理(管理员)", area = "FastCar", controller = "Admin", action = "CarType", status = true, isParent = false, parentId = 2 });

            //menu.Add(new Navbar { Id = 3, nameOption = "快车管理", imageClass = "fa fa-bar-chart-o fa-fw", status = true, isParent = true, parentId = 0 });
            //menu.Add(new Navbar { Id = 31, nameOption = "快车列表(管理员)", area = "FastCar", controller = "Admin", action = "FastCarList", status = true, isParent = false, parentId = 3 });

            
            //menu.Add(new Navbar { Id = 4, nameOption = "快车经营权管理(管理员)", imageClass = "fa fa-bar-chart-o fa-fw", status = true, isParent = true, parentId = 0 });
            //menu.Add(new Navbar { Id = 41, nameOption = "快车经营权列表(管理员)", area = "FastCar", controller = "Admin", action = "FastCarStockRightManager", status = true, isParent = false, parentId = 4 });          
            //menu.Add(new Navbar { Id = 42, nameOption = "快车经营权发售(管理员)", area = "FastCar", controller = "Admin", action = "ChooseFastCar", status = true, isParent = false, parentId = 4 });

            //menu.Add(new Navbar { Id = 5, nameOption = "经营权置换中心（买家版）", imageClass = "fa fa-bar-chart-o fa-fw", status = true, isParent = true, parentId = 0 });
            //menu.Add(new Navbar { Id = 50, nameOption = "经营权市场", area = "FastCar", controller = "Admin", action = "StockRightTradeCenter", status = true, isParent = false, parentId = 5 });
            //menu.Add(new Navbar { Id = 51, nameOption = "我的购物车", area = "FastCar", controller = "Admin", action = "Cart", status = true, isParent = false, parentId = 5 });
            //menu.Add(new Navbar { Id = 52, nameOption = "所有订单", area = "FastCar", controller = "Admin", action = "StockRightOrders", status = true, isParent = false, parentId = 5 });
            //menu.Add(new Navbar { Id = 53, nameOption = "待付款订单", area = "FastCar", controller = "Admin", action = "StockRightOrders21", status = true, isParent = false, parentId = 5 });
            //menu.Add(new Navbar { Id = 54, nameOption = "待确认订单", area = "FastCar", controller = "Admin", action = "StockRightOrders22", status = true, isParent = false, parentId = 5 });
            //menu.Add(new Navbar { Id = 55, nameOption = "已完成订单", area = "FastCar", controller = "Admin", action = "StockRightOrders1", status = true, isParent = false, parentId = 5 });

            //menu.Add(new Navbar { Id = 6, nameOption = "经营权置换中心（卖家版）", imageClass = "fa fa-bar-chart-o fa-fw", status = true, isParent = true, parentId = 0 });
            //menu.Add(new Navbar { Id = 61, nameOption = "我的快车经营权", area = "FastCar", controller = "Admin", action = "MyStockRight", status = true, isParent = false, parentId = 6 });
            //menu.Add(new Navbar { Id = 62, nameOption = "我的货架", area = "FastCar", controller = "Admin", action = "MyStockRightChange", status = true, isParent = false, parentId = 6 });
            //menu.Add(new Navbar { Id = 63, nameOption = "所有订单", area = "FastCar", controller = "Admin", action = "MyStockRightOrders", status = true, isParent = false, parentId = 6 });
            //menu.Add(new Navbar { Id = 64, nameOption = "待付款订单", area = "FastCar", controller = "Admin", action = "MyStockRightOrders22", status = true, isParent = false, parentId = 6 });
            //menu.Add(new Navbar { Id = 65, nameOption = "待确认订单", area = "FastCar", controller = "Admin", action = "MyStockRightOrders21", status = true, isParent = false, parentId = 6 });
            //menu.Add(new Navbar { Id = 66, nameOption = "已完成订单", area = "FastCar", controller = "Admin", action = "MyStockRightOrders1", status = true, isParent = false, parentId = 6 });

            //menu.Add(new Navbar { Id = 7, nameOption = "会员管理(会员)", imageClass = "fa fa-bar-chart-o fa-fw", status = true, isParent = true, parentId = 0 });  
            //menu.Add(new Navbar { Id = 71, nameOption = "会员列表(管理员)", area = "Member", controller = "TMember", action = "Index", status = true, isParent = false, parentId = 7 });
           
            //menu.Add(new Navbar { Id = 8, nameOption = "会员健康币管理(管理员)", imageClass = "fa fa-bar-chart-o fa-fw", status = true, isParent = true, parentId = 0 });
            //menu.Add(new Navbar { Id = 81, nameOption = "会员健康币(管理员)", area = "Member", controller = "MemJKBAccount", action = "Index", status = true, isParent = false, parentId = 8 });

            //menu.Add(new Navbar { Id = 9, nameOption = "会员群管理(管理员)", imageClass = "fa fa-bar-chart-o fa-fw", status = true, isParent = true, parentId = 0 });
            //menu.Add(new Navbar { Id = 91, nameOption = "群列表(管理员)", area = "Member", controller = "MemGroup", action = "Index", status = true, isParent = false, parentId = 9 });

            //menu.Add(new Navbar { Id = 10, nameOption = "会员积分管理(管理员)", imageClass = "fa fa-bar-chart-o fa-fw", status = true, isParent = true, parentId = 0 });
            //menu.Add(new Navbar { Id = 101, nameOption = "会员积分(管理员)", area = "Member", controller = "MemScore", action = "Index", status = true, isParent = false, parentId = 10 });
            
            //menu.Add(new Navbar { Id = 11, nameOption = "会员等级管理(管理员)", imageClass = "fa fa-bar-chart-o fa-fw", status = true, isParent = true, parentId = 0 });
            //menu.Add(new Navbar { Id = 111, nameOption = "会员等级(管理员)", area = "Member", controller = "MemLevel", action = "Index", status = true, isParent = false, parentId = 11 });
           
            //menu.Add(new Navbar { Id = 12, nameOption = "实名认证管理(管理员)", imageClass = "fa fa-bar-chart-o fa-fw", status = true, isParent = true, parentId = 0 });
            //menu.Add(new Navbar { Id = 121, nameOption = "实名认证列表(管理员)", area = "Member", controller = "MemRealName", action = "Index", status = true, isParent = false, parentId = 12 });

            //menu.Add(new Navbar { Id = 13, nameOption = "健康币管理(用户)", imageClass = "fa fa-bar-chart-o fa-fw", status = true, isParent = true, parentId = 0 });
            //menu.Add(new Navbar { Id = 131, nameOption = "健康币余额", area = "Member", controller = "MemJKBAccount", action = "JKBAccount", status = true, isParent = false, parentId = 13 });

            //menu.Add(new Navbar { Id = 14, nameOption = "会员群管理(用户)", imageClass = "fa fa-bar-chart-o fa-fw", status = true, isParent = true, parentId = 0 });
            //menu.Add(new Navbar { Id = 141, nameOption = "我管理的群", area = "Member", controller = "MemGroup", action = "MyMemGroup", status = true, isParent = false, parentId = 14 });
            //menu.Add(new Navbar { Id = 141, nameOption = "我加入的群", area = "Member", controller = "MemGroup", action = "MyJoinMemGroup", status = true, isParent = false, parentId = 14 });
            
            //menu.Add(new Navbar { Id = 15, nameOption = "会员积分管理(用户)", imageClass = "fa fa-bar-chart-o fa-fw", status = true, isParent = true, parentId = 0 });
            //menu.Add(new Navbar { Id = 151, nameOption = "会员积分", area = "Member", controller = "MemScore", action = "MemScore", status = true, isParent = false, parentId = 15 });

            //menu.Add(new Navbar { Id = 16, nameOption = "会员等级管理(用户)", imageClass = "fa fa-bar-chart-o fa-fw", status = true, isParent = true, parentId = 0 });
            //menu.Add(new Navbar { Id = 161, nameOption = "会员等级", area = "Member", controller = "MemLevel", action = "MemLevel", status = true, isParent = false, parentId = 16 });

            //menu.Add(new Navbar { Id = 17, nameOption = "实名认证管理(用户)", imageClass = "fa fa-bar-chart-o fa-fw", status = true, isParent = true, parentId = 0 });
            //menu.Add(new Navbar { Id = 171, nameOption = "实名认证", area = "Member", controller = "MemRealName", action = "RealNameCheck", status = true, isParent = false, parentId = 17 });

            //menu.Add(new Navbar { Id = 18, nameOption = "文件上传(测试，以后要注释)", imageClass = "fa fa-bar-chart-o fa-fw", status = true, isParent = true, parentId = 0 });
            //menu.Add(new Navbar { Id = 181, nameOption = "内容列", area = "Contents", controller = "CCD", action = "Index", status = true, isParent = false, parentId = 18 });
            //menu.Add(new Navbar { Id = 182, nameOption = "内容值", area = "Contents", controller = "CCV", action = "Index", status = true, isParent = false, parentId = 18 });
            //menu.Add(new Navbar { Id = 183, nameOption = "内容类型", area = "Contents", controller = "ContentType", action = "Index", status = true, isParent = false, parentId = 18 });
            //menu.Add(new Navbar { Id = 184, nameOption = "内容表", area = "Contents", controller = "CTD", action = "Index", status = true, isParent = false, parentId = 18 });
            //menu.Add(new Navbar { Id = 185, nameOption = "内容表查询", area = "Contents", controller = "CTQ", action = "Index", status = true, isParent = false, parentId = 18 });
            //menu.Add(new Navbar { Id = 186, nameOption = "数据类型", area = "Contents", controller = "DataType", action = "Index", status = true, isParent = false, parentId = 18 });
            //menu.Add(new Navbar { Id = 187, nameOption = "控件类型", area = "Contents", controller = "PageControlType", action = "Index", status = true, isParent = false, parentId = 18 });
           
            #endregion

            #region 模板

            //menu.Add(new Navbar { Id = 1, nameOption = "Dashboard", controller = "Home", action = "Index", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 0 });
            //menu.Add(new Navbar { Id = 2, nameOption = "Charts", imageClass = "fa fa-bar-chart-o fa-fw", status = true, isParent = true, parentId = 0 });
            //menu.Add(new Navbar { Id = 3, nameOption = "Flot Charts", controller = "Home", action = "FlotCharts", status = true, isParent = false, parentId = 2 });
            //menu.Add(new Navbar { Id = 4, nameOption = "Morris.js Charts", controller = "Home", action = "MorrisCharts", status = true, isParent = false, parentId = 2 });
            //menu.Add(new Navbar { Id = 5, nameOption = "Tables", controller = "Home", action = "Tables", imageClass = "fa fa-table fa-fw", status = true, isParent = false, parentId = 0 });
            //menu.Add(new Navbar { Id = 6, nameOption = "Forms", controller = "Home", action = "Forms", imageClass = "fa fa-edit fa-fw", status = true, isParent = false, parentId = 0 });
            //menu.Add(new Navbar { Id = 7, nameOption = "UI Elements", imageClass = "fa fa-wrench fa-fw", status = true, isParent = true, parentId = 0 });
            //menu.Add(new Navbar { Id = 8, nameOption = "Panels and Wells", controller = "Home", action = "Panels", status = true, isParent = false, parentId = 7 });
            //menu.Add(new Navbar { Id = 9, nameOption = "Buttons", controller = "Home", action = "Buttons", status = true, isParent = false, parentId = 7 });
            //menu.Add(new Navbar { Id = 10, nameOption = "Notifications", controller = "Home", action = "Notifications", status = true, isParent = false, parentId = 7 });
            //menu.Add(new Navbar { Id = 11, nameOption = "Typography", controller = "Home", action = "Typography", status = true, isParent = false, parentId = 7 });
            //menu.Add(new Navbar { Id = 12, nameOption = "Icons", controller = "Home", action = "Icons", status = true, isParent = false, parentId = 7 });
            //menu.Add(new Navbar { Id = 13, nameOption = "Grid", controller = "Home", action = "Grid", status = true, isParent = false, parentId = 7 });
            //menu.Add(new Navbar { Id = 14, nameOption = "Multi-Level Dropdown", imageClass = "fa fa-sitemap fa-fw", status = true, isParent = true, parentId = 0 });
            //menu.Add(new Navbar { Id = 15, nameOption = "Second Level Item", status = true, isParent = false, parentId = 14 });
            //menu.Add(new Navbar { Id = 16, nameOption = "Sample Pages", imageClass = "fa fa-files-o fa-fw", status = true, isParent = true, parentId = 0 });
            //menu.Add(new Navbar { Id = 17, nameOption = "Blank Page", controller = "Home", action = "Blank", status = true, isParent = false, parentId = 16 });
            //menu.Add(new Navbar { Id = 18, nameOption = "Login Page", controller = "Home", action = "Login", status = true, isParent = false, parentId = 16 });

            #endregion
            return menu.ToList();
        }
    }
}