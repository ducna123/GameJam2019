using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ConfirmPopup : FrameBase
{
    [SerializeField] private TextMeshProUGUI txtContent;
    [SerializeField] private ButtonBase btnYes;
    [SerializeField] private ButtonBase btnNo;

    public void ShowPopup(string content, Action yesAc, Action noAct ) {
        Show();
        txtContent.text = content;
        btnYes.onClick.RemoveAllListeners();
        btnNo.onClick.RemoveAllListeners();
        btnYes.onClick.AddListener(()=>yesAc());
        btnNo.onClick.AddListener(()=>noAct());
        btnYes.onClick.AddListener(Hide);
        btnNo.onClick.AddListener(Hide);
    }
}
