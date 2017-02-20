using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficPlanCL
{
 public   class ClSahm:Grid
  {
private int? _SahmID;
public int? SahmID {
get { return _SahmID; }
set { _SahmID = value; }
}
private int? _CompanyID;
public int? CompanyID {
get { return _CompanyID; }
set { _CompanyID = value; }
}
private int? _DiscountTypeID;
public int? DiscountTypeID {
get { return _DiscountTypeID; }
set { _DiscountTypeID = value; }
}
private int? _sahmNumbre;
public int? sahmNumbre {
get { return _sahmNumbre; }
set { _sahmNumbre = value; }
}
private int? _DiscountPersent;
public int? DiscountPersent {
get { return _DiscountPersent; }
set { _DiscountPersent = value; }
}
private String _Comment;
public String Comment {
get { return _Comment; }
set { _Comment = value; }
}
private String _RegDate;
public String RegDate
{
get { return _RegDate; }
set { _RegDate = value; }
}
private int? _RegUser;
public int? RegUser {
get { return _RegUser; }
set { _RegUser = value; }
}
private int? _Year;
public int? Year {
get { return _Year; }
set { _Year = value; }
}

}
}
