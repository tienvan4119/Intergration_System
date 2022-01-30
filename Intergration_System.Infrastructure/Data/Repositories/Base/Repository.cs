//using Microsoft.EntityFrameworkCore;
//using System;
//using TM.Domain.DTOs;
//using TM.Domain.Entities.Base;
//using TM.Domain.Interfaces;

//namespace TM.Infrastructure.Data.Repositories.Base
//{
//    public class Repository<T> : IRepository<T> where T : Entity
//    {
//        public DbSet<T> Entites => DbContext.Set<T>();
//        private readonly IUserInfor _userInfor;

//        public DbContext DbContext { get; private set; }

//        public IUserInfor UserInfor => _userInfor ?? throw new Exception("UnAuthorized");

//        public int TenantId => UserInfor.TenantId;

//        public int UserId => UserInfor.Id;

//        public Repository(IUserInfor userInfor, DbContext dbContext)
//        {
//            _userInfor = userInfor;
//            DbContext = dbContext;
//        }
//    }
//}
