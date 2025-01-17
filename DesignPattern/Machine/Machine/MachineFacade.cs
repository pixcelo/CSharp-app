using System;

namespace Machine
{
    /// <summary>
    /// ファサード
    /// <remarks>
    /// クライアント側に知識がなくても、サブシステムを利用できるようにする
    /// </remarks>
    /// </summary>
    public class MachineFacade : IMachineFacade
    {
        private int _fanStopValue;

        /// <summary>
        /// 同じようなAPIは、語尾を変えてクライアント側に提供する
        /// </summary>
        /// <returns></returns>
        public int BoxInternalTemperatureFunStop()
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

        public int BoxGetInternalTemperature()
        {
            return new Box().GetInternalTemperature();
        }

        public int BoxGetInternalTemperatureInMemory()
        {
            return _fanStopValue;
        }

        public int BoxGetExternalTemperature()
        {
            return new Box().GetExternalTemperature();
        }

        public void CameraTake()
        {
            // メソッドに利用手順がある場合にもファサードで吸収する
            // クライアントは利用手順を知らなくてもよい
            if (BoxGetInternalTemperature() > 60)
            {
                throw new Exception("内部温度が高すぎます");
            }

            new Camera().Take();
        }

        public FanEntity FanSpin(int fanId)
        {
            return new Fan().GetSpin(fanId);
        }

        public void FanStart(int fanId)
        {
            new Fan().Start(fanId);
        }

        public void FanStop(int fanId)
        {
            new Fan().Stop(fanId);
        }

        public void PowerOn()
        {
            new Power().On();
        }

        public void PowerOff()
        {
            new Power().Off();
        }

        public void BacklightOff()
        {
            new Power().BacklightOff();
        }
    }
}
