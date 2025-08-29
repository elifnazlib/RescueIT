using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _timeRemaining;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_timeRemaining < 0)
        {
            Destroy(_text);
            return;
        }

        _timeRemaining -= Time.deltaTime;
        UpdateText();
    }

    private void UpdateText()
    {
        _text.text = ((int)_timeRemaining).ToString();
     }
}
