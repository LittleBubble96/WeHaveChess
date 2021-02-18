using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampData : DataModelBase , IListMax
{
    public int ID;

    public string Name;

    public string Des;

    public int CampCount;

    public int TargetType;

    public int TargetCount;

    public int AttributeType;

    public int CampType;

    public int Compare => CampCount;
}
