using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficPlanCL
{
 public   class ClSharj:Grid
  {
private int? _SharjID;
public int? SharjID {
get { return _SharjID; }
set { _SharjID = value; }
}
private int? _PersonalID;
public int? PersonalID {
get { return _PersonalID; }
set { _PersonalID = value; }
}

private string  _CodeMelli;
public string CodeMelli
{
    get { return _CodeMelli; }
    set { _CodeMelli = value; }
}

 

private int? _ShariPrice;
public int? ShariPrice
{
get { return _ShariPrice; }
set { _ShariPrice = value; }
}
private String _ShajComment;
public String ShajComment {
get { return _ShajComment; }
set { _ShajComment = value; }
}
private string _SharjDate;
public string SharjDate
{
get { return _SharjDate; }
set { _SharjDate = value; }
}

private string _Mobile;
public string Mobile
{
    get { return _Mobile; }
    set { _Mobile = value; }
}

private int? _ISExpire;
public int? ISExpire {
get { return _ISExpire; }
set { _ISExpire = value; }
}
private int? _IsZero;
public int? IsZero {
get { return _IsZero; }
set { _IsZero = value; }
}

}
}
