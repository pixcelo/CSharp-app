using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine
{
    public interface IMachineFacade
    {
        int BoxInternalTemperatureFunStop();

        int BoxGetInternalTemperature();

        int BoxGetInternalTemperatureInMemory();

        int BoxGetExternalTemperature();

        void CameraTake();

        FanEntity FanSpin(int fanId);

        void FanStart(int fanId);

        void FanStop(int fanId);

        void PowerOn();

        void BacklightOff();
    }
}
