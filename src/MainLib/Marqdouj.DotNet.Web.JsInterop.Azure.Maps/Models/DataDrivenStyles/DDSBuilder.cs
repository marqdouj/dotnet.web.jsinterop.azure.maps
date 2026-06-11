namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.DataDrivenStyles
{
    public static class DDSBuilder
    {
        public static object LinearInterpolate(string inputExpression, List<(double Case, string Value)> cases)
        {
            var builder = new LinearInterpolateStyleBuilder(inputExpression, cases);
            return builder.Build();
        }

        public static object Match(string inputExpression, List<(string Case, string Value)> cases, string? defaultCase)
        {
            var builder = new MatchStyleBuilder(inputExpression, cases, defaultCase);
            return builder.Build();
        }

        public static List<string> LiteralGet(string value)
        {
            return new List<string> { "get", value };
        }
    }
}
