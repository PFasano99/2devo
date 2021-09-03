using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldGenerationMenager : MonoBehaviour
{
    public GameObject tree1, tree2, tree3, stone, ironOre, copperOre, coal, forest1;
    public int maxTree1, maxTree2, maxTree3, maxStone, maxIronOre, maxCopperOre, maxCoal, maxForest1;
    public float xMin, xMax, yMin, yMax;  
    // Start is called before the first frame update
    void Awake()
    {
        spawnObject(tree1, maxTree1, xMin, xMax, yMin, yMax);
        spawnObject(tree2, maxTree2, xMin, xMax, yMin, yMax);
        spawnObject(tree3, maxTree3, xMin, xMax, yMin, yMax);
        spawnObject(stone, maxStone, xMin, xMax, yMin, yMax);
        spawnObject(ironOre, maxIronOre, xMin, xMax, yMin, yMax);
        spawnObject(copperOre, maxCopperOre, xMin, xMax, yMin, yMax);
        spawnObject(coal, maxCoal, xMin, xMax, yMin, yMax);
        spawnObject(forest1, maxForest1, xMin, xMax, yMin, yMax);
        Destroy(this);
    }

    public void spawnObject(GameObject toSpawn, int maxToSpawn, float XrangeMin, float XrangeMax, float YrangeMin, float YrangeMax)
    {
        for(int c = 0; c<maxToSpawn; c++)
        {
            float x = Random.Range(XrangeMin, XrangeMax);
            float y = Random.Range(YrangeMin, YrangeMax);
            float z = y * 0.1f;
   
            Vector3 positionToSpawn = new Vector3();
            positionToSpawn = new Vector3(x, y, z);
            Instantiate(toSpawn, positionToSpawn, Quaternion.identity);
        }
        
    }
}
