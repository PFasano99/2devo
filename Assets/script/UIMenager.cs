using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenager : MonoBehaviour
{
    public Text coins;
    public Text MaxSpaceDisplay;

    //resources
    public Text woodDisplay;
    public Text woodPlankDisplay;
    public Text ironDisplay;
    public Text ironOreDisplay;
    public Text nuclearDisplay;
    public Text stoneDisplay;
    public Text foodDisplay;
    public Text copperDisplay;
    public Text copperOreDisplay;
    public Text fiberDisplay;
    public Text coalDisplay;

    public Button oresB;
    public Button woodB;
    public Button barsB;
    public Button foodB;

    public Image oresP;
    public Image woodP;
    public Image barsP;
    public Image foodP;

    public Button metalB;
    public Image metalP;
    public Text ironGearBT, copperGearBT, ironPlateBT, copperPlateBT, ironWireBT, copperWireBT;

    //building
    public builderMenager builderMenager;
    public Image buildingTypeP;
    public Image buildingP;
    public Image convayorP;
    public Image otherP;

    public Button buildingTypeB;
    public Button buildingB;
    public Button convayorB;
    public Button otherB;

    public Button noFilterB;
    public Text noFilterT;

    public GameObject noFilter;

    public Text depositT, shopT, sawmillT, architectT, blacksmithT, meccanicT, powerT;
    public Button depositB, shopB, sawmillB, architectB, blacksmithB, meccanicB, powerB;
    public GameObject deposit, shop, sawmill, architect, blacksmith, meccanic, power;

    // Start is called before the first frame update
    void Start()
    {
        //Carica da file le quantità
        //resources
        oresP.gameObject.SetActive(false);
        woodP.gameObject.SetActive(false);
        barsP.gameObject.SetActive(false);
        foodP.gameObject.SetActive(false);
        metalP.gameObject.SetActive(false);

        oresB.GetComponent<Button>();
        woodB.GetComponent<Button>();
        barsB.GetComponent<Button>();
        foodB.GetComponent<Button>();
        metalB.GetComponent<Button>();

        oresB.onClick.AddListener(delegate { setPanelVisibility(oresP); });
        woodB.onClick.AddListener(delegate { setPanelVisibility(woodP); });
        barsB.onClick.AddListener(delegate { setPanelVisibility(barsP); });
        foodB.onClick.AddListener(delegate { setPanelVisibility(foodP); });
        metalB.onClick.AddListener(delegate { setPanelVisibility(metalP); });

        //building
        buildingTypeP.gameObject.SetActive(false);
        buildingP.gameObject.SetActive(false);
        convayorP.gameObject.SetActive(false);
        otherP.gameObject.SetActive(false);

        buildingTypeB.GetComponent<Button>();
        buildingB.GetComponent<Button>();
        convayorB.GetComponent<Button>();
        otherB.GetComponent<Button>();

        buildingTypeB.onClick.AddListener(delegate { setPanelVisibility(buildingTypeP); });
        buildingB.onClick.AddListener(delegate { setPanelVisibility(buildingP); });
        convayorB.onClick.AddListener(delegate { setPanelVisibility(convayorP); });
        otherB.onClick.AddListener(delegate { setPanelVisibility(otherP); });

        noFilterB.GetComponent<Button>();
        noFilterB.onClick.AddListener(delegate { FindObjectOfType<builderMenager>().createBuilding(noFilter, "noFilter"); }) ;


        shopB.GetComponent<Button>();
        shopB.onClick.AddListener(delegate { FindObjectOfType<builderMenager>().createBuilding(shop, "shop"); });

        depositB.GetComponent<Button>();
        depositB.onClick.AddListener(delegate { FindObjectOfType<builderMenager>().createBuilding(deposit, "deposit"); });

        sawmillB.GetComponent<Button>();
        sawmillB.onClick.AddListener(delegate { FindObjectOfType<builderMenager>().createBuilding(sawmill, "sawmill"); });

        architectB.GetComponent<Button>();
        architectB.onClick.AddListener(delegate { FindObjectOfType<builderMenager>().createBuilding(architect, "architect"); });

        blacksmithB.GetComponent<Button>();
        blacksmithB.onClick.AddListener(delegate { FindObjectOfType<builderMenager>().createBuilding(blacksmith, "blacksmith"); });

        meccanicB.GetComponent<Button>();
        meccanicB.onClick.AddListener(delegate { FindObjectOfType<builderMenager>().createBuilding(meccanic, "meccanic"); });

        powerB.GetComponent<Button>();
        powerB.onClick.AddListener(delegate { FindObjectOfType<builderMenager>().createBuilding(power, "power"); });
    }

    // Update is called once per frame
    void Update()
    {
        coins.text = "" + FindObjectOfType<resourceQuantity>().getCoins();
        MaxSpaceDisplay.text = FindObjectOfType<resourceQuantity>().getCurrentQuantity() +"/" + FindObjectOfType<resourceQuantity>().getMaxSpace();

        woodDisplay.text = "" + FindObjectOfType<resourceQuantity>().getWood();
        woodPlankDisplay.text="" + FindObjectOfType<resourceQuantity>().getWoodPlank();
        ironDisplay.text = "" + FindObjectOfType<resourceQuantity>().getIron();
        ironOreDisplay.text = "" + FindObjectOfType<resourceQuantity>().getIronOre();
        nuclearDisplay.text = "" + FindObjectOfType<resourceQuantity>().getNuclear();
        stoneDisplay.text = "" + FindObjectOfType<resourceQuantity>().getStone();
        foodDisplay.text = "" + FindObjectOfType<resourceQuantity>().getFood();
        copperDisplay.text = "" + FindObjectOfType<resourceQuantity>().getCopper();
        copperOreDisplay.text = "" + FindObjectOfType<resourceQuantity>().getCopperOre();
        fiberDisplay.text = "" + FindObjectOfType<resourceQuantity>().getFiber();
        coalDisplay.text = "" + FindObjectOfType<resourceQuantity>().getCoal();

        ironGearBT.text = "" + FindObjectOfType<resourceQuantity>().getIronGear();
        ironPlateBT.text = "" + FindObjectOfType<resourceQuantity>().getIronPlate();
        ironWireBT.text = "" + FindObjectOfType<resourceQuantity>().getIronWire();

        copperGearBT.text = "" + FindObjectOfType<resourceQuantity>().getCopperGear();
        copperPlateBT.text = "" + FindObjectOfType<resourceQuantity>().getCopperPlate();
        copperWireBT.text = "" + FindObjectOfType<resourceQuantity>().getCopperWire();

        noFilterT.text = FindObjectOfType<resourceQuantity>().getNoFilter().ToString();

        depositT.text = FindObjectOfType<resourceQuantity>().getDeposit().ToString();
        shopT.text = FindObjectOfType<resourceQuantity>().getShop().ToString();
        sawmillT.text = FindObjectOfType<resourceQuantity>().getSawmill().ToString();
        blacksmithT.text = FindObjectOfType<resourceQuantity>().getBlacksmith().ToString();
        meccanicT.text = FindObjectOfType<resourceQuantity>().getMeccanic().ToString();
        architectT.text = FindObjectOfType<resourceQuantity>().getArchitect().ToString();
        powerT.text = FindObjectOfType<resourceQuantity>().getPower().ToString();
    }

    public void setPanelVisibility(Image panel)
    {
        panel.gameObject.SetActive(!panel.gameObject.activeSelf);
    }

    

}
