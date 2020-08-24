using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigDialog : MonoBehaviour
{
    private const float ADD_LETTER_TIME = 0.03f;
    private string textToWrite = "Съешь этих мягких французских булочек да выпей чаю.";

    private Text m_DialogText;
    private int letterCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        // Don't like next line. Unsafety =(
        m_DialogText = GameObject.Find("DialogText").GetComponent<Text>();
        m_DialogText.text = "";
        letterCounter = 0;

        InvokeRepeating("WriteLetter", 0.2f, ADD_LETTER_TIME);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void WriteText(string newText) {
        m_DialogText.text = "";
        textToWrite = newText;
        letterCounter = 0;
    }

    public void onClickNext() {
        Destroy(gameObject);
    }

    private void WriteLetter() {
        if(letterCounter < textToWrite.Length) {
            m_DialogText.text = m_DialogText.text + textToWrite[letterCounter];
            letterCounter++;
        }
    }
}
