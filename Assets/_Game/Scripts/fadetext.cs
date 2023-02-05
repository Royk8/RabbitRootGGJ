using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class fadetext : MonoBehaviour
{
    public Color color;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        color = GetComponent < TextMeshProUGUI > ().color;
    }

    // Update is called once per frame
    void Update()
    {
        
         float alpha = Mathf.Sin(Time.time*2)+.5f;
        color.a = alpha;
        text.color = color;
    }
}
