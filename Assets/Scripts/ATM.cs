using UnityEngine;
using System.Collections;

public class ATM : MonoBehaviour
{
    public GameObject atmScreen;
    private CanvasGroup canvasGroup;
    private Coroutine fadeCoroutine;
    myControls inputActions;

    public UnityEngine.Events.UnityEvent myAction;
    private void Awake()
    {
        inputActions = new myControls();
    }

    private void Start()
    {
        canvasGroup = atmScreen.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = atmScreen.AddComponent<CanvasGroup>();
        }
        canvasGroup.alpha = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Entered space");
            if (fadeCoroutine != null)
                StopCoroutine(fadeCoroutine);
            fadeCoroutine = StartCoroutine(FadeIn());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Left the space");
            if (fadeCoroutine != null)
                StopCoroutine(fadeCoroutine);
            fadeCoroutine = StartCoroutine(FadeOut());
        }
    }

    private IEnumerator FadeIn()
    {
        atmScreen.SetActive(true);
        float duration = 0.5f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(elapsed / duration);
            yield return null;
        }
        canvasGroup.alpha = 1f;
    }

    private IEnumerator FadeOut()
    {
        float duration = 0.5f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(1f - (elapsed / duration));
            yield return null;
        }
        canvasGroup.alpha = 0f;
        atmScreen.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (inputActions.Player.ActionKey.WasPressedThisFrame())
                myAction.Invoke();
        }
    }
    public void OnEnable()
    {
        inputActions.Player.Enable();
    }
    public void OnDisable()
    {
        inputActions.Player.Disable();
    }
}
