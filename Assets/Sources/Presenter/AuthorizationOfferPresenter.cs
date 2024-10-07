public class AuthorizationOfferPresenter : IPresenter
{
    private AuthorizationOffer _authorizationOffer;
    private AuthorizationOfferView _authorizationOfferView;

    public AuthorizationOfferPresenter(AuthorizationOffer authorizationOffer, AuthorizationOfferView authorizationOfferView)
    {
        _authorizationOffer = authorizationOffer;
        _authorizationOfferView = authorizationOfferView;
    }

    public void Enable()
    {
        _authorizationOfferView.OpenButtonClicked += OnOpenButtonClicked;
        _authorizationOfferView.AuthorizeButtonClicked += OnAuthorizeButtonClicked;
        _authorizationOfferView.CloseButtonClicked += Close;
    }

    public void Disable()
    {
        _authorizationOfferView.OpenButtonClicked -= OnOpenButtonClicked;
        _authorizationOfferView.AuthorizeButtonClicked -= OnAuthorizeButtonClicked;
        _authorizationOfferView.CloseButtonClicked -= Close;
    }

    private void OnAuthorizeButtonClicked()
    {
        _authorizationOffer.OnAuthorizeOpen();
    } 

    public void OnOpenButtonClicked()
    {
        _authorizationOffer.Open();
    }

    public void Close()
    {
        _authorizationOffer.Close();
    }
}