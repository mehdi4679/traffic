using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrafficPlanCL
{
    public class Grid
    {
        private int _RowCount = 0;
        public int RowCount
        {
            get { return _RowCount; }
            set { _RowCount = value; }
        }
        private int _PageIndex = 1;
        public int PageIndex
        {
            get { return _PageIndex; }
            set { _PageIndex = value; }
        }
        private int _PageSize = 10;
        public int PageSize
        {
            get { return _PageSize; }
            set { _PageSize = value; }
        }
        private string _OrderDirection;
        public string OrderDirection
        {
            get { return _OrderDirection; }
            set { _OrderDirection = value; }
        }
        private string _OrderBy;
        public string  OrderBy
        {
            get { return _OrderBy; }
            set { _OrderBy = value; }
        }
    }
}