using System;
using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{
    public TMP_Text text;

    private void Start()
    {
        text.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        text.gameObject.SetActive(true);
    }
    
    void OnTriggerExit2D(Collider2D coll)
    {
        text.gameObject.SetActive(false);
    }
}
