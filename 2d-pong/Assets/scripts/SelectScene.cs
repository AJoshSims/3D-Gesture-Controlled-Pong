using UnityEngine;
using UnityEngine.SceneManagement;

using System.Collections;

public class SelectScene : MonoBehaviour
{
	public void LoadScene(int indexOfScene)
    {
        SceneManager.LoadScene(indexOfScene, LoadSceneMode.Single);
    }
}
