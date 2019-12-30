using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
public class ToolMapController : MonoBehaviour
{
    [Header("MapController")]
    public int Level;
    public int Row;
    public int Collum;

    [HideInInspector]public Transform panelMap;
    [HideInInspector]public CellInMap cube;
     
 

}
