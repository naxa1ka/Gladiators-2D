using System.Collections.Generic;
using UnityEngine;

public class GameBoardElementsReplacer : MonoBehaviour
{
    [SerializeField] private GameBoard _gameBoard;
    [SerializeField] private GameBoardElementsSelector _gameBoardElementsSelector;

    public void OnEnable()
    {
        _gameBoardElementsSelector.ONSelectingEnd += ReplaceElements;
    }
    
    private void ReplaceElements(List<Element> elements)
    {
        foreach (var element in elements)
        {
          ReplaceElement(element);
        }
    }

    private void ReplaceElement(Element oldElement)
    {
        Element newElement = _gameBoard.ElementsFactory.CreateRandomElement(oldElement.ElementType);
        
        _gameBoard.SetElement(oldElement.GameBoardPosition, newElement);
        CopyProperties(oldElement, newElement);

        newElement.PlayLightAnimation();
        
        Destroy(oldElement.gameObject);
    }
    
    private void CopyProperties(Element oldElement, Element newElement)
    {
        newElement.transform.position = oldElement.transform.position;
        newElement.GameBoardPosition = oldElement.GameBoardPosition;
        newElement.transform.SetParent(oldElement.transform.parent);
    } 

    private void OnDisable()
    {
        _gameBoardElementsSelector.ONSelectingEnd -= ReplaceElements;
    }
}