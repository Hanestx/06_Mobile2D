namespace Mobile2D
{
    internal class GameController : BaseController
    {
        public GameController()
        {
            CarController carController = new CarController();
            AddController(carController);
        }
    }
}