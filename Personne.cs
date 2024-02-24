namespace MinimalAPI
{
    public class Personne
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public bool TryParse(string value, out Personne? person) 
        {
            try
            {
                var data = value.Split(' '); //split renvoie un tebleau de chaine de caractère
                person = new Personne();
                {
                    Nom = data[0]; //Le trableau renvoie le nom et le prénom
                    Prenom = data[1]; 
                }
                //Si ça se passe sans problème, il renvoie true
                return true;

            }
            catch(Exception)
            {
                person = null;
                return true;
            }
        }
    }
}
