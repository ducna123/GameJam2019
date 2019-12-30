using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellInMap : MonoBehaviour
{
    public CellType type;
}
public enum CellType
{
    normal = 0,
    wall = 1,
    start = 2,
    end = 3,
    power = 4,
    waste1 = 5,
    waste2 = 6,
    boss = 7,
    trap = 8,
    door1 = 9,
    door1_2 = 10,
    door2_1 = 11,
    door2_2 = 12,
    door3_1 = 13,
    door3_2 = 14,
}
