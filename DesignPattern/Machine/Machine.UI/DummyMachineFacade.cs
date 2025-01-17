using System;

namespace Machine.UI
{
    internal sealed class DummyMachineFacade : IMachineFacade
    {
        public void BacklightOff()
        {
            throw new NotImplementedException();
        }

        public int BoxGetExternalTemperature()
        {
            throw new NotImplementedException();
        }

        public int BoxGetInternalTemperature()
        {
            throw new NotImplementedException();
        }

        public int BoxGetInternalTemperatureInMemory()
        {
            throw new NotImplementedException();
        }

        public int BoxInternalTemperatureFunStop()
        {
            throw new NotImplementedException();
        }

        public void CameraTake()
        {
            throw new NotImplementedException();
        }

        public FanEntity FanSpin(int fanId)
        {
            throw new NotImplementedException();
        }

        public void FanStart(int fanId)
        {
            throw new NotImplementedException();
        }

        public void FanStop(int fanId)
        {
            throw new NotImplementedException();
        }

        public void PowerOn()
        {
            throw new NotImplementedException();
        }
    }
}
