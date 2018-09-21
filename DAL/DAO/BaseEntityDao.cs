using System.Collections.Generic;
using Dapper;
using System.Linq;
using System;
using Dapper.Contrib.Extensions;
using System.Transactions;

namespace DAL.DAO
{
    public class BaseEntityDao<T> : BaseDao<T> where T : BaseEntity
    {
        public BaseEntityDao(string connectionString) : base(connectionString)
        {

        }

        public virtual IEnumerable<T> FindAll(bool withDeleted = false)
        {
            string sql = $"SELECT * FROM {TableName} ";
            if (!withDeleted)
            {
                sql += "WHERE IsDeleted = 0";
            }

            using (var connection = Connection)
            {
                return connection.Query<T>(sql);
            }
        }
        public virtual IEnumerable<T> FindAll(Func<T, bool> predicate, bool withDeleted = false)
        {
            string sql = $"SELECT * FROM {TableName} ";
            if (!withDeleted)
            {
                sql += "WHERE IsDeleted = 0";
            }

            using (var connection = Connection)
            {
                return connection.Query<T>(sql).Where(predicate);
            }
        }
        public virtual T FindById(int? id, bool withDeleted = false)
        {
            if (id == null)
                return null;

            string sql = $"SELECT * FROM {TableName} WHERE Id = {id}";
            if (!withDeleted)
            {
                sql += " AND IsDeleted = 0";
            }

            using (var connection = Connection)
            {
                return connection.QueryFirstOrDefault<T>(sql);
            }
        }

        public override long Insert(T entity)
        {
            var now = DateTime.Now;
            entity.CreatedAt = now;
            entity.ModifiedAt = now;
            entity.IsDeleted = false;

            using (var connection = Connection)
            {
                return connection.Insert(entity);
            }
        }
        public override long Insert(IEnumerable<T> entities)
        {
            var now = DateTime.Now;
            foreach (var entity in entities)
            {
                entity.CreatedAt = now;
                entity.ModifiedAt = now;
                entity.IsDeleted = false;
            }

            using (var connection = Connection)
            {
                return connection.Insert(entities);
            }
        }

        public override bool Update(T entity)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                var _oldEntity = FindById(entity.Id);
                entity.CreatedAt = _oldEntity.CreatedAt;
                entity.IsDeleted = false;
                entity.ModifiedAt = DateTime.Now;

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
        public override bool Update(IEnumerable<T> entities)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                foreach (var entity in entities)
                {
                    var _oldEntity = FindById(entity.Id);
                    entity.CreatedAt = _oldEntity.CreatedAt;
                    entity.IsDeleted = false;
                    entity.ModifiedAt = DateTime.Now;
                }

                try
                {
                    using (var connection = Connection)
                    {
                        return connection.Update(entities);
                    }
                }
                catch (Exception)
                {
                    scope.Dispose();
                    return false;
                }
            }
        }

        public override bool Delete(int? id)
        {
            if (id == null)
                return false;

            string sql = $"UPDATE {TableName} SET IsDeleted = 1 WHERE Id = {id}";

            try
            {
                using (var connection = Connection)
                {
                    int count = connection.Execute(sql);
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
        public override bool Delete(T entity)
        {
            return Delete(entity.Id);
        }
        public virtual long Delete(IEnumerable<T> entities)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                long successCount = 0;
                try
                {
                    foreach (var entity in entities)
                    {
                        if (Delete(entity))
                        {
                            successCount++;
                        }
                    }
                    return successCount;
                }
                catch (Exception)
                {
                    scope.Dispose();
                    return 0;
                }
            }
        }
    }
}
