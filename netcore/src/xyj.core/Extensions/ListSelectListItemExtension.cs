using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using xyj.core.Models.Report;
using xyj.core.Utility;

namespace xyj.core.Extensions
{
    public static class ListSelectListItemExtension
    {

        public static List<DropDownListItem> ToDropDownListItem(this List<DropDownListItem> items)
        {
            return items.Select(i => new DropDownListItem()
            {
                Selected = i.Selected,
                Text = i.Text,
                Value = i.Value
            }).ToList();
        }
        public static List<DropDownListItem> ToSelectListItem(this List<DropDownListItem> items)
        {
            return items.Select(i => new DropDownListItem()
            {
                Selected = i.selected,
                Text = i.text,
                Value = i.value
            }).ToList();
        }

        //从db层获取数据源
        public static List<DropDownListItem> ToItems<TModel>(this IQueryable<TModel> source,
            Expression<Func<TModel, string>> valueExpression, Expression<Func<TModel, string>> textExpression)
        {
            return source.ToList().Select(m => new DropDownListItem()
            {
                Text = textExpression.Compile().Invoke(m),
                Value = valueExpression.Compile().Invoke(m)
            }).ToList();
        }

        public static List<DropDownListItem> Format(this List<DropDownListItem> items, string selectedValue = ";")
        {
            return items.Format("全部", ";", selectedValue);
        }
        public static List<DropDownListItem> Format(this List<DropDownListItem> items, string defaultText, string defaultValue, string selectedValue = "")
        {
            selectedValue = selectedValue.HasValue() ? selectedValue : defaultValue;
            items = items.Distinct(Equality<DropDownListItem>.CreateComparer(p => p.value)).ToList();
            if (!items.Any(a => a.text == defaultText && a.value == defaultValue))
            {
                items.Insert(0, new DropDownListItem { Text = defaultText, Value = defaultValue, Selected = true });
            }
            items.ForEach(a =>
            {
                if (a.value == selectedValue || a.text == selectedValue)
                {
                    a.Selected  = true;
                }
            });
            return items;
        }


        //public static List<DropDownListItem> Format(this List<DropDownListItem> items, string selectedValue = ";")
        //{
        //    return items.Format("全部", ";", selectedValue);
        //}
        //public static List<DropDownListItem> Format(this List<DropDownListItem> items, string defaultText, string defaultValue, string selectedValue)
        //{
        //    selectedValue = selectedValue.HasValue() ? selectedValue : defaultValue;
        //    items = items.Distinct(Equality<DropDownListItem>.CreateComparer(p => p.Value)).ToList();
        //    if (!items.Any(a => a.Text == defaultText && a.Value == defaultValue))
        //    {
        //        items.Insert(0, new DropDownListItem { Text = defaultText, Value = defaultValue, Selected = true });
        //    }
        //    items.ForEach(a =>
        //    {
        //        if (a.Value == selectedValue || a.Text == selectedValue)
        //        {
        //            a.Selected = true;
        //        }
        //    });
        //    return items;
        //}
    }
}