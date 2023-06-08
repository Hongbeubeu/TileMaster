using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TemplateData", menuName = "Data/TemplateData", order = 0)]
public class TemplateData : ScriptableObject
{
    public List<LayerBoardData> LayerBoardDatas;
    public float LayerSpacing;
    public int NumberOfLayer => LayerBoardDatas.Count;
}

[Serializable]
public class LayerBoardData
{
    public int LayerIndex;
    public List<Vector2> TilePositions;
}