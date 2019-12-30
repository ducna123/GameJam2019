using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenu : FrameBase
{
    private List<LeveInfo> levels = new List<LeveInfo>();
    [SerializeField] private LeveInfo level;
    [SerializeField] private Transform panelMenu;
    public Button btnHome;

    private void InitLevel(int numLevel) {
        int tmp = panelMenu.transform.GetChildCount();
        print(tmp);
        for (int i = 0; i < tmp; i++)
        {
            Destroy(panelMenu.GetChild(i).gameObject);
        }
        if(levels.Count <= 0) {
            for(int i = 0; i<numLevel; i++) {
                var temp = level.Spawn(panelMenu);
                temp.Init(i, PrefCache.GetLevelOpen(i));
            }
        }
    }

    public virtual void Show()
    {
        InitLevel(9);
        gameObject.SetActive(true);
    }
    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OnButtonHome()
    {
        UIManager.Instance.panelLevelMenu.Hide();
        UIManager.Instance.panelHome.Show();
        //MovePlayer.Instance.hide();
    }

}
