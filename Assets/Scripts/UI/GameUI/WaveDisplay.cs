using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveDisplay : MonoBehaviour
{
    private static WaveDisplay _instance; public static WaveDisplay Instance { get => _instance; }
    private Text _text;

    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        _text = GetComponent<Text>();
    }

    private void Update()
    {
        ShowWaveIndex();
    }

    void FixedUpdate()
    {
        PulseEffectRevert();
    }
    private void ShowWaveIndex()
    {
        _text.text = WaveSystem.Instance.CurrentWaveIndex.ToString();
    }

    public void PulseEffect() { if (_text.fontSize < 110) _text.fontSize += 50; }
    private void PulseEffectRevert() { if (_text.fontSize != 70) _text.fontSize -= 1; }
}
