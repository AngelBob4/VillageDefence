using Infrastructure;
using Model;
using Model.PlayerComponents;

namespace Presenter
{
    public class GunPresenter : IPresenter
    {
        private Inventory _inventory;
        private Gun _model;

        public GunPresenter(Inventory inventory, Gun model)
        {
            _inventory = inventory;
            _model = model;
        }

        public void Enable()
        {
            _inventory.BulletPickedUp += OnBulletPickedUp;
        }

        public void Disable()
        {
            _inventory.BulletPickedUp -= OnBulletPickedUp;
        }

        private void OnBulletPickedUp()
        {
            _model.BulletPickUpSound();
        }
    }
}