using UnityEngine;

public class Cube : MonoBehaviour
{
    private PuzzleManager puzzleManager;

    myControls inputActions;

    public UnityEngine.Events.UnityEvent myAction;

    private void Start()
    {
        puzzleManager = FindObjectOfType<PuzzleManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            puzzleManager.Cube();
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (inputActions.Player.ActionKey.WasPressedThisFrame())
                myAction.Invoke();
        }
    }
}
