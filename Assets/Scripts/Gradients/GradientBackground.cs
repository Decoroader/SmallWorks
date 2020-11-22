using UnityEngine;
[ExecuteInEditMode]
public class GradientBackground : MonoBehaviour
{
    public Material bcgdMaterial;
    void Start()
    {
        // get level, choise material
    }
    private void OnRenderImage(RenderTexture source, RenderTexture dest)
    {
        Graphics.Blit(source, dest, bcgdMaterial);
    }
}
