namespace Mobile2D
{
    internal class GameController : BaseController
    {
        public GameController(ProfilePlayer profilePlayer)
        {
            CarController carController = new CarController();
            
            var leftMoveDiff = new SubscriptionProperty<float>();
            var rightMoveDiff = new SubscriptionProperty<float>();
            TapeBackgroundController tapeBackgroundController = new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
            
            InputGameController inputGameController = new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar);
            
            AddController(carController);
            AddController(tapeBackgroundController);
            AddController(inputGameController);
        }
    }
}