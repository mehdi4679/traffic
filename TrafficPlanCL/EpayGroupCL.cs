using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficPlanCL
{
 public   class ClEpayGroup:Grid
  {
private int? _EpayGroupID;
public int? EpayGroupID {
get { return _EpayGroupID; }
set { _EpayGroupID = value; }
}
private int? _GroupID;
public int? GroupID {
get { return _GroupID; }
set { _GroupID = value; }
}
private int? _ReqID;
public int? ReqID {
get { return _ReqID; }
set { _ReqID = value; }
}

private string _DareReg;
public string DareReg
{
get { return _DareReg; }
set { _DareReg = value; }
}

private string _AllReq;
public string AllReq
{
    get { return _AllReq; }
    set { _AllReq = value; }
}


private int? _PersonalID;
public int? PersonalID {
get { return _PersonalID; }
set { _PersonalID = value; }
}

}
}
