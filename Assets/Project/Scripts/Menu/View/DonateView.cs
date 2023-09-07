public class DonateView : View
{
    public override void UpdateView(Model model)
    {
        _icon.sprite = model.Data.Icon;
        _header.text = model.Data.Header;
        _description.text = model.Data.Description;
        _price.text = model.Data.Price.ToString();
    }
}
