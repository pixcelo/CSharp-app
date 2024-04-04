namespace SampleLog.NET8.Utils
{
    public static class ExpressionConverter
    {
        private static readonly Dictionary<string, string> _operands = new Dictionary<string, string>()
        {
            { "x", "*" },
            { "÷", "/" }
        };

        public static string Convert(string expression)
        {
            var result = expression;

            foreach (var operand in _operands)
            {
                result = result.Replace(operand.Key, operand.Value);
            }

            return result;
        }
    }
}
