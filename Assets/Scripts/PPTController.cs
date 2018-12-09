using UnityEngine;
using UnityEngine.EventSystems;

public class PPTController : MonoBehaviour
{
    [SerializeField] private GameObject sphereScreenObject;
    [SerializeField] private MeshRenderer reticlePointerRenderer;
    private Material mainMaterial;

    private int ppt_order = -1;
    private Texture[] currentTextures;
    

    public Texture[] testChessboardTexture;
    public Texture[] I_Blackboard_Texture;

    void Start()
    {
        Renderer sphereRenderer = sphereScreenObject.GetComponent<Renderer>();
        mainMaterial = sphereRenderer.material;
        Reset();
        SetGazedAt(false);
    }

    public void SetGazedAt(bool gazedAt)
    {
        //if (inactiveMaterial != null && gazedAtMaterial != null)
        //{
        //    myRenderer.material = gazedAt ? gazedAtMaterial : inactiveMaterial;
        //    return;
        //}
    }

    public void ClickBlackBoard(BaseEventData eventData)
    {
        if (!checkClickAllowed(eventData))
            return;
        sphereScreenObject.SetActive(true);
        currentTextures = I_Blackboard_Texture;
        reticlePointerRenderer.enabled = false;
    }

    public void pageDown(BaseEventData eventData)
    {
        if (!checkClickAllowed(eventData))
            return;
        if (ppt_order < currentTextures.Length)
        {
            mainMaterial.mainTexture = currentTextures[ppt_order];
            ++ppt_order;
        }
        else
        {
            Reset();
        }
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

    public void Reset()
    {
        sphereScreenObject.SetActive(false);
        mainMaterial.mainTexture = testChessboardTexture[0];
        ppt_order = 0;
        reticlePointerRenderer.enabled = true;
    }
}
