using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{

    public static MovePlayer Instance;

    [Header("IN4")]
    public int speed = 1;
    public int mana;
    public GameObject panelMana, panelTrash;

    public List<GameObject> listMana = new List<GameObject>();
    public List<GameObject> listTrash = new List<GameObject>();
    public AudioSource audio;
    public AudioClip jump,upMana, winAudio,lose;

    [Header("UI")]

    public Button btnBack;
    public Button btnReplay;
    public Button btnHome;

    Vector3 pointTouch, pointDrag;

    Vector2 nowPos;

    public int[,] mapUpdate = new int[7, 7];
    public List<Vector2> way = new List<Vector2>();
    public List<GameObject> lineObj = new List<GameObject>();

    [Header("Player")]
    public GameObject player;
    [SerializeField] private Animator animPlayer;
    private string animWalk = "Walk";
    private string animIdle = "Idle";
    private string animShake = "Shake";
    private bool isMoving = false;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
        MapController.Instance.OnLoadMapDone = () =>
        {

            for (int i = 0; i < lineObj.Count; i++) Destroy(lineObj[i].gameObject);

            lineObj.Clear();
            way.Clear();

            btnBack.gameObject.SetActive(true);
            btnReplay.gameObject.SetActive(true);
            btnHome.gameObject.SetActive(true);


            btnBack.onClick.RemoveAllListeners();
            btnReplay.onClick.RemoveAllListeners();

            btnReplay.onClick.AddListener(() =>
            {
                MapController.Instance.LoadMap();
            });

            btnBack.onClick.AddListener(() =>
            {
                MoveBack();
            });


            btnHome.onClick.AddListener(() =>
            {
                UIManager.Instance.lospop.Hide();
                UIManager.Instance.panelHome.Show();
                MovePlayer.Instance.hide();
            });

            mana = 2;
            nowPos = MapController.Instance.playerPos;


            for (int i = 0; i < 7; i++)
            {
                for(int j = 0; j < 7; j++)
                {
                    mapUpdate[i,j] = MapController.Instance.mapMatrix[i,j];
                }
            }

            for (int i = 0; i < mana; i++) listMana[i].SetActive(true);
            for (int i = 0; i < MapController.Instance.countTrash; i++) listTrash[i].SetActive(true);

        };

    }

    public void OnDown()
    {
        pointTouch = Input.mousePosition;
    }

    void UpDateMatrix(Vector2 pos, int value)
    {
        //print("update : " + pos);
        mapUpdate[(int)pos.y, (int)pos.x] = value;
        string s = "";
        for (int i = 0; i < mapUpdate.GetLength(1); i++)
        {
            s += "\n";
            for (int j = 0; j < mapUpdate.GetLength(0); j++)
            {
                s += mapUpdate[i, j] + " ";
            }
        }
        print(s);
    }

    public void OnUp()
    {
        pointDrag = Input.mousePosition;

        speed = 1;

        float dis = Vector3.Distance(pointTouch, pointDrag);

        float valueX = Mathf.Abs(pointDrag.x) - Mathf.Abs(pointTouch.x);
        float valueY = Mathf.Abs(pointDrag.y) - Mathf.Abs(pointTouch.y);

        //move doc
        if (Mathf.Abs(valueX) <= Mathf.Abs(valueY))
        {
            if (pointDrag.y > pointTouch.y)
            {
                MoveUp(true);
            }
            else MoveUp(false);
        }
        else //move ngang
        {
            if (pointDrag.x < pointTouch.x)
            {
                MoveLeft(true);
            }
            else MoveLeft(false);
        }
    }

    void CheckItemNext(int x, int y,bool isVer)
    {
        int tmp = MapController.Instance.mapMatrix[y, x];
        //if (isVer) tmp = mapUpdate[x, y];
        GameObject item = MapController.Instance.listClone[MapController.Instance.row * y + x];
        //print(tmp);
        switch (tmp)
        {
            case 3://end game
                if (isClear)
                {
                    Win();
                }
                break;
            case 4://mana
                audio.PlayOneShot(upMana);
                UpdateMana(1);
                break;
            case 5://waste 1
                ClearWaste(-1);
                break;
            case 6://waste 2
                ClearWaste(-2);
                break;
            case 7://boss

                break;
            case 8://trap
                UpdateMana(-1);
                break;
            case 9:
                print("tele to d12");
                //Tele(9,y,x);
                break;
            case 10:
                print("tele to d11");
                //Tele(10, y, x);
                break;
            case 11:
                print("tele to d22");
                //Tele(11, y, x);
                break;
            case 12:
                print("tele to d21");
                //Tele(12, y, x);
                break;
        }
        if (tmp != 3 && tmp != 9 && tmp != 10 && tmp != 11 && tmp != 12) item.SetActive(false);
    }

    private void Win()
    {
        audio.PlayOneShot(winAudio);
        int lv = PrefCache.GetCurLevel();
        lv++;
        PrefCache.SetCurLevel(lv);
        PrefCache.SetOpenLevel(lv);
        UIManager.Instance.winpop.Show();
    }

    void UpdateMana(int value)
    {
        if (value < 0)
        {
            if (mana + value > 0) mana += value;
            else mana = 0;
            for (int i = listMana.Count - 1; i >= mana; i--) listMana[i].SetActive(false);

        }
        else
        {
            if (mana + value < 2) mana += value;
            else mana = 2;
            for (int i = 0; i < mana; i++) listMana[i].SetActive(true);
        }
    }

    void Tele(int idDoor,int y,int x)
    {
        if (idDoor == 9) player.transform.position = MapController.Instance.posD12;
        else if (idDoor == 10) player.transform.position = MapController.Instance.posD11;
        else if (idDoor == 11) player.transform.position = MapController.Instance.posD22;
        else if (idDoor == 12) player.transform.position = MapController.Instance.posD21;
        way.Add(nowPos);

        nowPos = new Vector2(y, x);
    }

    bool isClear = false;

    void ClearWaste(int value)
    {
        if (mana >= -value)
        {
            MapController.Instance.countTrash--;
            listTrash[MapController.Instance.countTrash].SetActive(false);
            UpdateMana(value);
            if(MapController.Instance.countTrash == 0)
            {
                isClear = true;
            }
        }
        else Die();
    }

    void Die()
    {
        audio.PlayOneShot(lose);
        print("die");
        UIManager.Instance.lospop.Show();
    }

    public void hide()
    {
        btnBack.gameObject.SetActive(false);
        btnReplay.gameObject.SetActive(false);
        btnHome.gameObject.SetActive(false);
        for (int i = 0; i < mana; i++) listMana[i].SetActive(false);
        for (int i = 0; i < listTrash.Count; i++) listTrash[i].SetActive(false);

    }

    private void RiseObj(Vector3 pos, bool isWaste)
    {
        GameObject leaf = Instantiate(MapController.Instance.line, MapController.Instance.gameObject.transform);
        leaf.SetActive(true);
        leaf.transform.position = pos;
        lineObj.Add(leaf);
        var line = leaf.GetComponent<Line>();
        line.Init(isWaste);
    }

    private void MoveUp(bool isUp)
    {
        int s = isUp ? speed : -speed;

        float z = player.transform.position.z;

        if (nowPos.y - s >= 0 && nowPos.y - s < 7)
        {
            var tmp = mapUpdate[(int)(nowPos.y), (int)nowPos.x];
            if (mapUpdate[(int)(nowPos.y - s), (int)nowPos.x] != 1)
            {
                if (mapUpdate[(int)(nowPos.y - s), (int)nowPos.x] == 3) {
                    if (!isClear) return;
                }
                audio.PlayOneShot(jump);
                way.Add(nowPos);
                UpDateMatrix(nowPos, 1);
                bool check = false;
                if (tmp == 5 || tmp == 6) check = true;
                RiseObj(new Vector3(player.transform.position.x, 0.5f, player.transform.position.z), check); 
                isMoving = true;
                player.transform.DOMoveZ(z + s, 0.2f).OnComplete(() =>
                {
                    animPlayer.Play(animIdle);
                });
                animPlayer.Play(animWalk);

                nowPos = new Vector2(nowPos.x, (nowPos.y - s));
                CheckItemNext((int)nowPos.x, (int)nowPos.y, false);
            }
        }
        else
        {
            //Vector2 pos = new Vector2((int)nowPos.x, (int)(nowPos.y - s));
            //if (way.Count > 0)
            //{
            //    if (pos == way[way.Count - 1])
            //    {
            //        Destroy(lineObj[lineObj.Count - 1]);
            //        lineObj.Remove(lineObj[lineObj.Count - 1]);
            //        isMoving = true;
            //        player.transform.DOMoveZ(z + s, 0.2f).OnComplete(() => {
            //            animPlayer.Play(animIdle);
            //        });
            //        animPlayer.Play(animWalk);
            //        int value = MapController.Instance.mapMatrix[(int)nowPos.y, (int)nowPos.x];

            //        UpDateMatrix(nowPos, value);

            //        if (value == 5) UpdateMana(1);
            //        if (value == 6) UpdateMana(2);

            //        if (value != 0)
            //        {
            //            MapController.Instance.listClone[MapController.Instance.row * (int)nowPos.y + (int)nowPos.x].SetActive(true);
            //        }

            //        nowPos = new Vector2((int)nowPos.x, (int)(nowPos.y - s));

            //        way.RemoveAt(way.Count - 1);
            //    }
            //}
        }
    }

    private void MoveLeft(bool isLeft)
    {
        int s = isLeft ? -speed : speed;

        float x = player.transform.position.x;

        if (nowPos.x + s >= 0 && nowPos.x + s < 7)
        {
            int tmp = mapUpdate[(int)(nowPos.y), (int)nowPos.x];

            if (mapUpdate[(int)(nowPos.y), (int)nowPos.x + s] != 1)
            {
                if (mapUpdate[(int)(nowPos.y), (int)nowPos.x + s] == 3) {
                    if (!isClear) return; 
                }
                audio.PlayOneShot(jump);
                way.Add(nowPos);
                UpDateMatrix(nowPos, 1);
                bool check = false ;
                if (tmp == 5 || tmp == 6) check = true; 
                RiseObj(new Vector3(player.transform.position.x, 0.5f, player.transform.position.z), check);
                isMoving = true;
                player.transform.DOMoveX(x + s, 0.2f).OnComplete(() =>
                {
                    animPlayer.Play(animIdle);
                });
                animPlayer.Play(animWalk);
                nowPos = new Vector2((int)nowPos.x + s, (int)(nowPos.y));
                CheckItemNext((int)nowPos.x, (int)nowPos.y, true);
            }
        }
        else
        {
            //    Vector2 pos = new Vector2((int)nowPos.x + s, (int)(nowPos.y));
            //    if (way.Count > 0)
            //    {
            //        if (pos == way[way.Count - 1])
            //        {
            //            Destroy(lineObj[lineObj.Count - 1]);
            //            lineObj.Remove(lineObj[lineObj.Count - 1]);
            //            isMoving = true;
            //            player.transform.DOMoveX(x + s, 0.2f);
            //            animPlayer.Play(animWalk);
            //            int value = MapController.Instance.mapMatrix[(int)nowPos.y, (int)nowPos.x];

            //            UpDateMatrix(nowPos, value);

            //            if (value == 5) UpdateMana(1);
            //            if (value == 6) UpdateMana(2);

            //            if (value != 0)
            //            {
            //                MapController.Instance.listClone[MapController.Instance.row * (int)nowPos.y + (int)nowPos.x].SetActive(true);
            //            }

            //            nowPos = new Vector2((int)nowPos.x + s, (int)(nowPos.y));

            //            way.RemoveAt(way.Count - 1);
            //        }
            //    }
        }

    }

    public void MoveBack()
    {
        if (way.Count > 0)
        {
            Vector2 pos = way[way.Count-1];

            if (pos.x == nowPos.x) player.transform.DOMoveZ(lineObj[lineObj.Count-1].transform.position.z, 0.2f).OnComplete(() => {
                animPlayer.Play(animIdle);
            });
            else player.transform.DOMoveX(lineObj[lineObj.Count - 1].transform.position.x, 0.2f).OnComplete(() => {
                animPlayer.Play(animIdle);
            }); 
            animPlayer.Play(animWalk);
            int value = MapController.Instance.mapMatrix[(int)nowPos.x, (int)nowPos.y];

            UpDateMatrix(nowPos, value);

            int value2 = MapController.Instance.mapMatrix[(int)nowPos.y, (int)nowPos.x];

            if (value2 != 0)
            {
                MapController.Instance.listClone[MapController.Instance.row * (int)nowPos.y + (int)nowPos.x].SetActive(true);
            }

            if (value2 == 5)
            {
                isClear = false;
                UpdateMana(1);
                MapController.Instance.countTrash++;
                for (int i = 0; i < MapController.Instance.countTrash; i++) listTrash[i].SetActive(true);
            }
            if (value2 == 6)
            {
                isClear = false;
                UpdateMana(2);
                MapController.Instance.countTrash++;
                for (int i = 0; i < MapController.Instance.countTrash; i++) listTrash[i].SetActive(true);
            }

            nowPos = way[way.Count - 1];
            
            way.RemoveAt(way.Count - 1);

            Destroy(lineObj[lineObj.Count - 1]);
            lineObj.Remove(lineObj[lineObj.Count - 1]);
        }
    }


}
