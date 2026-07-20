namespace Sandbox.Models
{
    public class AppConfiguration(WebApplicationBuilder builder)
    {
        public bool IsDevelopment { get; } = builder.Environment.IsDevelopment();
    }
}
