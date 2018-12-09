using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RoomController : MonoBehaviour
{
    public const string Scene_Empty = "0_Empty";
    public const string Scene_1_ClassRoom = "1_ClassRoom";

    void Start()
    {
        Reset();
        SetGazedAt(false);
    }

    public void SetGazedAt(bool gazedAt)
    {
    }

    public void Reset()
    {

    }

    public void ClickDoorToEmpty(BaseEventData eventData)
    {
        SceneManager.LoadScene(Scene_Empty);
    }

    public void ClickDoorToRoom1_ClassRoom(BaseEventData eventData)
    {
        SceneManager.LoadScene(Scene_1_ClassRoom);
    }

    private bool checkClickAllowed(BaseEventData eventData)
    {
        // Only trigger on left input button, which maps to
        // Daydream controller TouchPadButton and Trigger buttons.
        PointerEventData ped = eventData as PointerEventData;
        if (ped != null)
        {
            if (ped.button != PointerEventData.InputButton.Left)
            {
                return false;
            }
        }
        return true;
    }
}
