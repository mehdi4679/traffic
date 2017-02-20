using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficPlanCL
{
 public   class ClRequestRepeat:Grid
  {
private int? _RequestRepeatID;
public int? RequestRepeatID {
get { return _RequestRepeatID; }
set { _RequestRepeatID = value; }
}
private int? _RequestID;
public int? RequestID {
get { return _RequestID; }
set { _RequestID = value; }
}
private int? _RepeatTypeID;
public int? RepeatTypeID {
get { return _RepeatTypeID; }
set { _RepeatTypeID = value; }
}
private string _RepeatDate;
public string RepeatDate
{
get { return _RepeatDate; }
set { _RepeatDate = value; }
}
private int? _YearMonthSeasonID;
public int? YearMonthSeasonID {
get { return _YearMonthSeasonID; }
set { _YearMonthSeasonID = value; }
}

}
}
