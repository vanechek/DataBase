namespace DataBase.Helpers
{
    static class ExtensionMethods
    {
        public static double ConvertToDouble(this string line)
        {
            double result = 0.0;
            if (double.TryParse(line, out result) == true)
            {
                return result;
            }
            return result;
        }
    }
}
