using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGamePanel : FrameBase
{
    [SerializeField] private ButtonBase btnReplay;
    [SerializeField] private ButtonBase btnBackSteps;
    [Header("wates panel")]
    [SerializeField] private List<Image> wates;
    [Header("Power panel")]
    [SerializeField] private List<Image> powers;

    private void Start() {
        btnReplay.onClick.AddListener(OnButtonReplay);
        btnBackSteps.onClick.AddListener(OnButtonBackSteps);
    }

    private void OnButtonReplay() {
        MapController.Instance.LoadMap();
        // button replay
    }

    private void OnButtonBackSteps() {
        MovePlayer.Instance.MoveBack();
        // button btnBackSteps
    }

    public void Init(int numWaste, int numPower) {
        SetNumberWaste(numWaste);
        UpdatePower(numPower);
    }

    public void SetNumberWaste(int numWaste) {
        for(int i =0; i < wates.Count; i++) {
            if (i < numWaste) wates[i].gameObject.SetActive(true);
            else wates[i].gameObject.SetActive(false);
        }
    }

    public void UpdateWasteClean(int numWaste = 1) {
        for(int i= wates.Count-1; i>=0; i--) {
            if (wates[i].IsActive()) {
                wates[i].gameObject.SetActive(false);
                numWaste--;
            }
            if (numWaste <= 0) return;
        }
    }
    public void UpdatePower(int curPower) {
        for(int i = 0; i< powers.Count; i++) {
            if (i < curPower) {
                powers[i].gameObject.SetActive(true);
            } else {
                powers[i].gameObject.SetActive(false);
            }
        }
    }
}
