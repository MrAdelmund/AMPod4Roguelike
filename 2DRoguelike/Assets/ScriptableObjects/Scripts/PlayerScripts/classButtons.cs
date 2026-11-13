using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class classButtons : MonoBehaviour
{

    public static PlayerClassSO SelectedClass;
    public void SelectClass(PlayerClassSO chosenClass)
    {
        SelectedClass = chosenClass;
        Debug.Log("selected Class" + chosenClass.className);

    }
  
   
}
