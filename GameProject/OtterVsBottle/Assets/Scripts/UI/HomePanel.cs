using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePanel : FrameBase
{
    [SerializeField] private ButtonBase btnPlay;
    [SerializeField] private ButtonBase btnMenu;
    [SerializeField] private ButtonBase btnSetting;


    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            UIManager.Instance.ShowConfirmPop("Are you sure you want to quit the game???",()=> {
                Application.Quit();
            },()=> {
                UIManager.Instance.confirmPopup.Hide();
            });
        }
    }

    private void Start() {
        btnPlay.onClick.AddListener(OnButtonPlay);
        btnMenu.onClick.AddListener(OnbuttonMenu);
        btnSetting.onClick.AddListener(OnButtonSetting);
    }

    private void OnButtonPlay() {
        UIManager.Instance.panelHome.Hide();
        UIManager.Instance.panelInGame.SetActive(true);
        MapController.Instance.LoadMap();
        CameraController.Instance.changDirection();
    }
    private void OnbuttonMenu() {
        UIManager.Instance.panelHome.Hide();
        UIManager.Instance.panelLevelMenu.Show();

    }
    private void OnButtonSetting() {
        UIManager.Instance.panelHome.Hide();
        UIManager.Instance.popUpSetting.SetActive(true);
    }
}
