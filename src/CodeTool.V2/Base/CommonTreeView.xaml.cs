using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CodeTool.V2.Base
{
    public partial class CommonTreeView : UserControl
    {
        public IList<CommonTreeViewItemModel> ItemsSourceData
        {
            get { return (IList<CommonTreeViewItemModel>) innerTree.ItemsSource; }
        }


        public CommonTreeView()
        {
            InitializeComponent();
           
        }

        /// <summary>
        /// 设置数据源, 以及各个字段
        /// </summary>
        /// <typeparam name="TSource">数据源类型</typeparam>
        /// <typeparam name="TId">主键类型</typeparam>
        /// <param name="itemsArray">数据源列表</param>
        /// <param name="captionSelector">指定显示为Caption的属性</param>
        /// <param name="idSelector">指定主键属性</param>
        /// <param name="parentIdSelector">指定父项目主键属性</param>
        public void SetItemsSourceData<TSource, TId>(IEnumerable<TSource> itemsArray,
            Func<TSource, string> captionSelector, Func<TSource, TId> idSelector, Func<TSource, TId> parentIdSelector)
            where TId : IEquatable<TId>
        {
            var list = new List<CommonTreeViewItemModel>();

            foreach (var item in itemsArray.Where(a => object.Equals(default(TId), parentIdSelector(a))))
            {
                var tvi = new CommonTreeViewItemModel();
                tvi.Caption = captionSelector(item).ToString();
                tvi.Id = idSelector(item);
                tvi.Tag = item;
                tvi.TagType = item.GetType();
                list.Add(tvi);
                RecursiveAddChildren(tvi, itemsArray, captionSelector, idSelector, parentIdSelector);
            }

            innerTree.ItemsSource = list;
            return;
        }

        /// <summary>
        /// 递归加载children
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TId"></typeparam>
        /// <param name="parent"></param>
        /// <param name="itemsArray"></param>
        /// <param name="captionSelector"></param>
        /// <param name="idSelector"></param>
        /// <param name="parentIdSelector"></param>
        /// <returns></returns>
        private CommonTreeViewItemModel RecursiveAddChildren<TSource, TId>(CommonTreeViewItemModel parent,
            IEnumerable<TSource> itemsArray, Func<TSource, string> captionSelector, Func<TSource, TId> idSelector,
            Func<TSource, TId> parentIdSelector)
        {

            foreach (var item in itemsArray.Where(a => parent.Id.Equals(parentIdSelector(a))))
            {
                var tvi = new CommonTreeViewItemModel();
                tvi.Caption = captionSelector(item);
                tvi.Id = idSelector(item);
                tvi.Tag = item;
                tvi.TagType = item.GetType();
                tvi.Parent = parent;
                parent.Children.Add(tvi);
                RecursiveAddChildren(tvi, itemsArray, captionSelector, idSelector, parentIdSelector);
            }
            return parent;
        }
    }
}
