using Microsoft.AspNetCore.Mvc;
using MinimalAPI;
using System.Reflection.Metadata;
using System.Text;

// Création d'une nouvelle application Web
var builder = WebApplication.CreateBuilder();



// Construction de l'application
var app = builder.Build();

// Définition des routes et des méthodes HTTP correspondantes
app.MapGet("/hello", () => "Hello World!"); // Route GET pour "/hello"
app.MapDelete("/delete", () => "Hello DELETE"); // Route DELETE pour "/delete"
app.MapPost("/post", () => "Hello POST"); // Route POST pour "/post"
app.MapPut("/put", () => "Hello PUT"); // Route PUT pour "/put"
app.MapPatch("/patch", () => "Hello PATCH"); // Route PATCH pour "/patch"

// Route qui accepte à la fois les méthodes GET et POST
app.MapMethods("/methods", new[] { "GET", "POST" }, () => "Hellomethods");

// Route GET pour récupérer un article spécifique
app.MapGet("/article", () => new Article(1, "Marteau"));

// Route GET pour récupérer un article par son ID
app.MapGet("/articles/{id:int}", (int id) =>
{
    var article = new ArticleService().GetAll().Find(a => a.Id == id);
    if (article is not null) return Results.Ok(article);
    return Results.NotFound();
});

// Route GET pour récupérer un article par son titre
app.MapGet("/articles/{title}", (string title) => new Article(99999, "Marteau"));

// Route GET pour récupérer une personne par son nom, prénom (optionnel) et l'encodage (à partir de l'en-tête)
app.MapGet("/personne/{nom}", (
   [FromRoute] string nom,
   [FromQuery] string? prenom,
   [FromHeader(Name = "Accept-Encoding")] string encoding) => Results.Ok($"{nom} {prenom} {encoding}"));

//création clesse personne 

//app.MapGet("/personne/identite", (Personne p) => Results.Ok(p));

app.MapPost("/personne/identite", (Personne p) => Results.Ok(p));

//Route GET pour récupérer articles

app.MapGet("/article", (Article a) =>
{
    var result = new ArticleService().Add(a.Title);
    return Results.Ok(result);
});

// Exécution de l'application
app.Run();

//Ce code est un exemple d’une API Web simple utilisant le framework ASP.NET Core Minimal APIs.
//    Il définit plusieurs routes et méthodes HTTP pour interagir avec des articles et des personnes. 
//    Chaque route est associée à une fonction qui est exécutée lorsque la route est appelée avec la méthode HTTP correspondante. 
//    Les données sont stockées en mémoire pour la simplicité de cet exemple. Dans une application réelle, 
//    vous utiliseriez probablement une base de données pour stocker vos données. 
//    De plus, vous devriez également gérer les erreurs et les cas limites de manière plus robuste. 
//    Cet exemple est destiné à être une introduction simple aux concepts de base d’une API.