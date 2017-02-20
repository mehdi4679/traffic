using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficPlanCL
{
 public   class ClCar:Grid
  {
private int? _CarID;
public int? CarID {
get { return _CarID; }
set { _CarID = value; }
}

private int? _CarOFcompanyID;
public int? CarOFcompanyID
{
    get { return _CarOFcompanyID; }
    set { _CarOFcompanyID = value; }
}

private int? _PersonID; 
     public int? PersonID {
         get { return _PersonID; }
         set { _PersonID = value; }
}

     private int? _yearID;
public int? yearID
{
    get { return _yearID; }
    set { _yearID = value; }
}

private String _Pelak;
public String Pelak {
get { return _Pelak; }
set { _Pelak = value; }
}
private String _CarType;
public String CarType
{
get { return _CarType; }
set { _CarType = value; }
}

private String _SacrificeName;
public String SacrificeName
{
    get { return _SacrificeName; }
    set { _SacrificeName = value; }
}

private String _SacrificePercent;
public String SacrificePercent
{
    get { return _SacrificePercent; }
    set { _SacrificePercent = value; }
}

private String _CarModel;
public String CarModel
{
get { return _CarModel; }
set { _CarModel = value; }
}
private string _CarColor;
public string  CarColor {
get { return _CarColor; }
set { _CarColor = value; }
}
private int? _CarCapacity;
public int? CarCapacity {
get { return _CarCapacity; }
set { _CarCapacity = value; }
}
private String _VIN;
public String VIN {
get { return _VIN; }
set { _VIN = value; }
}
 
}
}
