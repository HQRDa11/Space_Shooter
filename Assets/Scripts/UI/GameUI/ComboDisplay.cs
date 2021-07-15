using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboDisplay : MonoBehaviour
{
    private static ComboDisplay _instance; public static ComboDisplay Instance { get => _instance; }
    private Text _text;
    private RectTransform _rectTransform;

    [SerializeField]
    private float _offSet;
    [SerializeField]
    private int _opacity;

    private bool _isStarted;
    private float _clock;
    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        _text = GetComponent<Text>();
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (_isStarted) ShowCombo();
    }

    void FixedUpdate()
    {
        switch (!_isStarted)
        {
            case true:
                Initialize();
                PulseEffectRevert();
                return;
        }
    }

    private void Initialize()
    {
        _clock += Time.deltaTime;

        if (_clock >= 1 && _clock < 1.6f)
        {
            _rectTransform.anchoredPosition += new Vector2(0, _offSet * Time.deltaTime * 2);
        }
        else if (_clock >= 1.6f && _clock < 4f)
        {
            _text.text = "0";
            _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, 0);
            _text.color += new Color(0, 0, 0, _opacity * Time.deltaTime);
            _rectTransform.anchoredPosition = Vector2.zero + Vector2.down * 3; ;
        }
        else if (_clock >= 3f)
        {
            _isStarted = true;
        }
    }


    private void ShowCombo()
    {
        _text.text = "x" + ComboSystem.Instance.CurrentCombo.ToString();
    }

    public void PulseEffect() { if(_text.fontSize < 110) _text.fontSize += 20; }
    private void PulseEffectRevert() { if (_text.fontSize != 50) _text.fontSize -= 1; }
}
