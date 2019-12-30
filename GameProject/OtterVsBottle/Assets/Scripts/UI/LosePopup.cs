using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosePopup : FrameBase
{
    [SerializeField] private ButtonBase btnReplay;
    [SerializeField] private ButtonBase btnHome;

    private void Start() {
        btnReplay.onClick.AddListener(OnButtonReplay);
        btnHome.onClick.AddListener(OnButtonHome);
    }

    private void OnButtonReplay() {

        MapController.Instance.LoadMap();
        UIManager.Instance.lospop.Hide();

    }
    private void OnButtonHome() {
        UIManager.Instance.lospop.Hide();
        UIManager.Instance.panelHome.Show();
        MovePlayer.Instance.hide();
    }
}
