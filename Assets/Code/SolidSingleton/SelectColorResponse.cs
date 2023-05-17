using UnityEngine;

internal class SelectColorResponse : MonoBehaviour, ISelectColor
{
    public ColorState SetColorState(ColorState settingColor)
    {
        return settingColor;
    }
}
