using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficPlanCL
{
 public   class ClDiscountPrice:Grid
  {
private int? _DiscountPriceID;
public int? DiscountPriceID {
get { return _DiscountPriceID; }
set { _DiscountPriceID = value; }
}
private int? _RepeatTypeID;
public int? RepeatTypeID {
get { return _RepeatTypeID; }
set { _RepeatTypeID = value; }
}
private int? _DiscountID;
public int? DiscountID {
get { return _DiscountID; }
set { _DiscountID = value; }
}
private int? _Price;
public int? Price {
get { return _Price; }
set { _Price = value; }
}

}
}
