using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIScalingMask : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] private List<Sprite> m_listSprites;
    [SerializeField] private bool m_isRandomSprites;

    [Header("Open Transition value")]
    [SerializeField] private float m_openDefaultValue;
    [SerializeField] private float m_openFirstValue;
    [SerializeField] private float m_openFirstDuration;
    [SerializeField] private float m_openSecondValue;
    [SerializeField] private float m_openSecondDuration;

    [Header("Close Transition value")]
    [SerializeField] private float m_closeDefaultValue;
    [SerializeField] private float m_closeFirstValue;
    [SerializeField] private float m_closeFirstDuration;
    [SerializeField] private float m_closeSecondValue;
    [SerializeField] private float m_closeSecondDuration;

    //comment this for build version
    [Header("Test Value")]
    [SerializeField] private bool m_isCloseTransition;

    private Vector2 m_startValueSizeDelta;
    private Vector2 m_endValueSizeDelta;

    private RectTransform m_maskRect;
    private Transform m_maskedChild;

    private void Awake()
    {
        m_maskRect = GetComponent<RectTransform>();
        m_maskedChild = transform.GetChild(0);
    }

    private void Start()
    {
        if (!m_isCloseTransition)
            ScaleIcon(m_isCloseTransition, m_openDefaultValue, m_openFirstValue, m_openFirstDuration, m_openSecondValue, m_openSecondDuration);
        else
            ScaleIcon(m_isCloseTransition, m_closeDefaultValue, m_closeFirstValue, m_closeFirstDuration, m_closeSecondValue, m_closeFirstDuration);
    }

    private void ScaleIcon(bool _isCloseTransition, float _defaultValue, float _firstValue, float _firstDuration, float _secondValue, float _secondDuration)
    {
        //get random Plastic stuffs
        if (m_listSprites.Count != 0)
            m_maskRect.GetComponent<Image>().sprite = m_isRandomSprites ? m_listSprites[Random.Range(0, m_listSprites.Count)] : m_listSprites[0];

        //set default value for width & height
        m_maskRect.sizeDelta = new Vector2(_defaultValue, _defaultValue);
        //m_maskRect.sizeDelta.Set(_defaultValue, _defaultValue);

        //m_startValueSizeDelta = new Vector2(_firstValue, _firstValue);
        m_startValueSizeDelta.Set(_firstValue, _firstValue);
        if (_secondValue != 0)
            m_endValueSizeDelta.Set(_secondValue, _secondValue);
        //m_endValueSizeDelta = new Vector2(_secondValue, _secondValue);

        Sequence seq = DOTween.Sequence();
        seq.Append(m_maskRect.DOSizeDelta(m_startValueSizeDelta, _firstDuration));
        if (_secondDuration != 0)
            seq.Append(m_maskRect.DOSizeDelta(m_endValueSizeDelta, _secondDuration));

        if (!_isCloseTransition)
            seq.Join(m_maskedChild.GetComponent<Image>().DOFade(0, (_firstDuration + _secondDuration) * 0.85f).SetEase(Ease.OutQuint));
    }

    #region Public Functions for calling Event
    public void OnOpenTransition()
    {
        ScaleIcon(false, m_openDefaultValue, m_openFirstValue, m_openFirstDuration, m_openSecondValue, m_openSecondDuration);
    }

    public void OnCloseTransition()
    {
        ScaleIcon(true, m_closeDefaultValue, m_closeFirstValue, m_closeFirstDuration, m_closeSecondValue, m_closeFirstDuration);
    }
    #endregion
}
