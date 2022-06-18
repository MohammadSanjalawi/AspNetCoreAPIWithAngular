using Contracts;
using Entities;
using Entities.Helpers;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public IEnumerable<Account> AccoutByOwner(Guid ownerId)
        {
            return FindByCondition(a => a.OwnerId.Equals(ownerId)).ToList();
        }

        public PagedList<Account> GetAccountsByOwner(Guid ownerId, AccountParameters accountParameters)
        {
            return PagedList<Account>.ToPagedList(FindByCondition(a => a.OwnerId.Equals(ownerId)), accountParameters.PageNumber, accountParameters.PageSize);
        }
    }
}
