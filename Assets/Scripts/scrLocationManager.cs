using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrLocationManager : MonoBehaviour
{
    /*
     * Singleton method is used to transfer information about which levels are locked/unlocked between scenes.
     */
    public static scrLocationManager Instance;

    public List<int> unlockedLevels = new List<int>();

    //This is called as soon as scene is loaded
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        //This ensures the josh fight is unlocked when the map is first loaded
        unlockedLevels.Add(1);
    }
}
