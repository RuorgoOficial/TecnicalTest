using CodereTecnicalTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodereTecnicalTest.Domain.Abstractions
{
    public abstract class SpecificationBase<T> : ISpecification<T>
        where T : Base
    {
        public SpecificationBase(Expression<Func<T, bool>> criteria) {
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; }

        public Expression<Func<T, object>>? OrderBy { get; private set; }

        protected void WithOrderBy(Expression<Func<T, object>> orderBy) { 
            OrderBy = orderBy;
        }
    }
}
