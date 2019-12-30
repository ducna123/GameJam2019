using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPopup : FrameBase
{
    [SerializeField] private ButtonBase btnNextLevel;
    [SerializeField] private ButtonBase btnHome;
    [SerializeField] private ButtonBase btnReplay;

    private void Start() {
        btnNextLevel.onClick.AddListener(OnbuttonNextLevel);
        btnReplay.onClick.AddListener(OnButtonReplay);
        btnHome.onClick.AddListener(OnButtonHome);
    }
    private void OnbuttonNextLevel() {
        PrefCache.SetCurLevel(PrefCache.GetCurLevel() + 1);
        UIManager.Instance.winpop.Hide();
        MapController.Instance.LoadMap();
    }

    private void OnButtonReplay() {
        MapController.Instance.LoadMap();
        UIManager.Instance.winpop.Hide();
    }
    private void OnButtonHome() {
        UIManager.Instance.lospop.Hide();
        UIManager.Instance.panelHome.Show();
        MovePlayer.Instance.hide();
    }

}
