using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject door;
    private PuzzleManager puzzleManager;

    private void Start()
    {
        puzzleManager = FindObjectOfType<PuzzleManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (puzzleManager != null)
                puzzleManager.PressurePlate();
            door.SetActive(false); // door opens
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door.SetActive(true); // door closes
        }
    }

    public void HideDoor()
    {
        if (door != null)
            door.SetActive(false);
    }
}
