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
                var data = value.Split(' ');
                person = new Personne();
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
