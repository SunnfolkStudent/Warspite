using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public SceneAsset nextScene;
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        print("Collision");
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(nextScene.name);
            print("Scene Loaded");
        }
    }
}
