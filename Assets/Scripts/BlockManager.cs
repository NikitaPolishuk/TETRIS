using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockManager : MonoBehaviour
{

    public List<GameObject> blocks;

    
    
    
    public static BlockManager instance;


    public void ButtonButtonBkickI(string name)
    {
        GameObject go = blocks.Find(x => x.name == name);
        blocks.Remove(go);
       

    }




    void Start()
    {
        instance = this;
    }

    
    void Update()
    {
        
    }
}
