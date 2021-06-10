using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    private Text _text;
    private RectTransform _rectTransform;

    [SerializeField]
    private float _offSet;
    [SerializeField]
    private int _opacity;

    private bool _isStarted;
    private float _clock;
    void Start()
    {
        _text = GetComponent<Text>();
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if(_isStarted) ShowScore();
    }

    void FixedUpdate()
    {
        if (!_isStarted) Initialize();
    }

    private void Initialize()
    {
        _clock += Time.deltaTime;

        if (_clock >= 1 && _clock < 2)
        {
            _rectTransform.anchoredPosition += new Vector2(0, _offSet * Time.deltaTime);
        }
        else if (_clock >= 2 && _clock < 2.5f)
        {
            _text.text = "0";
            _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, 0);
            _text.color += new Color(0, 0, 0, _opacity * Time.deltaTime);
            _rectTransform.anchoredPosition = Vector2.zero;
        }
        else if (_clock >= 2.5f)
        {
            _isStarted = true;
        }
    }

    private void ShowScore()
    {
        _text.text = ScoreSystem.Instance.CurrentScore.ToString();
    }
}
