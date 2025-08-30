using TMPro;
using UnityEngine;

public class CountdownController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _timeRemaining;
    public bool isGameStarted = false;
    void Awake()
    {
        _text.text = ((int)_timeRemaining).ToString();
    }

    void Update()
    {
        if (_timeRemaining < 0)
        {
            Destroy(_text);
            isGameStarted = true;
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
