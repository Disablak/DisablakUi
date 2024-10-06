using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MyGraph : Graphic
{
    [SerializeField] private Vector2Int _gridSize;
    [SerializeField] private float      _thickness;
    [SerializeField] private List<Vector2> _points;

    private float _width;
    private float _height;
    private float _unitWidth;
    private float _unitHeight;


    protected override void OnPopulateMesh(VertexHelper vh) 
    {
        vh.Clear();

        _width = rectTransform.rect.width;
        _height = rectTransform.rect.height;

        _unitWidth = _width / _gridSize.x;
        _unitHeight = _height / _gridSize.y;

        if (_points.Count < 2)
        {
            return;
        }

        float angle = 0;
        for (int i = 0; i < _points.Count - 1; i++)
        {
            Vector2 point = _points[i];
            Vector2 point2 = _points[i+1];

            if (i < _points.Count - 1)
            {
                angle = GetAngle(_points[i], _points[i + 1]) + 90f;
            }

            DrawVerticesForPoint(point, point2, angle, vh);
        }

        for (int i = 0; i < _points.Count - 1; i++)
        {
            int index = i * 4;
            vh.AddTriangle(index + 0, index + 1, index + 2);
            vh.AddTriangle(index + 1, index + 2, index + 3);
        }
    }

    private float GetAngle(Vector2 me, Vector2 target)
    {
        //panel resolution go there in place of 9 and 16
        return (Mathf.Atan2(9f*(target.y - me.y), 16f*(target.x - me.x)) * Mathf.Rad2Deg);
    }

    private void DrawVerticesForPoint(Vector2 point, Vector2 point2, float angle, VertexHelper vh)
    {
        UIVertex vertex = UIVertex.simpleVert;
        vertex.color = color;

        vertex.position = Quaternion.Euler(0, 0, angle) * new Vector3(-_thickness / 2, 0);
        vertex.position += new Vector3(_unitWidth * point.x, _unitHeight * point.y);
        vh.AddVert(vertex);

        vertex.position = Quaternion.Euler(0, 0, angle) * new Vector3(_thickness / 2, 0);
        vertex.position += new Vector3(_unitWidth * point.x, _unitHeight * point.y);
        vh.AddVert(vertex);

        vertex.position = Quaternion.Euler(0, 0, angle) * new Vector3(-_thickness / 2, 0);
        vertex.position += new Vector3(_unitWidth * point2.x, _unitHeight * point2.y);
        vh.AddVert(vertex);

        vertex.position = Quaternion.Euler(0, 0, angle) * new Vector3(_thickness / 2, 0);
        vertex.position += new Vector3(_unitWidth * point2.x, _unitHeight * point2.y);
        vh.AddVert(vertex);
    }
}
