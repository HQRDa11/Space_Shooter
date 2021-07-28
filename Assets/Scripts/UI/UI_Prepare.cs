using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Prepare : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ButtonsPanel newPanel = new ButtonsPanel(this.gameObject, "PREPARE NEXT FLIGHT", 64, new string[] { " LAUNCH ASSAULT ", " UPGRADE SQUADRON "," BACK " }, new Color32(32, 32, 32, 255), Color.white);
        newPanel.Buttons[0].onClick.AddListener(() => Application_StateMachine.Instance.stateRequest(ApplicationState_Type.GAME));
        newPanel.Buttons[0].onClick.AddListener(() => Sound.Instance.Play_ButtonSound());
        newPanel.Buttons[1].onClick.AddListener(() => Application_StateMachine.Instance.stateRequest(ApplicationState_Type.UPGRADE));
        newPanel.Buttons[1].onClick.AddListener(() => Sound.Instance.Play_ButtonSound());
        newPanel.Buttons[2].onClick.AddListener(() => Application_StateMachine.Instance.stateRequest(ApplicationState_Type.MAINMENU));
        newPanel.Buttons[2].onClick.AddListener(() => Sound.Instance.Play_ButtonSound());
    }
}
