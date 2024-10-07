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
        _authorizationErrorView.OnOpen += OnOpen;
        _authorizationErrorView.OnCloseButtonClicked += OnClose;
    }

    public void Disable()
    {
        _authorizationErrorView.OnOpen -= OnOpen;
        _authorizationErrorView.OnCloseButtonClicked -= OnClose;
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