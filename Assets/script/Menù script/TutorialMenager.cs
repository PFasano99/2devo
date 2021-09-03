using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialMenager : MonoBehaviour
{
    public Button commands, infoBuilding, reciper;
    public Image commandsP, infoBuildingP, recipesP;
    // Start is called before the first frame update
    void Start()
    {

        resetPanel();

        commands.GetComponent<Button>();
        commands.onClick.AddListener(delegate { changeVisibility(commandsP); });

        infoBuilding.GetComponent<Button>();
        infoBuilding.onClick.AddListener(delegate { changeVisibility(infoBuildingP); });

        reciper.GetComponent<Button>();
        reciper.onClick.AddListener(delegate { changeVisibility(recipesP); });

        commandsP.GetComponent<Image>();
        commandsP.gameObject.SetActive(true);

        infoBuildingP.GetComponent<Image>();

        recipesP.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void changeVisibility(Image panel)
    {
        resetPanel();
        panel.gameObject.SetActive(!panel.gameObject.activeSelf);
    }

    public void resetPanel()
    {
        commandsP.gameObject.SetActive(false);
        infoBuildingP.gameObject.SetActive(false);
        recipesP.gameObject.SetActive(false);
    }

   
}
