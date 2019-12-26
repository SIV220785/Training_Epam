using System;
using System.Collections.Generic;
using AutoMapper;
using Bank.BLL.Entities;
using Bank.BLL.Entities.Base;
using Bank.BLL.Mapper.Base;
using Bank.BLL.Mapper.Interfaces;
using Bank.DAL.Contexts;
using Bank.DAL.DTO;
using Bank.DAL.Repositories;
using Ninject;

namespace Bank.BLL.Mapper
{
    internal class UserService : BaseService, IUserService
    {
        private UserRepository userRepository;

        public UserService(BankContext db)
        {
            this.userRepository = new UserRepository(db);
        }

        /// <inheritdoc/>
        protected override Action<IMapperConfigurationExpression> MapperCustomConfiguration =>
         cfg =>
         {
             cfg.CreateMap<User, UserInfo>().ReverseMap();
         };


        IEnumerable<IUserInfo> IUserService.GetAll()
        {
            var collection = this.userRepository.GetAll();
            var collectionInfo = this.MapperInstance.Map<IEnumerable<User>, IEnumerable<IUserInfo>>(collection);
            return collectionInfo;
        }

        public void Add(IUserInfo item)
        {
            throw new NotImplementedException();
        }

        public void Update(IUserInfo item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int itemId)
        {
            throw new NotImplementedException();
        }

        public void Create(IUserInfo itemInfo)
        {
            throw new NotImplementedException();
        }
    }
}
