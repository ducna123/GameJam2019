using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(ToolMapController))]
public class ToolMapEditor : Editor
{
    ToolMapController mapConl;
    public List<CellInMap> listCell = new List<CellInMap>();
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        mapConl = (ToolMapController)target;
        if (mapConl.panelMap == null || mapConl.cube == null) SetRef();

        if (GUILayout.Button("Show Map")) {
            ShowMap();
        }
        if(GUILayout.Button("Save map")) {
            SaveMap();
        }
    }
    private void SetRef() {
        mapConl.panelMap = mapConl.transform.GetChild(0);
        mapConl.cube = AssetDatabase.LoadAssetAtPath<CellInMap>("Assets/ToolMap/CellInMap.prefab");
    }
    private void RefreshMap() {
        listCell.Clear();
        int num = mapConl.panelMap.childCount;
        for(int i = 0; i< num; i++) {
            var chil = mapConl.panelMap.GetChild(0);
            DestroyImmediate(chil.gameObject);
        } 
    }
     
    public void ShowMap() {
        RefreshMap();
        var map = mapConl.panelMap.GetComponent<GridLayoutGroup>();
        map.constraintCount = mapConl.Collum;

        for (int i = 0; i < mapConl.Row; i++) {
            for (int j = 0; j < mapConl.Collum; j++) { 
                var temp = Instantiate<CellInMap>(mapConl.cube) ;
                temp.transform.SetParent(mapConl.panelMap);
                temp.name = string.Format("Cell[{0},{1}]", i,j);
      //          listCell.Add(temp);
            }
        }
    }
    private void SaveMap() { 
        var map = AssetDatabase.LoadAssetAtPath<MapInfo>(string.Format("Assets/Data/Resource/Map/MapData{0}.asset", mapConl.Level));
        if (map == null) {
            EditorUtility.DisplayDialog("asset null" , "you must creat asset for level befor save it " + mapConl.Level , "OK");
            return;
        }

        listCell.Clear();
        for (int i = 0; i<mapConl.panelMap.childCount; i++) {
            listCell.Add(mapConl.panelMap.GetChild(i).GetComponent<CellInMap>());
            //Debug.Log("cell : " + listCell[i].name + "    " + listCell[i].type);
        }
        //Debug.Log("List : " + listCell.Count);
        map.CreatMap(mapConl.Row, mapConl.Collum, listCell);
        EditorUtility.SetDirty(map);
        AssetDatabase.SaveAssets();
    }
}
