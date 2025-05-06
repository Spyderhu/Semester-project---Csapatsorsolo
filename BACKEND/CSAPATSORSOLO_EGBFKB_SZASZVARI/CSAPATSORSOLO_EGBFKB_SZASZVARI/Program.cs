using CSAPATSORSOLO_EGBFKB_SZASZVARI.Data;

namespace CSAPATSORSOLO_EGBFKB_SZASZVARI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddSingleton<ICsapatRepository, CsapatRepository>();

            var app = builder.Build();

            app.UseRouting();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action}/{id?}");

            app.Run();
        }
    }
}
