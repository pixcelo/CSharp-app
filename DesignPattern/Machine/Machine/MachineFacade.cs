using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine
{
    /// <summary>
    /// ファサード
    /// <remarks>
    /// クライアント側に知識がなくても、サブシステムを利用できるようにする
    /// </remarks>
    /// </summary>
    public static class MachineFacade
    {
        public static int BoxGetInternalTemperature()
        {
            return new Box().GetInternalTemperature();
        }

        public static int BoxGetExternalTemperature()
        {
            return new Box().GetExternalTemperature();
        }

        public static void CameraTake()
        {
            new Camera().Take();
        }

        public static FanEntity FanSpin(int fanId)
        {
            return new Fan().GetSpin(fanId);
        }

        public static void FanStart(int fanId)
        {
            new Fan().Start(fanId);
        }

        public static void FanStop(int fanId)
        {
            new Fan().Stop(fanId);
        }

        public static void PowerOn()
        {
            new Power().On();
        }

        public static void PowerOff()
        {
            new Power().Off();
        }

        public static void BacklightOff()
        {
            new Power().BacklightOff();
        }
    }
}
