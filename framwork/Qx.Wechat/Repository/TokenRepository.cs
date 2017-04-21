using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;
using Qx.Wechat.Entity;
using Qx.Wechat.Services;

namespace Qx.Wechat.Repository
{


    public class TokenRepository : BaseRepository, IRepository<Token>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.Tokens.Select(a => new SelectListItem() { Text = a.TokenId, Value = a.TokenId }).ToList();
            return dest.Format(value);
        }

        public string Add(Token model)
        {
            model.TokenId = Pk.ToString();
            if (Find(model.TokenId) == null)
            {
                return Db.SaveAdd(model) ? Pk.ToString() : null;
            }
            else
            {
                return "";
            }
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(Token model, string note = "")
        {
            if (Find(model.TokenId) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public Token Find(object id)
        {
            return Db.Tokens.NoTrackingFind(a=>a.TokenId ==  id.ToString());
        }

        public List<Token> All()
        {
            return Db.Tokens.NoTrackingToList();
        }

        public List<Token> All(Func<Token, bool> filter)
        {
            return Db.Tokens.NoTrackingWhere(filter);
        }
    }
}
