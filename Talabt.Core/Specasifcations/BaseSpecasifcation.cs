﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabt.Core.Entities;

namespace Talabt.Core.Specasifcations
{
    public class BaseSpecasifcation<T> : ISpecasifcations<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>>? Criteria { get; set; } = null;
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();

        public BaseSpecasifcation()
        {
            // get initizae  Includes  with list
            // Criteria = null
        }

        public BaseSpecasifcation(Expression<Func<T, bool>> Criteria)
        {
            this.Criteria = Criteria;
        }

    }
}
