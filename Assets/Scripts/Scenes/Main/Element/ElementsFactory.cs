using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class ElementsFactory : MonoBehaviour
{
    [SerializeField] private Element _air;
    [SerializeField] private Element _bomb;
    [SerializeField] private Element _earth;
    [SerializeField] private Element _fire;
    [SerializeField] private Element _meat;
    [SerializeField] private Element _shield;
    [SerializeField] private Element _water;
    [SerializeField] private Element _empty;

    private static readonly ElementType[] ElementTypesArray =
    {
        ElementType.Air, ElementType.Bomb,
        ElementType.Earth, ElementType.Fire,
        ElementType.Meat, ElementType.Shield,
        ElementType.Water
    };

    public Element Create(ElementType elementType)
    {
        switch (elementType)
        {
            case ElementType.Air:
                return Instantiate(_air);
            case ElementType.Bomb:
                return Instantiate(_bomb);
            case ElementType.Earth:
                return Instantiate(_earth);
            case ElementType.Fire:
                return Instantiate(_fire);
            case ElementType.Meat:
                return Instantiate(_meat);
            case ElementType.Shield:
                return Instantiate(_shield);
            case ElementType.Water:
                return Instantiate(_water);
            case ElementType.Empty:
                return Instantiate(_empty);
            default:
                throw new ArgumentOutOfRangeException(nameof(elementType), elementType,
                    "Такого элемента не существует!");
        }
    }

    public static ElementType GetRandomElementType()
    {
        return ElementTypesArray[Random.Range(0, ElementTypesArray.Length)];
    }

    public Element CreateRandomElement()
    {
        return Create(ElementTypesArray[Random.Range(0, ElementTypesArray.Length)]);
    }

    public Element CreateRandomElement(ElementType notIncludedElementType)
    {
        int randomIndex = Random.Range(0, ElementTypesArray.Length - 1);
        ElementType elementType = ElementTypesArray.Where(type => type != notIncludedElementType).ElementAt(randomIndex);
        return Create(elementType);
    }
}   