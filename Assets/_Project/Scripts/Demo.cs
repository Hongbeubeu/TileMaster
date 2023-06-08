using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

public class Demo : MonoBehaviour
{
    [SerializeField] private TemplateData _templateData;
    [SerializeField] private GameObject _tilePrefab;

    [SerializeField, ReadOnly] private List<GameObject> _tiles = new();

    [Button(ButtonSizes.Gigantic)]
    private void GenerateBoard()
    {
        DestroyInstancedTiles();
        var position = Vector3.zero;
        position.z = -10f;
        for (var i = 0; i < _templateData.NumberOfLayer; i++)
        {
            for (var j = 0; j < _templateData.LayerBoardDatas[i].TilePositions.Count; j++)
            {
                var go = PrefabUtility.InstantiatePrefab(_tilePrefab, transform) as GameObject;
                position.x = _templateData.LayerBoardDatas[i].TilePositions[j].x;
                position.y = _templateData.LayerBoardDatas[i].TilePositions[j].y;
                go.transform.localPosition = position;
                _tiles.Add(go);
            }

            position.z += _templateData.LayerSpacing;
        }
    }

    private void DestroyInstancedTiles()
    {
        foreach (var t in _tiles)
        {
            DestroyImmediate(t);
        }

        _tiles.Clear();
    }
}