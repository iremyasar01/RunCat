using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
 
    public GameObject StartPanel, InGamePanel, EndPanel, WinPanel, FailPanel;
    public GameObject player;
 
    // Start is called before the first frame update
    void Awake()
    {
        player.GetComponent<CharacterMove>().RunSpeed = 0;
        player.GetComponent<CharacterMove>().AnimationControl("Idle");
        //burda jump'ı da engellemen gerekiyor.


    }
    public void PanelControl(GameObject PanelObject, GameObject SecondObject)
    {
        StartPanel.SetActive(false);
        InGamePanel.SetActive(false);
        EndPanel.SetActive(false);
        FailPanel.SetActive(false);
        WinPanel.SetActive(false);
        PanelObject.SetActive(true);
        if (SecondObject != null)
        {
            SecondObject.SetActive(true);
        }
    }
    private void Start()
    {

        PanelControl(StartPanel,null);

    }

    public void TapToStart()
    {
        PanelControl(InGamePanel, null);
        player.GetComponent<CharacterMove>().RunSpeed = 10;
        player.GetComponent<CharacterMove>().AnimationControl("Run");
    }
    public void Fail()
    {
        PanelControl(EndPanel, FailPanel);
    }
    public void Win()
    {
        PanelControl(EndPanel, WinPanel);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
