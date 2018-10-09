using Huach.Admin.IRepository;
using Huach.Admin.Models;
using Huach.Framework.Extend;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Huach.Admin.Repository
{
    /// <summary>
    /// 实现对数据库的操作(增删改查)的基类
    /// </summary>
    /// <typeparam name="T">定义泛型，约束其是一个类</typeparam>
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {

        //获取的是当前线程内部的上下文实例，而且保证了线程内上下文唯一
        private DbContext db = EFContextFactory.GetCurrentDbContext;

        public IQueryable<TResult> LoadPaging<TResult>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TResult>> selector, out int total, int pageIndex, int pageSize, string order, string sort)
        {
            var temp = db.Set<T>().Where<T>(whereLambda);
            total = temp.Count();
            temp = temp.SetQueryableOrder(sort, order).Skip(pageSize * (pageIndex - 1))
                     .Take(pageSize);
            return temp.Select(selector).AsQueryable();
        }

        public int Add(T entity)
        {
            db.Entry<T>(entity).State = EntityState.Added;
            return db.SaveChanges();
        }

        public int Update(T entity)
        {
            db.Set<T>().Attach(entity);
            db.Entry<T>(entity).State = EntityState.Modified;
            return db.SaveChanges();
        }


        public int Update(Expression<Func<T>> entityExpression, Expression<Func<T, bool>> whereLambda)
        {
            MemberInitExpression memberInitExpression;
            if ((memberInitExpression = (entityExpression.Body as MemberInitExpression)) == null)
            {
                return 0;
            }
            ReadOnlyCollection<MemberBinding> bindings = memberInitExpression.Bindings;
            if (bindings != null && bindings.Count > 0)
            {
                T newEntity = entityExpression.Compile()();



                var dbSet = db.Set<T>();
                List<T> list = new List<T>();
                //if (whereLambda == null)
                //{
                //    list.Add(dbSet.Find(keys.Values.ToArray()));
                //}
                //else
                //{
                list.AddRange(dbSet.Where(whereLambda));
                //}
                if (list.Count > 0)
                {
                    PropertyInfo[] properties = typeof(T).GetProperties();
                    foreach (T item in list)
                    {
                        if (item != null)
                        {
                            dbSet.Attach(item);
                            foreach (var property in properties)
                            {
                                object value = property.GetValue(newEntity);
                                property.SetValue(item, value);
                            }
                        }
                    }
                }
            }
            return db.SaveChanges();
        }

        public int Update(T entity, Expression<Func<T, bool>> whereLambda, params string[] proNames)
        {
            var listModifes = db.Set<T>().Where(whereLambda).ToList();
            Type t = typeof(T);
            var proInfos = t.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
            Dictionary<string, PropertyInfo> dicPros = new Dictionary<string, PropertyInfo>();
            proInfos.ForEach(a =>
            {
                if (proNames.Contains(a.Name))
                {
                    dicPros.Add(a.Name, a);
                }
            });
            foreach (var item in proNames)
            {
                if (dicPros.ContainsKey(item))
                {
                    PropertyInfo proInfo = dicPros[item];
                    object newValue = proInfo.GetValue(entity, null);
                    foreach (var m in listModifes)
                    {
                        proInfo.SetValue(m, newValue, null);
                    }
                }
            }
            return db.SaveChanges();
        }

        public int Delete(T entity)
        {
            //EF5.0的写法
            db.Set<T>().Attach(entity);
            db.Entry<T>(entity).State = EntityState.Deleted;
            return db.SaveChanges();
        }

        public int Delete(Expression<Func<T, bool>> delLambda)
        {
            var ListDel = db.Set<T>().Where(delLambda).ToList();
            ListDel.ForEach(a =>
            {
                db.Set<T>().Attach(a);
                db.Entry(a).State = EntityState.Deleted;
            });
            //EF5.0的写法
            return db.SaveChanges();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> whereLambda)
        {
            return db.Set<T>().AsNoTracking().Where<T>(whereLambda);
        }

        public IQueryable<T> All()
        {
            return db.Set<T>().AsNoTracking();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> whereLambda)
        {
            return db.Set<T>().AsNoTracking().FirstOrDefault<T>(whereLambda);
        }
        public TResult FirstOrDefault<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> whereLambda)
        {
            return db.Set<T>().Where(whereLambda).Select(selector).FirstOrDefault();
        }
        public T Find(params object[] keyValues)
        {
            return db.Set<T>().Find(keyValues);
        }
    }
}