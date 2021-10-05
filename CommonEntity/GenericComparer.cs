using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.UI.WebControls;
namespace CommonEntity
{
    public class GenericComparer<T> : IComparer<T>
    {
        private SortDirection _sortDirection;
        private string _sortExpression;

        /// <summary>
        /// Direction in which to sort.
        /// </summary>
        public SortDirection SortDirection
        {
            get { return this._sortDirection; }
            set { this._sortDirection = value; }
        }

        public GenericComparer(string sortExpression, SortDirection sortDirection)
        {
            this._sortExpression = sortExpression;
            this._sortDirection = sortDirection;
        }

        public int Compare(T x, T y)
        {
            PropertyInfo propertyInfo = typeof(T).GetProperty(_sortExpression);
            IComparable obj1 = (IComparable)propertyInfo.GetValue(x, null);
            IComparable obj2 = (IComparable)propertyInfo.GetValue(y, null);

            if (SortDirection == SortDirection.Ascending)
            {
                return obj1.CompareTo(obj2);
            }
            else return obj2.CompareTo(obj1);
        }
    }
}
