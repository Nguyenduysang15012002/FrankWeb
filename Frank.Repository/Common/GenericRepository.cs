using Frank.Model;
using Frank.Repository;
using Frank.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Web;

namespace Frank.Repository
{
    public  class GenericRepository<T> : IGenericRepository<T>
       where T : class
    {
        protected DbContext _entities;
        protected readonly IDbSet<T> _dbset;

        public GenericRepository(DbContext context)
        {

            _entities = context;
            _dbset = context.Set<T>();
        }

        public virtual IDbSet<T> DBSet()
        {
            return _dbset;
        }
        public virtual IEnumerable<T> GetAll()
        {

            return _dbset.AsEnumerable<T>();
        }
        public virtual IQueryable<T> GetAllAsQueryable()
        {
            //var lstInterFace = ((System.Reflection.TypeInfo)typeof(T).BaseType).ImplementedInterfaces;
            //if (lstInterFace != null && lstInterFace.Contains(typeof(IAuditableEntity)))
            //{
            //    return _dbset.AsQueryable<T>().Where(x => ((IAuditableEntity)x).IsDelete == false);
            //}
            return _dbset.AsQueryable<T>();
        }
        public IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            IEnumerable<T> query = _dbset.Where(predicate).AsEnumerable();
            return query;
        }

        public virtual T Add(T entity)
        {
            return _dbset.Add(entity);
        }

        public virtual T Delete(T entity)
        {
            return _dbset.Remove(entity);
        }

        public void Delete(Expression<Func<T, bool>> filter)
        {
            var entities = _dbset.Where(filter);
            foreach (var item in entities)
            {
                if (_entities.Entry(item).State == EntityState.Detached)
                {
                    _dbset.Attach(item);
                }
                _dbset.Remove(item);
            }
        }

        //public virtual void SoftDelete(T entity)
        //{
        //    IAuditableEntity entityPa = entity as IAuditableEntity;
        //    if (entity != null)
        //    {
        //        string identityName = Thread.CurrentPrincipal.Identity.Name;
        //        var userId = _entities.Set<AppUser>().Where(x => x.UserName == identityName).Select(x => x.Id).FirstOrDefault();
        //        entityPa.IsDelete = true;
        //        entityPa.DeleteTime = DateTime.Now;
        //        entityPa.DeleteId = userId;
        //        _entities.Entry(entityPa).State = System.Data.Entity.EntityState.Modified;
        //        _entities.SaveChanges();
        //    }
        //}


        public virtual void Edit(T entity)
        {
            _entities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }

        public T GetById(object id)
        {
            return _dbset.Find(id);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            foreach (var item in entities)
            {
                if (_entities.Entry(item).State == EntityState.Detached)
                {
                    _dbset.Attach(item);
                }
                _dbset.Remove(item);
            }
        }

        public List<SelectListItem> GetDropdown(string displayMember, string valueMember, object selected = null)
        {
            Type objType = typeof(T);
            List<SelectListItem> result = new List<SelectListItem>();
            if (string.IsNullOrEmpty(displayMember) == false && string.IsNullOrEmpty(valueMember) == false)
            {
                result = _dbset.ToList().Select(x => new SelectListItem()
                {
                    Value = objType.GetProperty(valueMember).GetValue(x).ToString(),
                    Text = objType.GetProperty(displayMember).GetValue(x).ToString(),
                    Selected = (selected != null) && selected.Equals(objType.GetProperty(valueMember).GetValue(x))
                }).ToList();
            }
            return result;
        }

        public List<SelectListItem> GetDropDownMultiple(string displayMember, string valueMember, List<object> selected = null)
        {
            Type objType = typeof(T);
            List<SelectListItem> result = new List<SelectListItem>();
            if (string.IsNullOrEmpty(displayMember) == false && string.IsNullOrEmpty(valueMember) == false)
            {
                result = _dbset.ToList().Select(x => new SelectListItem()
                {
                    Value = objType.GetProperty(valueMember).GetValue(x).ToString(),
                    Text = objType.GetProperty(displayMember).GetValue(x).ToString(),
                    Selected = (selected != null) && selected.Contains(objType.GetProperty(valueMember).GetValue(x))
                }).ToList();
            }
            return result;
        }

        public List<object> GetListFieldValue(string fieldName)
        {
            Type objType = typeof(T);
            List<object> result = null;
            try
            {
                result = _dbset.ToList()
                    .Select(x => objType.GetProperty(fieldName).GetValue(x)).ToList();
            }
            catch (Exception)
            {
                result = new List<object>();
            }
            return result;
        }

        public List<SelectListItem> GetDropdownFields(object selected = null)
        {
            Type objType = typeof(T);
            List<SelectListItem> result = new List<SelectListItem>();
            result = objType.GetProperties().Select(x => new SelectListItem()
            {
                Value = x.Name,
                Text = x.Name,
                Selected = (selected != null) && x.Name.Equals(selected)
            }).ToList();
            return result;
        }

        public List<T> GetEntitiesByFieldValue(string fieldName, object value)
        {
            Type objectType = typeof(T);
            List<T> result = _dbset.ToList()
                .Where(x => objectType.GetProperty(fieldName)
                .GetValue(x).Equals(value)).ToList();
            return result;
        }

        public List<T> GetEntitiesByMultipleFieldValue(params KeyValuePair<string, object>[] groupKeyValue)
        {
            Type objectType = typeof(T);
            List<T> result = _dbset.ToList();
            foreach (var pair in groupKeyValue)
            {
                result = result
                    .Where(x => objectType.GetProperty(pair.Key)
                    .GetValue(x).Equals(pair.Value)).ToList();
            }
            return result;
        }


        public T GetEmptyIfNullById(object id)
        {
            var entity = _dbset.Find(id) ?? Activator.CreateInstance(typeof(T)) as T;
            return entity;
        }

        public void InsertRange(IEnumerable<T> entities)
        {
            _entities.Set<T>().AddRange(entities);
        }

        public DbContext GetContext()
        {
            return _entities;
        }

        public T FindEmptyIfNullByExp(Expression<Func<T, bool>> predicate)
        {
            var entity = _entities.Set<T>().Where(predicate).FirstOrDefault() ?? Activator.CreateInstance(typeof(T)) as T;
            return entity;
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            foreach (var item in entities)
            {
                if (item == null)
                {
                    throw new ArgumentNullException("entity");
                }
                _dbset.Attach(item);
                _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            }
        }
    }
}
