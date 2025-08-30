using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    [SerializeField] Image blackScreen;
    [SerializeField] private float fadeInDuration;
    [SerializeField] private float fadeOutDuration;
    private string currentSceneName;
    [SerializeField] private float levelDuration;

    void Start()
    {
        blackScreen.DOFade(0, fadeInDuration);
        currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "Level1")
        {
            blackScreen.DOFade(1, fadeOutDuration).SetDelay(levelDuration).OnComplete(() => SceneManager.LoadScene("Level2"));
        }
        if (currentSceneName == "Level2")
        {
            blackScreen.DOFade(1, fadeOutDuration).SetDelay(levelDuration).OnComplete(() => SceneManager.LoadScene("Level3"));
        }
    }

    public void ButtonDestroy()
    {
        Debug.Log("button clicked!");
        Destroy(gameObject);
        blackScreen.DOFade(1, fadeOutDuration).OnComplete(() => SceneManager.LoadScene("Level1"));
    }



}
