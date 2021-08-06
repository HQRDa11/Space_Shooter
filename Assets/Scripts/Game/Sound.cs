using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    private static Sound _instance;
    public static Sound Instance { get => _instance; }

    private AudioSource m_audioSource;
    private AudioClip m_weaponDeployShort;
    private AudioClip m_droidShort;
    private AudioClip m_componentCollect;
    private AudioClip m_startSound;
    private AudioClip m_buttonSound;
    private AudioClip m_moduleLevelUp;
    private AudioClip m_shipLevelUp;

    // Start is called before the first frame update
    void Awake()
    {
        _instance = this;
        m_audioSource = GetComponent<AudioSource>();
        m_weaponDeployShort = Resources.Load<AudioClip>("AudioClips/WeaponDeployShort");
        m_droidShort        = Resources.Load<AudioClip>("AudioClips/DroidShort");
        m_componentCollect  = Resources.Load<AudioClip>("AudioClips/ComponentCollect");
        m_startSound        = Resources.Load<AudioClip>("AudioClips/StartSound");
        m_buttonSound       = Resources.Load<AudioClip>("AudioClips/ButtonSound");
        m_moduleLevelUp     = Resources.Load<AudioClip>("AudioClips/Selection");
        m_shipLevelUp       = Resources.Load<AudioClip>("AudioClips/WeaponDeploy");
    }


    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.S))
        {
            Play_Droid();
        }
    }
    public void Play_StartSound()
    {

        m_audioSource.PlayOneShot(m_startSound, 0.8f);
    }

    public void Play_WeaponDeployShort()
    {
        m_audioSource.PlayOneShot(m_weaponDeployShort,0.2f);
    }
    public void Play_Droid()
    {
        m_audioSource.PlayOneShot(m_droidShort, 0.7f);
    }
    public void Play_ComponentCollect()
    {
        m_audioSource.PlayOneShot(m_componentCollect, 0.9f);
    }
    public void Play_ButtonSound()
    {
        m_audioSource.PlayOneShot(m_buttonSound, 0.7f);
    }    
    public void Play_ModuleLevelUp()
    {
       m_audioSource.PlayOneShot(m_moduleLevelUp, 0.7f);
    }
    public void Play_ShipLevelUp()
    {
       m_audioSource.PlayOneShot(m_shipLevelUp, 0.7f);
    }
}
