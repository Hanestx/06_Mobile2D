namespace Mobile2D
{
    internal interface IAnalyticTools
    {
        void SendMessage(string nameEvent);
        void SendMessage(string nameEvent, (string, object) eventData);
    }
}