using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI milkAmountText;

    void Start()
    {
        milkAmountText.text = Singleton.Instance.milkAmount.ToString() + "%";
    }

    public void ChangeMilkAmountOnScreen(float amount)
    {
        milkAmountText.text = amount.ToString() + "%";
    }
}
