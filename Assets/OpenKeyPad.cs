using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenKeyPad : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject notebook;
    public GameObject keyPadText;
    public Button btn;

    void Start()
    {
        keyPadText.SetActive(false);
        btn.onClick.AddListener(showKey);
    }

    // Update is called once per frame
    void showKey()
    {
        keyPadText.SetActive(true);
        notebook.SetActive(false);
    }
}
