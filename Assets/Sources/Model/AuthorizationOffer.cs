using View.Yandex.Leaderboard;
using YG;

namespace Model
{
    public class AuthorizationOffer
    {
        private AuthorizationOfferView _authorizationOfferView;
        private AuthorizationError _authorizationError;
        private PauseService _pauseService;

        public AuthorizationOffer(AuthorizationOfferView authorizationOfferView,
            PauseService pauseService,
            AuthorizationError authorizationError)
        {
            _authorizationOfferView = authorizationOfferView;
            _pauseService = pauseService;
            _authorizationError = authorizationError;
        }

        public void Open()
        {
            _pauseService.Pause(_authorizationOfferView.gameObject);
            _authorizationOfferView.Show();
            YandexGame.Instance.ResolvedAuthorization.AddListener(OnAuthorizeSuccess);
            YandexGame.Instance.RejectedAuthorization.AddListener(OnAuthorizeError);
        }

        public void Close()
        {
            _pauseService.Unpause(_authorizationOfferView.gameObject);
            _authorizationOfferView.Hide();
            YandexGame.Instance.ResolvedAuthorization.RemoveListener(OnAuthorizeSuccess);
            YandexGame.Instance.RejectedAuthorization.RemoveListener(OnAuthorizeError);
        }

        public void OnAuthorizeOpen()
        {
            YandexGame.AuthDialog();
        }

        public void OnAuthorizeSuccess()
        {
            Close();
        }

        public void OnAuthorizeError()
        {
            Close();
        }
    }
}