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
        private static int _fanStopValue;

        /// <summary>
        /// 同じようなAPIは、語尾を変えてクライアント側に提供する
        /// </summary>
        /// <returns></returns>
        public static int BoxInternalTemperatureFunStop()
        {
            FanStop(0);

            try
            {
                System.Threading.Thread.Sleep(1000);
                var result = BoxGetInternalTemperature();
                _fanStopValue = result;
                return result;
            }
            finally
            {
                FanStart(0);
            }
        }

        public static int BoxGetInternalTemperature()
        {
            return new Box().GetInternalTemperature();
        }

        public static int BoxGetInternalTemperatureInMemory()
        {
            return _fanStopValue;
        }

        public static int BoxGetExternalTemperature()
        {
            return new Box().GetExternalTemperature();
        }

        public static void CameraTake()
        {
            // メソッドに利用手順がある場合にもファサードで吸収する
            // クライアントは利用手順を知らなくてもよい
            if (BoxGetInternalTemperature() > 60)
            {
                throw new Exception("内部温度が高すぎます");
            }

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
