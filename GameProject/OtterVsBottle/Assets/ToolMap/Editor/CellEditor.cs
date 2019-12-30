using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(CellInMap))]
public class CellEditor : Editor
{
    private CellInMap cell; 
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        cell = (CellInMap)target;
        ChooseOption(); 
      
    }
    private void ChooseOption() {
        Image img = cell.GetComponent<Image>();
        var t = cell.type;
        switch (t) {
            case CellType.normal:
                img.color = Color.white;
                break;
            case CellType.power:
                img.color = Color.green;
                break;            
            case CellType.door1:
                img.color = Color.red;
                break;
            case CellType.door1_2:
                img.color = Color.red;
                break;
            case CellType.door2_1:
                img.color = Color.cyan;
                break;
            case CellType.door2_2:
                img.color = Color.cyan;
                break;
            case CellType.waste1:
                img.color = Color.blue;
                break;
            case CellType.waste2:
                img.color = Color.blue;
                break;
            case CellType.start:
                img.color = Color.yellow;
                break;
            case CellType.end:
                img.color = Color.grey;
                break;
            case CellType.wall:
                img.color = Color.black;
                break;
            case CellType.trap:
                img.color = new Color((float)204/255, 0.2f, 1);
                break;
            case CellType.boss:
                img.color = new Color(1, 0.6f,0, 1);
                break;
            case CellType.door3_1:
                img.color = new Color(0.7f, 1, 0, 1);
                break;
            case CellType.door3_2:
                img.color = new Color(0.7f, 1, 0, 1);
                break;
        }
    }
}
