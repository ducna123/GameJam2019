using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class UIManager : SingletonBind<UIManager>
{
    [SerializeField] private Image blackBG;
    [Header("Popup")]
    public GameObject panelInGame;
    public GameObject popUpSetting;
    public HomePanel panelHome;
    public WinPopup winpop;
    public LosePopup lospop;
    public ConfirmPopup confirmPopup;
    public LevelMenu panelLevelMenu;


    public void ShowConfirmPop(string content, Action yes, Action no) {
        confirmPopup.ShowPopup(content, yes, no);
    }

    public void ShowFrame(FrameBase frame, bool isBlackBG = true) {
        if (blackBG) {
            blackBG.DOFade(0.5f, 0.1f);
        }
        frame.Show(); 
    }

    public void HideFrame(FrameBase frame, bool isBlackBG = true) {
        if (blackBG) {
            blackBG.DOFade(0.5f, 0.1f);
        }
        frame.Hide();
    }
}
