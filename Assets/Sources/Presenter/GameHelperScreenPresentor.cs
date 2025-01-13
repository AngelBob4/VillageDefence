using Infrastructure;
using Model;
using View.UI;

namespace Presenter
{
    public class GameHelperScreenPresentor : IPresenter
    {
        private GameHelperScreen _screenOfGameHelper;
        private GameHelperScreenView _screenOfGameHelperView;

        public GameHelperScreenPresentor(GameHelperScreen screenOfGameHelper,
            GameHelperScreenView screenOfGameHelperView)
        {
            _screenOfGameHelper = screenOfGameHelper;
            _screenOfGameHelperView = screenOfGameHelperView;
        }

        public void Enable()
        {
            _screenOfGameHelperView.OpenButtonClicked += Open;
            _screenOfGameHelperView.ExitButtonClicked += Close;
        }

        public void Disable()
        {
            _screenOfGameHelperView.OpenButtonClicked -= Open;
            _screenOfGameHelperView.ExitButtonClicked -= Close;
        }

        private void Open()
        {
            _screenOfGameHelper.Open();
        }

        private void Close()
        {
            _screenOfGameHelper.Close();
        }
    }
}