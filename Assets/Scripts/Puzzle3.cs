using UnityEngine;

public class Puzzle3 : MonoBehaviour
{
    private PuzzleManager puzzleManager;
    myControls inputActions;
    private bool isCorrectAnswer = false;

    public UnityEngine.Events.UnityEvent myAction;
    private void Start()
    {
        puzzleManager = FindObjectOfType<PuzzleManager>();
    }

    private void Awake()
    {
        inputActions = new myControls();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (inputActions.Player.ActionKey.WasPressedThisFrame())
            {
                if (!isCorrectAnswer)
                {
                    puzzleManager.CompletePuzzle3();
                    isCorrectAnswer = true;
                }
                myAction.Invoke();
            }
        }
    }

    public void OnEnable()
    {
        inputActions.Enable();
    }

    public void OnDisable()
    {
        inputActions.Disable();
    }
}
