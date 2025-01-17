using System;

namespace Machine
{
    internal class Fan
    {
        private Random _random = new Random();
        public FanEntity GetSpin(int fanId)
        {
            return new FanEntity(fanId, _random.Next(0,3000));
        }

        public void Start(int fanId)
        {
        }

        public void Stop(int fanId)
        {
        }
    }
}