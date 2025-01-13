using Infrastructure;
using Model;
using View.Yandex.Leaderboard;

namespace Presenter
{
    public class AuthorizationOfferPresenter : IPresenter
    {
        private AuthorizationOffer _authorizationOffer;
        private AuthorizationOfferView _authorizationOfferView;

        public AuthorizationOfferPresenter(
            AuthorizationOffer authorizationOffer,
            AuthorizationOfferView authorizationOfferView)
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

        private void OnOpenButtonClicked()
        {
            _authorizationOffer.Open();
        }

        private void Close()
        {
            _authorizationOffer.Close();
        }
    }
}