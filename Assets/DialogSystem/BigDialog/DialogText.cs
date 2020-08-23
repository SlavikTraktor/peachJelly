using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogText : MonoBehaviour
{
    private BigDialog parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = gameObject.GetComponentInParent<BigDialog>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0)) {
            parent.onClickNext();
        }
    }
}
