using UnityEngine;

public static class TransformExtension
{
    public static void ChangeParent(this Transform child, Transform parent) {
        child.parent = parent;
        child.localPosition = Vector3.zero;
        child.localRotation = Quaternion.identity;
        child.localScale = Vector3.one;
    }
}