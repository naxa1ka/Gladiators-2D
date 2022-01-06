using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class GameBoardElementsSelector : MonoBehaviour
{
    [SerializeField] private GameBoard _gameBoard;
    
    private Camera _camera;

    private bool _isSelecting;
    private ElementType _currentSelectedElementType;
    private List<Element> _pastNeighboursSelectedElement = new List<Element>();
    private readonly List<Element> _selectedElements = new List<Element>();

    private bool IsAmountSelectedElementsEnough => _selectedElements.Count >= 3;
    
    public event Action<List<Element>> ONSelectingEnd;

    [Inject]
    private void Constructor(Camera cam)
    {
        _camera = cam;
    }

    public async UniTask<List<Element>> SelectingElements()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (TryStartSelecting())
                {
                    _isSelecting = true;
                }
            }

            if (Input.GetMouseButton(0))
            {
                if (_isSelecting)
                {
                    Selecting();
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (_isSelecting)
                {
                    if (IsAmountSelectedElementsEnough)
                    {
                        var elements = new List<Element>(_selectedElements);

                        ONSelectingEnd?.Invoke(elements);
                        SelectingEnd();

                        return elements;
                    }

                    SelectingEnd();
                }
            }

            await UniTask.Yield();
        }
    }

    private bool TryStartSelecting()
    {
        if (TrySelectElement(out Element element))
        {
            _currentSelectedElementType = element.ElementType;
            SelectNewElement(element);
            return true;
        }

        return false;
    }

    private void Selecting()
    {
        if (TrySelectElement(out Element element) && element.ElementType == _currentSelectedElementType)
        {
            if (_pastNeighboursSelectedElement.Contains(element))
            {
                SelectNewElement(element);
            }
        }
    }

    private void SelectingEnd()
    {
        _isSelecting = false;

        foreach (var element in _selectedElements)
        {
            element.DeselectSprite();
        }

        _selectedElements.Clear();
    }


    private void SelectNewElement(Element element)
    {
        if (_selectedElements.Contains(element)) return;

        element.SelectSprite();
        _pastNeighboursSelectedElement = GetNeighbours(element).ToList();
        _selectedElements.Add(element);
    }

    private bool TrySelectElement(out Element result)
    {
        result = null;

        Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.negativeInfinity);

        if (hit.collider != null)
        {
            result = hit.collider.GetComponent<Element>();
        }

        return result != null;
    }

    private IEnumerable<Element> GetNeighbours(Element element)
    {
        int x = element.GameBoardPosition.x;
        int y = element.GameBoardPosition.y;

        Vector2Int[] neighbours =
        {
            new Vector2Int(x - 1, y - 1),
            new Vector2Int(x + 1, y + 1),
            new Vector2Int(x - 1, y + 1),
            new Vector2Int(x + 1, y - 1),

            new Vector2Int(x - 1, y),
            new Vector2Int(x + 1, y),
            new Vector2Int(x, y - 1),
            new Vector2Int(x, y + 1)
        };

        return GetCorrectNeighbours(neighbours);
    }

    private IEnumerable<Element> GetCorrectNeighbours(Vector2Int[] neighbours)
    {
        foreach (var neighbour in neighbours)
        {
            if (IsCorrectIndex(neighbour))
            {
                yield return _gameBoard.GetElement(neighbour);
            }
        }
    }

    private bool IsCorrectIndex(Vector2Int point)
    {
        int x = point.x;
        int y = point.y;

        if (x < 0) return false;
        if (y < 0) return false;

        if (x > _gameBoard.Elements.GetLength(0) - 1) return false;
        if (y > _gameBoard.Elements.GetLength(1) - 1) return false;

        return true;
    }
}