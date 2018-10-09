using Huach.Admin.Models;
using Huach.Admin.Models.Basic;
using Huach.Framework;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Huach.Admin.IRepository
{
    /// <summary>
    /// 实现对数据库的操作(增删改查)的基类
    /// </summary>
    /// <typeparam name="T">定义泛型，约束其是一个类</typeparam>
    public interface IBaseRepository<T> : IService where T : BaseModel
    {
        /// <summary>
        /// 实现对数据库的添加功能,添加实现EF框架的引用
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Add(T entity);

        /// <summary>
        /// 实现对数据库的修改功能
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Update(T entity);
        /// <summary>
        /// 按条件
        /// </summary>
        /// <param name="entityExpression"></param>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        int Update(Expression<Func<T>> entityExpression, Expression<Func<T, bool>> whereLambda);

        /// <summary>
        /// 实现对数据库的删除功能
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Delete(T entity);
        /// <summary>
        /// 根据条件产出
        /// </summary>
        /// <param name="delLambda"></param>
        /// <returns></returns>
        int Delete(Expression<Func<T, bool>> delLambda);
        /// <summary>
        /// 实现对数据库的查询  --简单查询
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        IQueryable<T> Where(Expression<Func<T, bool>> whereLambda);
        /// <summary>
        /// 获取所有
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        IQueryable<T> All();
        /// <summary>
        /// 实现对数据库的查询  --简单单行查询
        /// </summary> 
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        T FirstOrDefault(Expression<Func<T, bool>> whereLambda);
        /// <summary>
        /// 根据id查询
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        T Find(params object[] keyValues);

        /// <summary>
        /// 实现对数据的分页查询
        /// </summary>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="total">总条数</param>
        /// <param name="pageIndex">当前第几页</param>
        /// <param name="pageSize">一页显示多少条数据</param>
        /// <param name="order">DESC/ASC</param>
        /// <param name="sort">排序字段</param>
        /// <returns></returns>
        IQueryable<TResult> LoadPaging<TResult>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TResult>> selector, out int total, int pageIndex, int pageSize, string order, string sort);
        /// <summary>
        /// 单行查询
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="selector"></param>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        TResult FirstOrDefault<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> whereLambda);
    }
}