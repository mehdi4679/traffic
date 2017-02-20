using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficPlanCL
{
 public   class ClPelakChange:Grid
  {
private int? _PelakChangeID;
public int? PelakChangeID {
get { return _PelakChangeID; }
set { _PelakChangeID = value; }
}

private int? _PersonalID;
public int? PersonalID
{
    get { return _PersonalID; }
    set { _PersonalID = value; }
}

private int? _FromCarID;
public int? FromCarID {
get { return _FromCarID; }
set { _FromCarID = value; }
}
private int? _ToCarID;
public int? ToCarID {
get { return _ToCarID; }
set { _ToCarID = value; }
}

private int? _RequestTrafficID;
public int? RequestTrafficID
{
    get { return _RequestTrafficID; }
    set { _RequestTrafficID = value; }
}

private string _Pelak;
public string Pelak
{
    get { return _Pelak; }
    set { _Pelak = value; }
}

private string  _sysDATE;
public string sysDATE
{
get { return _sysDATE; }
set { _sysDATE = value; }
}
private int? _RequestUser;
public int? RequestUser {
get { return _RequestUser; }
set { _RequestUser = value; }
}
private int? _NazarID;
public int? NazarID {
get { return _NazarID; }
set { _NazarID = value; }
}

private string _NazarDate;
public string NazarDate
{
    get { return _NazarDate; }
    set { _NazarDate = value; }
}

private String _CommentUser;
public String CommentUser {
get { return _CommentUser; }
set { _CommentUser = value; }
}

private String _RahCode;
public String  RahCode {
    get { return _RahCode; }
    set { _RahCode = value; }
}

private String _CommentNazar;
public String CommentNazar {
get { return _CommentNazar; }
set { _CommentNazar = value; }
}

}
}
