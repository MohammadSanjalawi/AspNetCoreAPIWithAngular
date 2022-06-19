using Contracts;
using Entities;
using Entities.Helpers;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateOwner(Owner owner)
        {
            Create(owner);
        }

        public void DeleteOwner(Owner owner)
        {
            Delete(owner);
        }

        public PagedList<Owner> GetOwners(OwnerParameters ownerParameters)
        {
            //implementation withput filtering
            //return PagedList<Owner>.ToPagedList(FindAll().OrderBy(o => o.Name), ownerParameters.PageNumber, ownerParameters.PageSize);

            //implementation with filtering
            var owners = FindByCondition(o => o.DateOfBirth.Year >= ownerParameters.MinYearOfBirth &&
                                  o.DateOfBirth.Year <= ownerParameters.MaxYearOfBirth);


            SearchByName(ref owners, ownerParameters.Name);


            return PagedList<Owner>.ToPagedList(owners,
            ownerParameters.PageNumber,
            ownerParameters.PageSize);
        }



        public Owner GetOwnerById(Guid ownerId)
        {
            return FindByCondition(owner => owner.OwnerId.Equals(ownerId)).FirstOrDefault();
        }

        public Owner GetOwnerWithDetails(Guid ownerId)
        {
            return FindByCondition(owner => owner.OwnerId.Equals(ownerId))
                .Include(account => account.Accounts)
                .FirstOrDefault();
        }

        public void UpdateOwner(Owner owner)
        {
            Update(owner);
        }


        private void SearchByName(ref IQueryable<Owner> owners, string ownerName)
        {
            if (!owners.Any() || string.IsNullOrWhiteSpace(ownerName))
                return;


            owners = owners.Where(o => o.Name.ToLower().Contains(ownerName.Trim().ToLower()));
        }
    }
}
