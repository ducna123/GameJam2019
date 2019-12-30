using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : SingletonBind<MapManager>
{
    [SerializeField] private int curLevel = 0 ;

    protected override void Awake() {
        base.Awake();
        curLevel = PrefCache.GetCurLevel();
    }

    public int[,] getCurMap(int level) {
        var m = Resources.Load<MapInfo>("Map/MapData"+level);
        int num = 0;
        print(m);
        int[,] a = new int[m.row, m.col];
        for(int i =0; i< m.row; i++) {
            for(int j= 0; j<m.col; j++) {
                a[i, j] =(int) m.cellInMap[num].type;
                num++;
            } 
        }
        return a;
    }

}
