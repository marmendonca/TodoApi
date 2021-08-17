﻿using System;
using System.Linq.Expressions;
using Todo.Domain.Entities;

namespace Todo.Domain.Infra.Queries
{
    public static class TodoQueries
    {
        public static Expression<Func<TodoItem, bool>> GetAll(string user)
        {
            return x => x.User == user;
        }

        public static Expression<Func<TodoItem, bool>> GetAllDone(string user)
        {
            return x => x.User == user && x.Done;
        }

        public static Expression<Func<TodoItem, bool>> GetAllUndone(string user)
        {
            return x => x.User == user && x.Done == false;
        }

        public static Expression<Func<TodoItem, bool>> GetByPeriod(string user, DateTime date, bool done)
        {
            return x => x.User == user && x.Done == done && x.Date == date.Date;
        }

        //public static Expression<Func<TodoItem, bool>> OrderByDate(DateTime date)
        //{
        //    return x => x.Date == date;
        //}

        public static Expression<Func<TodoItem, bool>> GetById(Guid id, string user)
        {
            return x => x.Id == id && x.User == user;
        }
    }
}
