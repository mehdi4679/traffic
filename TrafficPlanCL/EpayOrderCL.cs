using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficPlanCL
{
 public   class ClEpayOrder:Grid
  {
private int? _EpayOrderID;
public int? EpayOrderID {
get { return _EpayOrderID; }
set { _EpayOrderID = value; }
}
private int? _RequestID;
public int? RequestID {
get { return _RequestID; }
set { _RequestID = value; }
}

private int? _SharjID;
public int? SharjID
{
    get { return _SharjID; }
    set { _SharjID = value; }
}

private String _IP;
public String IP {
get { return _IP; }
set { _IP = value; }
}
private String _OS;
public String OS {
get { return _OS; }
set { _OS = value; }
}
private String _Browser;
public String Browser {
get { return _Browser; }
set { _Browser = value; }
}
private int? _Prcie;
public int? Prcie {
get { return _Prcie; }
set { _Prcie = value; }
}

private int? _GroupID;
public int? GroupID {
    get { return _GroupID; }
    set { _GroupID = value; }
}

private string _OrderDateStart;
public string OrderDateStart
{
get { return _OrderDateStart; }
set { _OrderDateStart = value; }
}
private string _OrderDateEND;
public string OrderDateEND
{
get { return _OrderDateEND; }
set { _OrderDateEND = value; }
}
private String _OrderStatus;
public String OrderStatus
{
get { return _OrderStatus; }
set { _OrderStatus = value; }
}
private String _RefId;
public String RefId {
get { return _RefId; }
set { _RefId = value; }
}
private String _ResCode;
public String ResCode {
get { return _ResCode; }
set { _ResCode = value; }
}
private String _SaleOrderId;
public String SaleOrderId {
get { return _SaleOrderId; }
set { _SaleOrderId = value; }
}
private String _SaleReferenceId;
public String SaleReferenceId {
get { return _SaleReferenceId; }
set { _SaleReferenceId = value; }
}
private String _Comment;
public String Comment {
get { return _Comment; }
set { _Comment = value; }
}


private String _VerifyResult;
public String VerifyResult
{
    get { return _VerifyResult; }
    set { _VerifyResult = value; }
}
}
}
