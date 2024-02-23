using MinimalAPI;

var builder = WebApplication.CreateBuilder();

var list = new List<Article>();
{
    new Article(1, "Marteau");
    new Article(2, "Scie");

}

var app = builder.Build();

app.MapGet("/hello", () => "Hello World!");
app.MapDelete("/delete", () => "Hello DELETE");
app.MapPost("/post", () => "Hello POST");
app.MapPut("/put", () => "Hello PUT");
app.MapPatch("/patch", () => "Hello PATCH");

app.MapMethods("/methods", new[] { "GET", "POST" }, () => "Hellomethods");

app.MapGet("/article", () => new Article(1, "Marteau"));
app.MapGet("/articles/{id:int}", (int id) =>

{
    var article = list.Find(a => a.Id == id);
    if (article is not null) return article;
});


app.MapGet("/articles/{title}", (string title) => new Article(99999, "Marteau")); //Définiion valeur dynamique, en gros on peut mettre le


app.Run();

