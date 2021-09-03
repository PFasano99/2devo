using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resourceQuantity : MonoBehaviour
{
    private int coin = 0;
    private int wood = 0;
    private int stone = 0;
    private int ironOre = 0;
    private int food = 0;
    private int iron = 0;
    private int nuclear = 0;
    private int coal = 0;
    private int copper = 0;
    private int copperOre = 0;
    private int fiber = 0;
    private int woodPlank = 0;
    private int copperGear = 0;
    private int copperWire = 0;
    private int copperPlate = 0;
    private int ironGear = 0;
    private int ironWire = 0;
    private int ironPlate = 0;

    //belt
    private int noFilter = 0;

    //buildings
    private int deposit, shop, architect, sawmill, blacksmith, meccanic, power;

    private int maxSpace = 0;
    private int currentQuantity = 0;

    public void setCoin(int value)
    {
        coin = value;
    }
    public int getCoins()
    {
        return coin;
    }

    public void setCoal(int value)
    {
        coal = value;
    }
    public int getCoal()
    {
        return coal;
    }

    public void setWood(int value)
    {
        wood = value;
    }
    public int getWood()
    {
        return wood;
    }

    public void setWoodPlank(int value)
    {
        woodPlank = value;
    }
    public int getWoodPlank()
    {
        return woodPlank;
    }
    public void setStone(int value)
    {
        stone = value;
    }
    public int getStone()
    {
        return stone;
    }

    public void setIron(int value)
    {
        iron = value;
    }
    public int getIron()
    {
        return iron;
    }

    public void setCopper(int value)
    {
        copper = value;
    }
    public int getCopper()
    {
        return copper;
    }

    public void setFiber(int value)
    {
        fiber = value;
    }
    public int getFiber()
    {
        return fiber;
    }
    public void setCopperOre(int value)
    {
        copperOre = value;
    }
    public int getCopperOre()
    {
        return copperOre;
    }

    public void setFood(int value)
    {
        food = value;
    }
    public int getFood()
    {
        return food;
    }

    public void setMaxSpace(int value)
    {
        maxSpace = value;
    }

    public int getMaxSpace()
    {
        return maxSpace;
    }

    public void setIronOre(int value)
    {
        ironOre = value;
    }
    public int getIronOre()
    {
        return ironOre;
    }

    public void setNuclear(int value)
    {
        nuclear = value;
    }
    public int getNuclear()
    {
        return nuclear;
    }

    public void setCurrentQuantity(int value)
    {
        currentQuantity = value; 
    }

    public int getCurrentQuantity()
    {
        return currentQuantity;
    }

    public int getCopperGear()
    {
        return this.copperGear;
    }

    public void setCopperGear(int copperGear)
    {
        this.copperGear = copperGear;
    }

    public int getCopperWire()
    {
        return this.copperWire;
    }

    public void setCopperWire(int copperWire)
    {
        this.copperWire = copperWire;
    }

    public int getCopperPlate()
    {
        return this.copperPlate;
    }

    public void setCopperPlate(int copperPlate)
    {
        this.copperPlate = copperPlate;
    }

    public int getIronGear()
    {
        return this.ironGear;
    }

    public void setIronGear(int ironGear)
    {
        this.ironGear = ironGear;
    }

    public int getIronWire()
    {
        return this.ironWire;
    }

    public void setIronWire(int ironWire)
    {
        this.ironWire = ironWire;
    }

    public int getIronPlate()
    {
        return this.ironPlate;
    }

    public void setIronPlate(int ironPlate)
    {
        this.ironPlate = ironPlate;
    }

    //belt
    public int getNoFilter()
    {
        return this.noFilter;
    }

    public void setNoFilter(int noFilter)
    {
        this.noFilter = noFilter;
    }

    //building
    public int getArchitect()
    {
        return this.architect;
    }

    public void setArchitect(int architect)
    {
        this.architect = architect;
    }

    public int getSawmill()
    {
        return this.sawmill;
    }

    public void setSawmill(int sawmill)
    {
        this.sawmill = sawmill;
    }

    public int getBlacksmith()
    {
        return this.blacksmith;
    }

    public void setBlacksmith(int blacksmith)
    {
        this.blacksmith = blacksmith;
    }

    public int getMeccanic()
    {
        return this.meccanic;
    }

    public void setMeccanic(int meccanic)
    {
        this.meccanic = meccanic;
    }

    public int getPower()
    {
        return this.power;
    }

    public void setPower(int power)
    {
        this.power = power;
    }


    public int getDeposit() {
		return this.deposit;
	}

    public void setDeposit(int deposit) {

        this.deposit = deposit;

    }

    public int getShop()
    {
        return this.shop;
    }

    public void setShop(int shop)
    {
        this.shop = shop;
    }
}
