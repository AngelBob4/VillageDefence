public class AuthorizationError
{
    private PauseService _pauseService;
    private AuthorizationErrorView _authorizationErrorView;

    public AuthorizationError(PauseService pauseService, AuthorizationErrorView authorizationErrorView)
    {
        _pauseService = pauseService;
        _authorizationErrorView = authorizationErrorView;
    }

    public void Open()
    {
        _pauseService.Pause(_authorizationErrorView.gameObject);
        _authorizationErrorView.Show();
    }

    public void Close()
    {
        _pauseService.Unpause(_authorizationErrorView.gameObject);
    }
}