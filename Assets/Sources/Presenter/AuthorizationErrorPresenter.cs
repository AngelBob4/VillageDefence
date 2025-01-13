using Infrastructure;
using Model;
using View.Yandex.Leaderboard;

namespace Presenter
{
    public class AuthorizationErrorPresenter : IPresenter
    {
        private AuthorizationErrorView _authorizationErrorView;
        private AuthorizationError _authorizationError;

        public AuthorizationErrorPresenter(AuthorizationErrorView authorizationErrorView, AuthorizationError authorizationError)
        {
            _authorizationErrorView = authorizationErrorView;
            _authorizationError = authorizationError;
        }

        public void Enable()
        {
            _authorizationErrorView.Opening += OnOpen;
            _authorizationErrorView.CloseButtonClicked += OnClose;
        }

        public void Disable()
        {
            _authorizationErrorView.Opening -= OnOpen;
            _authorizationErrorView.CloseButtonClicked -= OnClose;
        }

        private void OnOpen()
        {
            _authorizationError.Open();
        }

        private void OnClose()
        {
            _authorizationError.Close();
        }
    }
}