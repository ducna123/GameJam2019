using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "MapData", menuName = "ScriptableObjects/MapData", order = 1)]
public class MapInfo : ScriptableObject
{
    public int row, col;
    public List<cellInfo> cellInMap = new List<cellInfo>();

    public void CreatMap (int row, int coll, List<CellInMap> cells) {
        this.row = row;
        this.col = coll;
        int num = 0;
        cellInMap.Clear();
        for(int i = 0; i< row; i++) {
            for(int j = 0; j< coll; j++) {
                cellInMap.Add(new cellInfo(i, j, cells[num].type));
                num++;
            }
        }
    }
}
[Serializable]
public class cellInfo
{
    public int row;
    public int col;
    public CellType type;

    public cellInfo(int row, int col, CellType type){
        this.row = row;
        this.col = col;
        this.type = type;
        }
}
