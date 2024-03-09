using Rsk.AspNetCore.Authentication.Saml2p;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "cookie";
    options.DefaultChallengeScheme = "saml2";
   

})
  .AddCookie("cookie")
  .AddSaml2p("saml2",options =>
  {
      options.Licensee = "DEMO";
      options.LicenseKey = " eyJTb2xkRm9yIjowLjAsIktleVByZXNldCI6NiwiU2F2ZUtleSI6ZmFsc2UsIkxlZ2FjeUtleSI6ZmFsc2UsIlJlbmV3YWxTZW50VGltZSI6IjAwMDEtMDEtMDFUMDA6MDA6MDAiLCJhdXRoIjoiREVNTyIsImV4cCI6IjIwMjQtMDEtMDVUMDE6MDA6MDEuMjMyMTk1MyswMDowMCIsImlhdCI6IjIwMjMtMTItMDZUMDE6MDA6MDEiLCJvcmciOiJERU1PIiwiYXVkIjoyfQ==.pfZMBYLBd/KDIRG9RVggt1sr4J1HpvHuTR2L681yj43WFjRjMxftcAnV0w77s1Q1ROl1Z4xiUzqlAF9aAr3cAoxywBRlktLY44IzxNSKBIMq0ZJFMgU41dZOu6xgxza2Onva1dkk/Zq4Gj7p+1t91FB/ovKyfwRgVI1PBpe2RSAqphI6bDA7w1IKn2uQdX/I8m8dw0h1yxg+IRDLjV31T4gNS/p75gN1Y8c3axYpxDw0iTgV5TE8shVP6OnjXUaRxWyCGvb6tUezHM4NPjmUWDSLpwq90c74bjF4GR+ZDoxKhHINtoEAFCWh+8zJQOdTDjfNKM5zbox896eVg5c/cNQLqxIaSVhcgWgfCAMJUPZJ1Av3tAPSno1GKzzhQXyUwyVe2okFyEQh2LbE4ox/W7vm5vMjf6FyI74h7GaVyDKnXvLHy0P07foZVzFOuLDw9GGHHHpXTnlzwNCMcpuCXY4aqSw70D89/0z7AEYO+lJYQ6CBN+dL+7iVYYtPqMAyBsS6sBswwCiWK8D+4LxWBna6xkMf4stWXtEINgnAXPbjCj3iOot2h/1gYAs+eVhnMg7Z7FTcTnD5LOGt580Wjhr9txtEWbw3tbzHbJem8cnZYTbAPXeUcrO9hY1GUgZS//ufagRshh+qfhLTzKcHNia6oqgJLwXORu4eEHU9L08=";
      //options.NameIdClaimType = "sub";
      options.CallbackPath = "/signin-saml";
      options.SignInScheme = "cookie";

      options.IdentityProviderMetadataAddress = "https://trial-6322492.okta.com/app/exk9qtt33iuLWckBo697/sso/saml/metadata";
      
      options.RequireValidMetadataSignature = false;
      options.TimeComparisonTolerance = 120;
      
      options.ServiceProviderOptions = new SpOptions
      {
          EntityId = "https://localhost:5032/saml"


      };

  }
  );
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

