using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Areas.WeChat.Models
{
    public class TicketListModel
    {
        public string ticketonsellid;
        public string name;
        public double price;
        public string Picture;
        //public TicketListModel(string ticketid,string name, double price)
        //{
        //    this.ticketid = ticketid;
        //    this.name = name;
        //    this.price = price;
        //}
        //public static List<TicketListModel> TicketToList(string ticketid,string name, double price,List<TicketListModel> ticketlist)
        //{
        //    ticketlist.Add(new TicketListModel(ticketid,name, price));
        //    return ticketlist;
        //} 
    }

    public class OrderListModel
    {
        public string userticketid;
        public string OrderID;
        public string ticketname;
        public int booktime;
        public double Price;
    }
}