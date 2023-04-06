using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handle the dungeon door to load the dungeon or village scene
/// </summary>
public class DungeonDoorHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Method that it called when the player select the dungeon door
    /// That method called the LoadAsyncScene method
    /// </summary>
    public void ChangeScene()
    {
        StartCoroutine(LoadAsyncScene());
    }

    /// <summary>
    /// Load asynchronous the other scene of the project
    /// </summary>
    /// <returns></returns>
    IEnumerator LoadAsyncScene()
    {
        int indexScene = 0;

        if (SceneManager.GetActiveScene().buildIndex == 0)
            indexScene = 1;

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(indexScene);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
