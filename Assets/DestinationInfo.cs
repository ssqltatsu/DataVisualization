namespace DefaultNamespace
{
    public class DestinationInfo : UnityEngine.MonoBehaviour
    {
        private string destination;
        private string identification;
        private string adestination;
        private bool aFlag = false;
        
        public void InputDestination(string dest, string id)
        {
            destination = dest;
            identification = id;
        }

        public void InputADestination(string dest)
        {
            adestination = dest;
        }

        public string GetDestination()
        {
            return destination;
        }
        
        public string GetIdentification()
        {
            return identification;
        }
        
        public string GetADestination()
        {
            return adestination;
        }

    }
}