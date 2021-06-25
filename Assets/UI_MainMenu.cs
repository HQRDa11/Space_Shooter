using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ButtonsPanel newPanel = new ButtonsPanel(this.gameObject, "MAIN MENU", 32, new string[] { "Play", "Options", "Credits", "Quit" }, new Color32(32, 32, 32, 255), Color.white);
        newPanel.Buttons[0].onClick.AddListener(() => Application_StateMachine.Instance.stateRequest(ApplicationState_Type.GAME));
        newPanel.Buttons[1].onClick.AddListener(() => Application_StateMachine.Instance.stateRequest(ApplicationState_Type.OPTIONS));
        newPanel.Buttons[2].onClick.AddListener(() => Application_StateMachine.Instance.stateRequest(ApplicationState_Type.CREDITS));
        newPanel.Buttons[3].onClick.AddListener(() => Application_StateMachine.Instance.stateRequest(ApplicationState_Type.QUIT));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
