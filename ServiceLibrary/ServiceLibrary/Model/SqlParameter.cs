namespace ServiceLibrary.Model
{
    public class SqlParameter
    {
        private string parameterName;
        private object parameterValue;

        public object ParameterValue { get => parameterValue; set => parameterValue = value; }
        public string ParameterName { get => parameterName; set => parameterName = value; }

        public SqlParameter(string parameterName, object parameterValue)
        {
            this.parameterName = parameterName;
            this.parameterValue = parameterValue;
        }
    }
}