namespace Machine
{
    public sealed class FanEntity
    {
        public FanEntity(int fanId, int value)
        {
            FanId = fanId;
            Value = value;
        }

        public int FanId { get; }
        public int Value { get; }
    }
}
