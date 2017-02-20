using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficPlanCL
{
 public   class ClPersonal:Grid
  {
private int? _PersonalID;
public int? PersonalID {
get { return _PersonalID; }
set { _PersonalID = value; }
}
private String _NationalCode;
public String NationalCode {
get { return _NationalCode; }
set { _NationalCode = value; }
}
private String _FirstName;
public String FirstName {
get { return _FirstName; }
set { _FirstName = value; }
}
private String _LastName;
public String LastName {
get { return _LastName; }
set { _LastName = value; }
}
private String _PersonalAdress;
public String PersonalAdress {
get { return _PersonalAdress; }
set { _PersonalAdress = value; }
}
private String _PostiCode;
public String PostiCode {
get { return _PostiCode; }
set { _PostiCode = value; }
}
private String _PersonalTel;
public String PersonalTel {
get { return _PersonalTel; }
set { _PersonalTel = value; }
}
private String _PersonalMobile;
public String PersonalMobile {
get { return _PersonalMobile; }
set { _PersonalMobile = value; }
}
private String _JobName;
public String JobName {
get { return _JobName; }
set { _JobName = value; }
}
private String _Email;
public String Email {
get { return _Email; }
set { _Email = value; }
}
private String _Pass;
public String Pass {
    get { return _Pass; }
    set { _Pass = value; }
}

private int? _IsInActive;
public int? IsInActive
{
    get { return _IsInActive; }
    set { _IsInActive = value; }
}

private int? _CompanyID;
public int? CompanyID
{
    get { return _CompanyID; }
    set { _CompanyID = value; }
}


}
}
