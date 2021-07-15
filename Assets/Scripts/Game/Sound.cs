using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    private static Sound _instance;
    public static Sound Instance { get => _instance; }

    private AudioSource m_audioSource;
    private AudioClip m_weaponDeploy;
    private AudioClip m_droidShort;

    // Start is called before the first frame update
    void Awake()
    {
        _instance = this;
        m_audioSource = GetComponent<AudioSource>();
        m_weaponDeploy = Resources.Load<AudioClip>("AudioClips/WeaponDeploy");
        m_droidShort = Resources.Load<AudioClip>("AudioClips/DroidShort");
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.S))
        {
            Play_Droid();
        }
    }

    public void Play_WeaponDeploy()
    {
        m_audioSource.PlayOneShot(m_weaponDeploy,0.3f);
    }
    public void Play_Droid()
    {
        m_audioSource.PlayOneShot(m_droidShort, 1);
    }
}
