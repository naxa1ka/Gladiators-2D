using System;

public class CarouselPresenter<T>
{
    private readonly CarouselView _carouselView;
    private readonly Carousel<T> _carousel;

    public event Action<T> OnItemChanged;
    
    public CarouselPresenter(CarouselView carouselView, Carousel<T> carousel)
    {
        _carouselView = carouselView;
        _carousel = carousel;
    }

    public void Enable()
    {
        _carouselView.OnNextClicked += NextClicked;
        _carouselView.OnPreviousClicked += PreviousClicked;
        _carousel.OnItemChanged += ItemChanged;
    }

    private void ItemChanged(T item)
    {
        OnItemChanged?.Invoke(item);
    }

    private void NextClicked()
    {
        _carousel.Next();
    }

    private void PreviousClicked()
    {
        _carousel.Previous();
    }

    public void Disable()
    {
        _carouselView.OnNextClicked -= NextClicked;
        _carouselView.OnPreviousClicked -= PreviousClicked;
        _carousel.OnItemChanged -= ItemChanged;
    }
}