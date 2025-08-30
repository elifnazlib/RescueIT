using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject player;
    [SerializeField] GameObject princess;
    [SerializeField] GameObject bgImage;
    [SerializeField] GameObject blackScreen;

    void Start()
    {
        StartCoroutine(StartPlayingAnimations());
    }

    IEnumerator StartPlayingAnimations()
    {
        StartCoroutine(MoveToTarget(player, player.transform.position, new Vector2(-6.5f, player.transform.position.y), 3f));
        yield return new WaitForSeconds(3f);
        animator.SetBool("isFirstFinished", true);
        yield return new WaitForSeconds(2f);
        animator.SetBool("isSecondFinished", true);
        yield return new WaitForSeconds(3f);
        animator.SetBool("isThirdFinished", true);
        yield return new WaitForSeconds(3f);

        StartCoroutine(MoveToTarget(princess, princess.transform.position, new Vector2(-3f, princess.transform.position.y), 5f));
        yield return new WaitForSeconds(8f);

        Destroy(player);
        Destroy(princess);

        bgImage.SetActive(false);
        yield return new WaitForSeconds(1f);
        blackScreen.SetActive(true);
    }

    IEnumerator MoveToTarget(GameObject obj, Vector2 startPos, Vector2 endPos, float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            obj.transform.position = Vector2.Lerp(startPos, endPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        obj.transform.position = endPos;
    }
}
