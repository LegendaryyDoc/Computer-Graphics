using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDown : MonoBehaviour
{   
    public List<GameObject> allAnims;

    public Dropdown animOptions;

    // Start is called before the first frame update
    void Start()
    {
        animOptions.options.Clear();

        foreach (GameObject item in allAnims)
        {
            animOptions.options.Add(new Dropdown.OptionData(item.name)); // adding all items in the list into a dropdown
        }
    }
}