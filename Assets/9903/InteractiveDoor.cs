using UnityEngine;
using UnityEngine.Events;

public class InteractiveDoor : MonoBehaviour
{
    [System.Serializable]
    public class DoorStateEvent : UnityEvent<bool> { } 


    [SerializeField] private Transform doorChild; 
    [SerializeField] private float openAngle = 90f; 
    [SerializeField] private float smoothSpeed = 5f; 

    public DoorStateEvent onDoorStateChanged; 

    private bool isPlayerInTrigger = false;
    private bool isOpen = false; 
    
    private Quaternion closeRotation; 
    private Quaternion openRotation; 

    void Start()
    {

            closeRotation = doorChild.localRotation;
            openRotation = closeRotation * Quaternion.Euler(0, openAngle, 0);
        
    }

    void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            ToggleDoor();
        }

        if (doorChild != null)
        {
            Quaternion targetRotation = isOpen ? openRotation : closeRotation;
            doorChild.localRotation = Quaternion.Slerp(doorChild.localRotation, targetRotation, Time.deltaTime * smoothSpeed);
        }
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;

		Debug.Log("open door");
        if (onDoorStateChanged != null)
        {
            onDoorStateChanged.Invoke(isOpen);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
        }
    }
}