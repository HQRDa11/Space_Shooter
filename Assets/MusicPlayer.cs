using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private Application_StateMachine m_stateMachine;
    private AudioClip m_mainTheme;
    private AudioSource m_audioSource;
    // Start is called before the first frame update
    void Start()
    {
        m_stateMachine = Application_StateMachine.Instance;
        m_mainTheme = Resources.Load<AudioClip>("AudioClips/MainTheme");
        m_audioSource = GetComponent<AudioSource>();
        m_audioSource.clip = m_mainTheme;
       // m_audioSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        switch (!m_audioSource.isPlaying)
        {
            case true:
                switch (m_stateMachine.Get_CurrentStateType())
                {
                    case ApplicationState_Type.MAINMENU:
                        PlayMainTheme_ScheduledByState();
                        return;
                    case ApplicationState_Type.GAME:
                        m_audioSource.GetCustomCurve(AudioSourceCurveType.CustomRolloff);
                        PlayMainTheme_ScheduledByState();
                        return;
                    case ApplicationState_Type.PREPARE:
                        m_audioSource.GetCustomCurve(AudioSourceCurveType.CustomRolloff);
                        PlayMainTheme_ScheduledByState();
                        return;
                    case ApplicationState_Type.ENDGAME:
                        PlayMainTheme_ScheduledByState();
                        return;
                    case ApplicationState_Type.CREDITS:
                        PlayMainTheme_ScheduledByState();
                        return;
                    default:
                        return;
                }
        }

    }

    public void PlayMainTheme_ScheduledByState()
    {
        m_audioSource.time = m_stateMachine.Get_CurrentState().GetMainThemeSchedule();
        m_audioSource.Play();
    }

    public void Stop()
    {
        m_audioSource.Stop();
    }
}
