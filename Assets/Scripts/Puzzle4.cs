using UnityEngine;
using UnityEngine.InputSystem;

public class Puzzle4 : MonoBehaviour
{
    myControls inputActions;
    private PuzzleManager puzzleManager;

    public UnityEngine.Events.UnityEvent myAction;
    private Renderer sphereRenderer;

    public Material greenMaterial;
    public Material blueMaterial;
    public Material blackMaterial;

    private void Awake()
    {
        inputActions = new myControls();
        inputActions.Player.ActionKey.performed += OnActionKeyPressed;
    }

    private void OnActionKeyPressed(InputAction.CallbackContext context)
    {
        if (sphereRenderer == null)
            return;

        // Check which key was pressed using the keyboard
        if (Keyboard.current.digit1Key.isPressed)
        {
            sphereRenderer.material = greenMaterial;
        }
        else if (Keyboard.current.digit2Key.isPressed)
        {
            sphereRenderer.material = blueMaterial;
        }
        else if (Keyboard.current.digit3Key.isPressed)
        {
            sphereRenderer.material = blackMaterial;
            // Only call Puzzle4 and MyAction when key 3 is pressed
            if (puzzleManager != null)
                puzzleManager.Puzzle4();
            MyAction();
        }
    }

    private void Start()
    {
        sphereRenderer = GetComponent<Renderer>();
        puzzleManager = FindObjectOfType<PuzzleManager>();
    }

    public void OnEnable()
    {
        if (inputActions != null)
            inputActions.Enable();
    }

    public void OnDisable()
    {
        if (inputActions != null)
            inputActions.Disable();
    }
    private void OnDestroy()
    {
        if (inputActions != null)
        {
            inputActions.Player.ActionKey.performed -= OnActionKeyPressed;
            inputActions.Dispose();
        }
    }
    public void MyAction()
    {
        myAction?.Invoke();
    }
}

