using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTool.V2.Base
{
  public  class CommonListViewModel
    {
        public enum SexOpt { Male, Female };

        public class Member
        {
            public string Name { get; set; }
            public string Age { get; set; }
            public SexOpt Sex { get; set; }
            public bool Pass { get; set; }
            public Uri Email { get; set; }
        }

      public CommonListViewModel()
      {
            //dataGrid.DataContext = new List<Member>()
            //{
            //    new Member()
            //{
            //    Name = "Joe",
            //    Age = "23",
            //    Sex = SexOpt.Male,
            //    Pass = true,
            //    Email = new Uri("mailto:Joe@school.com")
            //},new Member()
            //{
            //    Name = "Mike",
            //    Age = "20",
            //    Sex = SexOpt.Male,
            //    Pass = false,
            //    Email = new Uri("mailto:Mike@school.com")
            //}, new Member(){
            //    Name = "Lucy",
            //    Age = "25",
            //    Sex = SexOpt.Female,
            //    Pass = true,
            //    Email = new Uri("mailto:Lucy@school.com")
            //}
            //};
        }
    }
}
