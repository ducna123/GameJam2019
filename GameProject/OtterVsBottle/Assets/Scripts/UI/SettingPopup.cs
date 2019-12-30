using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPopup : FrameBase
{
    [SerializeField] private ButtonBase btnSound;
    [SerializeField] private ButtonBase btnExit;

    private void Start() {
        btnSound.onClick.AddListener(OnButtonSound);
        btnExit.onClick.AddListener(OnButtonHome);
    }

    private void OnButtonSound() {


    }
    private void OnButtonHome() {
        this.gameObject.SetActive(false);
        UIManager.Instance.panelHome.Show();
    }
}
