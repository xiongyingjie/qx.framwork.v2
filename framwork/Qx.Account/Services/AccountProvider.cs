using System;
using Qx.Account.Interfaces;

namespace Qx.Account.Services
{
    public class AccountProvider : IAccountProvider
    {
        private IAccountPayService _accountPayService;
        public AccountProvider(IAccountPayService accountPayService)
        {
            _accountPayService = accountPayService;
        }

        public IAccountPayService Services
        {
            get
            {
                return _accountPayService;
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
