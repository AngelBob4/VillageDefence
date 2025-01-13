using Infrastructure;
using Model;
using View;

namespace Presenter
{
    public class AddNotificationPresenter : IPresenter
    {
        private PauseService _pauseService;
        private AddNotificationView _view;

        public AddNotificationPresenter(PauseService pauseService, AddNotificationView view)
        {
            _pauseService = pauseService;
            _view = view;
        }

        public void Enable()
        {
            _pauseService.Pause(_view.gameObject);
        }

        public void Disable()
        {
            _pauseService.Unpause(_view.gameObject);
        }
    }
}