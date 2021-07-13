using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    private AudioClip m_mainTheme;
    // Start is called before the first frame update
    void Start()
    {
        m_mainTheme = Resources.Load<AudioClip>("AudioClips/MainTheme");
        AudioSource source = GetComponent<AudioSource>();
        source.clip = m_mainTheme;
        source.Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
