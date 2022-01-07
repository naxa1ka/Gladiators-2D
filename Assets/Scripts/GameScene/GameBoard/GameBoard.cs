using UnityEngine;

public class GameBoard : MonoBehaviour
{
    [SerializeField] private ElementsFactory _elementsFactory;
    [SerializeField] private float _sizeOfSprite = 0.8f;
    [SerializeField] private ArrayLayout<ElementType> _arrayLayout;

    private readonly Element[,] _elements = new Element[ArrayLayout<int>.Size, ArrayLayout<int>.Size];
    
    public Element[,] Elements => _elements;
    public ElementsFactory ElementsFactory => _elementsFactory;

    public void Init(ArrayLayout<ElementType> gameBoard)
    {
        _arrayLayout = gameBoard;
        InitGameBoard();
    }

    public Element GetElement(Vector2Int gameBoardPosition)
    {
        return _elements[gameBoardPosition.x, gameBoardPosition.y];
    }

    public void SetElement(Vector2Int gameBoardPosition, Element element)
    {
        _elements[gameBoardPosition.x, gameBoardPosition.y] = element;
    }

    private void InitGameBoard()
    {
        ClearGameBoard();

        for (int i = 0; i < _elements.GetLength(0); i++)
        {
            for (int j = 0; j < _elements.GetLength(1); j++)
            {
                _elements[i, j] = _elementsFactory.Create(_arrayLayout[i, j]);
                _elements[i, j].transform.SetParent(gameObject.transform);

                var gameBoardPosition = gameObject.transform.position;
                _elements[i, j].transform.position =
                    new Vector2(
                        gameBoardPosition.x + j * _sizeOfSprite,
                        gameBoardPosition.y - i * _sizeOfSprite
                    );

                _elements[i, j].GameBoardPosition = new Vector2Int(i, j);
            }
        }
    }

    private void ClearGameBoard()
    {
        foreach (var element in FindObjectsOfType<Element>())
        {
            Destroy(element.gameObject);
        }
    }
}