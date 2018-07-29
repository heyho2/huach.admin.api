using Huach.Admin.IRepository;
using Huach.Admin.Models.Basic;
using Huach.Framework;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Huach.Admin.Service
{
    public class ServiceBase<T> : IService where T : ModelBase
    {
        private readonly IRepositoryBase<T> _repository = null;
        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// 实现对数据库的查询  --简单查询
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> Where(Expression<Func<T, bool>> whereLambda)
        {
            return _repository.Where(whereLambda);
        }
        /// <summary>
        /// 实现对数据库的查询  --简单单行查询
        /// </summary> 
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public T FirstOrDefault(Expression<Func<T, bool>> whereLambda)
        {
            return _repository.FirstOrDefault(whereLambda);
        }
        /// <summary>
        /// 根据id查询
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public T Find(params object[] keyValues)
        {
            return _repository.Find(keyValues);
        }
    }
}
