using System;
using System.Collections.Generic;
using System.Data.Entity;
using AutoMapper;
using Bank.BLL.Entities.Base;
using Bank.BLL.Mapper.Base;
using Bank.BLL.Mapper.Interfaces;
using Bank.DAL.Contexts;
using Bank.DAL.DTO;
using Bank.DAL.Repositories;
using Ninject;

namespace Bank.BLL.Mapper
{
    public class AccountService : BaseService, IAccountService
    {
        private AccountRepository accountRepository;

        public AccountService(BankContext db)
        {
            this.accountRepository = new AccountRepository(db);
        }

        /// <inheritdoc/>
        protected override Action<IMapperConfigurationExpression> MapperCustomConfiguration =>
         cfg =>
         {
             cfg.CreateMap<Account, IAccountInfo>().ReverseMap();
         };

        /// <inheritdoc/>
        public IEnumerable<IAccountInfo> GetAll()
        {
            var collection = this.accountRepository.GetAllIncluding();
            var collectionInfo = this.MapperInstance.Map<IEnumerable<Account>, IEnumerable<IAccountInfo>>(collection);
            return collectionInfo;
        }

        public void Add(IAccountInfo item)
        {
            throw new NotImplementedException();
        }

        public void Create(IAccountInfo itemInfo)
        {
            throw new NotImplementedException();
        }

        public void Delete(int itemId)
        {
            throw new NotImplementedException();
        }

        public void Update(IAccountInfo item)
        {
            throw new NotImplementedException();
        }

    }
}
