using UnityEngine;

public static class CameraExtensions
{

    public static void LayerCullingShow(this Camera cam, int layerMask)
    {
        cam.cullingMask |= layerMask;
    }

    public static void LayerCullingShow(this Camera cam, string layer)
    {
        LayerCullingShow(cam, 1 << LayerMask.NameToLayer(layer));
    }

    public static void LayerCullingHide(this Camera cam, int layerMask)
    {
        cam.cullingMask &= ~layerMask;
    }

    public static void LayerCullingHide(this Camera cam, string layer)
    {
        LayerCullingHide(cam, 1 << LayerMask.NameToLayer(layer));
    }

    public static void LayerCullingToggle(this Camera cam, int layerMask)
    {
        cam.cullingMask ^= layerMask;
    }


}