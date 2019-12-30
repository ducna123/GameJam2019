using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Line : MonoBehaviour
{
    public void Init(bool isWaste) {
       
        var tree = isWaste? ThemeController.Instance.GetRandomBigTree().Spawn(transform) : ThemeController.Instance.getRandomTree().Spawn(transform);
        tree.transform.position = transform.position + Vector3.up * 0.9f;
        tree.transform.localScale = Vector3.zero;
        tree.transform.DOScale(1, 0.2f);
    }

    public void OnDisable() {
        int num = transform.childCount;
        for (int i = 0; i < num; i++) {
            var tree = transform.GetChild(0);
            tree.DOKill();
            tree.transform.localScale = Vector3.one;
            tree.transform.DOScale(0, 0.2f).OnComplete(() => {
                tree.Recycle();
            });
            
        }
    }
}
