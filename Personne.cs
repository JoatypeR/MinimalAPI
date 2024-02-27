using Microsoft.AspNetCore.Http.HttpResults;
using System.Reflection;

namespace MinimalAPI
{
    public class Personne
    {
        private object person;

        public string Nom { get; set; }
        public string Surname { get; set; }

        //public bool TryParse(string value, out Personne? person) 
        //{
        //    try
        //    {
        //        var data = value.Split(' '); //split renvoie un tebleau de chaine de caractère
        //        person = new Personne
        //        {
        //            Nom = data[0], //Le trableau renvoie le nom et le prénom
        //            Surname = data[1]
        //        };
        //        //Si ça se passe sans problème, il renvoie true
        //        return true;

        //    }
        //    catch(Exception)
        //    {
        //        person = null;
        //        return true;
        //    }
        public static async ValueTask<Personne> BindAsync(
            HttpContext context, ParameterInfo parameterInfo)
        {
            try
            {
                using var StreamReader = new StreamReader(context.Request.Body);
                var body = await StreamReader.ReadToEndAsync();
                var data = body.Split(' ');
                var person = new Personne
                {
                    Nom = data[0], //Le tableau renvoie le nom et le prénom
                    Surname = data[1]
                };
                //Si ça se passe sans problème, il renvoie true
                return person;

            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
