using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficPlanCL
{
 public   class ClCompany:Grid
  {
private int? _CompanyID;
public int? CompanyID {
get { return _CompanyID; }
set { _CompanyID = value; }
}
private int? _CompanyTypeID;
public int? CompanyTypeID
{
    get { return _CompanyTypeID; }
    set { _CompanyTypeID = value; }
}

private String _CompanyName;
public String CompanyName {
get { return _CompanyName; }
set { _CompanyName = value; }
}
private String _ManageName;
public String ManageName {
get { return _ManageName; }
set { _ManageName = value; }
}
private String _CompanyTel;
public String CompanyTel {
get { return _CompanyTel; }
set { _CompanyTel = value; }
}
private String _ComapnyAdress;
public String ComapnyAdress {
get { return _ComapnyAdress; }
set { _ComapnyAdress = value; }
}
private String _RepresentativeName;
public String RepresentativeName {
get { return _RepresentativeName; }
set { _RepresentativeName = value; }
}
private String _RepresentativeMobile;
public String RepresentativeMobile {
get { return _RepresentativeMobile; }
set { _RepresentativeMobile = value; }
}
private String _CompanyEmail;
public String CompanyEmail {
get { return _CompanyEmail; }
set { _CompanyEmail = value; }
}
private int? _PersonalID;
public int? PersonalID
{
    get { return _PersonalID; }
    set { _PersonalID = value; }
}
}
}
