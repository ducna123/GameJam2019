using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : SingletonBind<CameraController>
{
    [SerializeField] private Transform _posInagme; 
    [SerializeField] private Transform  _posStart;

    public void Start() {
        setStartPos();
    }
    public void changDirection() {
        float timeDelay = 1.2f;
        transform.DOMove(_posInagme.position, timeDelay);
        transform.DORotateQuaternion(_posInagme.rotation, timeDelay);
    }

    public void setStartPos() {
        transform.position = _posStart.position;
        transform.rotation = _posStart.rotation;
    }
}
