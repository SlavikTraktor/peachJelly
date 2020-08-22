using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigDialog : MonoBehaviour
{
    private const float ADD_LETTER_TIME = 0.03f;
    private const string TEXT = "Съешь этих мягких французских булочек да выпей чаю.";

    private Text m_DialogText;

    private float timeCounter = 0;
    private int letterCounter = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        // Don't like next line. Unsafety =(
        m_DialogText = GameObject.Find("DialogText").GetComponent<Text>();
        m_DialogText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        WriteLetter();
    }

    public void WriteText(string newText) {

    }

    private void WriteLetter() {
        timeCounter += Time.deltaTime;
        if(letterCounter < TEXT.Length && timeCounter >= ADD_LETTER_TIME) {
            m_DialogText.text = m_DialogText.text + TEXT[letterCounter];
            letterCounter++;
            timeCounter = 0;
        }
    }
}
