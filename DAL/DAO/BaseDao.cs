using DAL.Infrastructure;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;

namespace DAL.DAO
{
    public abstract class BaseDao<T> where T : Base
    {
        public string ConnectionString { get; private set; }

        public BaseDao(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected string TableName { get; set; }
        protected IDbConnection Connection
        {
            get
            {
                return new ConnectionFactory(ConnectionString).CreateConnection();
            }
        }

        public virtual IEnumerable<T> FindAll()
        {
            using (var connection = Connection)
            {
                return connection.Query<T>($"SELECT * FROM {TableName}");
            }
        }
        public virtual IEnumerable<T> FindAll(Func<T, bool> predicate)
        {
            using (var connection = Connection)
            {
                return connection.Query<T>($"SELECT * FROM {TableName}").Where(predicate);
            }
        }
        public virtual T FindById(int? id)
        {
            using (var connection = Connection)
            {
                return connection.Query<T>($"SELECT * FROM {TableName} WHERE Id = {id}").FirstOrDefault();
            }
        }
        public virtual long Insert(T entity)
        {
            using (var connection = Connection)
            {
                return connection.Insert(entity);
            }
        }
        public virtual long Insert(IEnumerable<T> entities)
        {
            using (var connection = Connection)
            {
                return connection.Insert(entities);
            }
        }
        public virtual bool Update(T entity)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                var _oldEntity = FindById(entity.Id);

                try
                {
                    using (var connection = Connection)
                    {
                        return connection.Update(entity);
                    }
                }
                catch (Exception)
                {
                    scope.Dispose();
                    return false;
                }
            }
        }
        public virtual bool Update(IEnumerable<T> entities)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                try
                {
                    foreach (var entity in entities)
                    {
                        Update(entity);
                    }
                    return true;
                }
                catch (Exception)
                {
                    scope.Dispose();
                    return false;
                }
            }
        }
        public virtual bool Delete(int id)
        {
            try
            {
                using (var connection = Connection)
                {
                    int count = connection.Execute($"DELETE FROM {TableName} WHERE Id = {id}");
                    if (count > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public virtual bool Delete(T entity)
        {
            return Delete(entity.Id);
        }
    }
}
