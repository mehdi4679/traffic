using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficPlanCL
{
 public   class ClRequestDiscount:Grid
  {
private int? _DisCountRequestID;
public int? DisCountRequestID {
get { return _DisCountRequestID; }
set { _DisCountRequestID = value; }
}
private int? _RequestID;
public int? RequestID {
get { return _RequestID; }
set { _RequestID = value; }
}
private int? _DiscountPriceID;
public int? DiscountPriceID {
get { return _DiscountPriceID; }
set { _DiscountPriceID = value; }
}
private String _DiscountCode;
public String DiscountCode {
get { return _DiscountCode; }
set { _DiscountCode = value; }
}
private String _Adress;
public String Adress {
get { return _Adress; }
set { _Adress = value; }
}
private String _DiscountComment;
public String DiscountComment {
get { return _DiscountComment; }
set { _DiscountComment = value; }
}
private String _DiscountAttach;
public String DiscountAttach {
get { return _DiscountAttach; }
set { _DiscountAttach = value; }
}

}
}
