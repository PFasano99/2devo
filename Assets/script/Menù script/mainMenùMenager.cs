using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenùMenager : MonoBehaviour
{
    public Button newGameB, loadB, settingsB, exitB;
    public Button menu, saveB;
    public Image comingSoonP;

    public Coroutine coroutine;
    // Start is called before the first frame update
    void Start()
    {
        newGameB.GetComponent<Button>();
        newGameB.onClick.AddListener(delegate { newGame(); });

        menu.GetComponent<Button>();
        menu.onClick.AddListener(delegate { mainMenu(); });

        loadB.GetComponent<Button>();
        loadB.onClick.AddListener(delegate { load(); });

        saveB.GetComponent<Button>();
        saveB.onClick.AddListener(delegate { save(); });

        settingsB.GetComponent<Button>();
        settingsB.onClick.AddListener(delegate { settings(); });

        exitB.GetComponent<Button>();
        exitB.onClick.AddListener(delegate { exit(); });

        comingSoonP.GetComponent<Image>();
        comingSoonP.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }  

    public void newGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenù");
    }

    public void load()
    {
        toImplement();
    }

    public void save()
    {
        toImplement();
    }

    public void settings()
    {
        toImplement();
    }

    public void exit()
    {
        Application.Quit();
    }

    IEnumerator noSpaceTick()
    {
        while (true)
        {           
            yield return new WaitForSeconds(3);
            changePanel(comingSoonP);
            StopCoroutine(coroutine);
        }
        
    }

    public void toImplement()
    {
        changePanel(comingSoonP);
        coroutine = StartCoroutine(noSpaceTick());
    }

    public void changePanel(Image panel)
    {
        panel.gameObject.SetActive(!panel.gameObject.activeSelf);
    }
}
