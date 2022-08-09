namespace Mobile2D
{
    public class GameController : BaseController
    {
        public GameController()
        {
            CarController carController = new CarController();
            AddController(carController);
        }
    }
}