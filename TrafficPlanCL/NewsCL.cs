using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficPlanCL
{
 public   class ClNews:Grid
  {
private int? _NewID;
public int? NewID {
get { return _NewID; }
set { _NewID = value; }
}
private int? _ForCatalogID;
public int? ForCatalogID {
get { return _ForCatalogID; }
set { _ForCatalogID = value; }
}
private String _Title;
public String Title {
get { return _Title; }
set { _Title = value; }
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

}
}
