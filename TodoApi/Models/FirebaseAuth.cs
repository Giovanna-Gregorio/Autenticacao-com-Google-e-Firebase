using System.Collections.Generic;

namespace TodoApi.Models
{
    public class FirebaseAuth
    {
        public List<string> email { get; set; }
    }

    public class Firebase
    {
        public FirebaseAuth identities { get; set; }
    }
}