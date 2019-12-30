using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeveInfo : MonoBehaviour
{
    private int level;
    private bool isLock;
    [SerializeField] private ButtonBase button;
    [SerializeField] private Image img;
    [SerializeField] private Sprite spOpen, spLock;

    private void Start() {
        button.onClick.AddListener(OnButtonLevel);
    }

    public void Init(int level , bool isLock) {
        this.level = level;
        this.GetComponentInChildren<Text>().text = (level+1).ToString();
        this.isLock = isLock;
        if (!isLock)
        {
            button.interactable = false;
            this.GetComponentInChildren<Text>().gameObject.SetActive(false);
            img.sprite = spLock;
        }
        else img.sprite = spOpen;
    }

    private void OnButtonLevel() {
        MapController.Instance.LoadMap();
        UIManager.Instance.panelLevelMenu.Hide();
    }

}
