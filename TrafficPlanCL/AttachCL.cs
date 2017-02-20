using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficPlanCL
{
 public   class ClAttach:Grid
  {
private int? _AttachID;
public int? AttachID {
get { return _AttachID; }
set { _AttachID = value; }
}
private String _AttachName;
public String AttachName {
get { return _AttachName; }
set { _AttachName = value; }
}
private String _ForTable;
public String ForTable {
get { return _ForTable; }
set { _ForTable = value; }
}
private int? _ForID;
public int? ForID
{
get { return _ForID; }
set { _ForID = value; }
}
private int? _ForCatalogType;
public int? ForCatalogType {
get { return _ForCatalogType; }
set { _ForCatalogType = value; }
}
private int? _ForCatalogValue;
public int? ForCatalogValue {
get { return _ForCatalogValue; }
set { _ForCatalogValue = value; }
}
private int? _CreateUser;
public int? CreateUser {
get { return _CreateUser; }
set { _CreateUser = value; }
}
private String  _createDate;
public String createDate
{
get { return _createDate; }
set { _createDate = value; }
}
private int? _Compelete;
public int? Compelete {
get { return _Compelete; }
set { _Compelete = value; }
}
private String _MelliCode;
public String Mellicode
{
    get { return _MelliCode; }
    set { _MelliCode = value; }
}
private int? _PersonalID;
public int? PersonalID
{
    get { return _PersonalID; }
    set { _PersonalID = value; }
}


}

}
