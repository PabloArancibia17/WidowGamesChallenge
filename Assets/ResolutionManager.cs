using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ResolutionManager : MonoBehaviour
{
    [SerializeField] private GameObject _landscapeOrientationGO, _portraitOrientationGO;
    void Awake()
    {
        _landscapeOrientationGO.SetActive(Screen.orientation == ScreenOrientation.Landscape);
        _portraitOrientationGO.SetActive(Screen.orientation == ScreenOrientation.Portrait);
    }
}
