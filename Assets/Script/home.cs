using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlowManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject panelStart;
    public GameObject panelRules;
    public GameObject panelMission;
    public GameObject panelAbout;
    public GameObject panelSlime;
    public GameObject panelApeHulk;
    public GameObject panelDragon;

    public void OnStartClicked()
    {
        HideAllPanels();
        panelRules.SetActive(true);
    }

    public void OnRulesNextClicked()
    {
        HideAllPanels();
        panelMission.SetActive(true);
    }

    public void OnAboutClicked()
    {
        HideAllPanels();
        panelAbout.SetActive(true);
    }

    public void OnBackFromAbout()
    {
        HideAllPanels();
        panelStart.SetActive(true);
    }

    public void OnBackFromRules()
    {
        HideAllPanels();
        panelStart.SetActive(true);
    }

    public void OnBackFromMission()
    {
        HideAllPanels();
        panelRules.SetActive(true);
    }

    public void ShowSlimePanel()
    {
        HideAllPanels();
        panelSlime.SetActive(true);
    }

    public void ShowApeHulkPanel()
    {
        HideAllPanels();
        panelApeHulk.SetActive(true);
    }

    public void ShowDragonPanel()
    {
        HideAllPanels();
        panelDragon.SetActive(true);
    }

    public void OnBackFromSlime()
    {
        HideAllPanels();
        panelMission.SetActive(true);
    }

    public void OnBackFromApeHulk()
    {
        HideAllPanels();
        panelMission.SetActive(true);
    }

    public void OnBackFromDragon()
    {
        HideAllPanels();
        panelMission.SetActive(true);
    }

    public void StartSlimeBattle()
    {
        SceneManager.LoadScene("Slime");
    }

    public void StartApeHulkBattle()
    {
        SceneManager.LoadScene("Ape");
    }

    public void StartDragonBattle()
    {
        SceneManager.LoadScene("Dragon");
    }

    public void OnExitClicked()
    {
        Application.Quit();
    }

    private void HideAllPanels()
    {
        panelStart.SetActive(false);
        panelRules.SetActive(false);
        panelMission.SetActive(false);
        panelAbout.SetActive(false);
        panelSlime.SetActive(false);
        panelApeHulk.SetActive(false);
        panelDragon.SetActive(false);
    }
}
