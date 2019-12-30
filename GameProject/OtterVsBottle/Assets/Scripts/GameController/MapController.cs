using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapController : MonoBehaviour
{

    public static MapController Instance; 

    public int[,] mapMatrix = new int[,]
    {
        { 0, 0, 0, 2, 0, 6, 0 },
        { 0, 0, 5, 0, 0, 0, 4 },
        { 4, 0, 0, 0, 4, 0, 0},
        { 0, 6, 0, 0, 0, 4, 0},
        { 0, 0, 0, 0, 5, 0, 0},
        { 0, 1, 0, 0, 0, 0, 0},
        { 0, 0, 4, 3, 0, 5, 0}
    };

    public int row = 6;
    public int col = 6;
    public int countTrash = 0;

    public Vector3 posD11;
    public Vector3 posD12;
    public Vector3 posD21;
    public Vector3 posD22;

    public GameObject player, line;

    public Vector2 playerPos;

    public List<GameObject> listBlock = new List<GameObject>();

    public System.Action OnLoadMapDone;

    public List<GameObject> listClone = new List<GameObject>();
    public List<GameObject> listNormal = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        //mapMatrix = MapManager.Instance.getCurMap(PrefCache.GetCurLevel() + 1);
        
    }

    public void LoadMap()
    {
        mapMatrix = MapManager.Instance.getCurMap(PrefCache.GetCurLevel() + 1);
        countTrash = 0;
        for(int i = 0; i < listClone.Count; i++)
        {
            if(listClone[i] != player)
                Destroy(listClone[i]);
        }

        listClone.Clear();

        row = mapMatrix.GetLength(1);
        col = mapMatrix.GetLength(0);

        Vector3 start = new Vector3(-row / 2, 0.5f, col / 2);

        for(int i = 0; i < row; i++)
        {
            for(int j = 0; j < col; j++)
            {
                GameObject clone = null;
                int tmp = mapMatrix[i,j];
                switch (tmp)
                {
                    case 0:// normal
                        clone = Instantiate(listBlock[8], this.gameObject.transform);
                        break;
                    case 1://block
                        clone = Instantiate(listBlock[0], this.gameObject.transform);
                        break;
                    case 2://player
                        clone = player;
                        player.transform.parent = this.transform;
                        playerPos = new Vector2(j, i);
                        break;
                    case 3://end game
                        clone = Instantiate(listBlock[2], this.gameObject.transform);
                        break;
                    case 4://mana
                        clone = Instantiate(listBlock[3], this.gameObject.transform);
                        break;
                    case 5://waste1
                        countTrash++;
                        clone = Instantiate(listBlock[4], this.gameObject.transform);
                        break;
                    case 6://waste2;
                        countTrash++;
                        clone = Instantiate(listBlock[5], this.gameObject.transform);
                        break;
                    case 7://boss
                        clone = Instantiate(listBlock[6], this.gameObject.transform);
                        break;
                    case 8://trap
                        clone = Instantiate(listBlock[7], this.gameObject.transform);
                        break;
                    case 9: case 10: case 11: case 12:
                        clone = Instantiate(listBlock[9], this.gameObject.transform);
                        break;

                }
                listClone.Add(clone);
                clone.transform.position = new Vector3(start.x + j, clone.transform.position.y, start.z - i);
                //pos door
                if (tmp == 9) posD11 = clone.transform.position;
                else if (tmp == 10) posD12 = clone.transform.position;
                else if (tmp == 11) posD21 = clone.transform.position;
                else if (tmp == 12) posD22 = clone.transform.position;

                if (tmp != 0)
                {
                    clone.SetActive(true);
                }
                if(tmp != 1) {
                    GameObject nor = Instantiate(listBlock[8], this.gameObject.transform);
                    nor.transform.position = new Vector3(start.x + j, 0, start.z - i);
                    nor.SetActive(true);
                    listNormal.Add(nor);
                }
            }
        }

        OnLoadMapDone?.Invoke();

    }
}
