using exchangeRateList.Dat;
using exchangeRateList.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ExchanceDbContext>();
// Add services to the container.
builder.Services.AddRazorPages();
var app = builder.Build();

// Configure the HTTP request pipeline.
if( !app.Environment.IsDevelopment() )
{
    app.UseExceptionHandler( "/Error" );
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.MapGet( "/tikets", async ( HttpContext context, [FromServices] ExchanceDbContext dbContext ) =>
{
    try
    {
        if( !context.Request.Query.TryGetValue( "fromDatabase", out var fromDatabaseValue ) ||
                   !bool.TryParse( fromDatabaseValue, out bool fromDatabase ) )
        {
            return Results.BadRequest( "Invalid fromDatabase parameter" );
        }
        else
        {
            using var client = new HttpClient();
            var response = await client.GetAsync("https://webapi.developers.erstegroup.com/api/csas/public/sandbox/v2/rates/exchangerates?web-api-key=c52a0682-4806-4903-828f-6cc66508329e");

            if( !response.IsSuccessStatusCode )
            {
                return Results.StatusCode( (int) response.StatusCode );
            }

            var jsonString = await response.Content.ReadAsStringAsync();
            var data = System.Text.Json.JsonSerializer.Deserialize<List<Currency>>(jsonString);
            Task.Run( async () =>
            {
                await dbContext.Currency.AddRangeAsync( data );
            } );

            var sendData = System.Text.Json.JsonSerializer.Deserialize<JsonDocument>(jsonString);
            return Results.Json( sendData );

        }
    }
    catch( Exception e )
    {
        return Results.Problem( "An error occurred while processing the request" );
    }

} );

app.Run();
