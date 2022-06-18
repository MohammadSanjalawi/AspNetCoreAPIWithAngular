using Entities.Helpers;
using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IAccountRepository :IRepositoryBase<Account>
    {
        IEnumerable<Account> AccoutByOwner(Guid ownerId);

        PagedList<Account> GetAccountsByOwner(Guid ownerId, AccountParameters accountParameters);
    }
}
