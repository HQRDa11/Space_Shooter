using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    private static Sound _instance;
    public static Sound Instance { get => _instance; }

    private AudioSource m_audioSource;
    private AudioClip m_weaponDeploy;

    // Start is called before the first frame update
    void Awake()
    {
        m_audioSource = GetComponent<AudioSource>();
        m_weaponDeploy = Resources.Load<AudioClip>("AudioClips/WeaponDeploy");
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.S))
        {
            Play_WeaponDeploy();
        }
    }

    public void Play_WeaponDeploy()
    {
        m_audioSource.PlayOneShot(m_weaponDeploy);
    }
}
