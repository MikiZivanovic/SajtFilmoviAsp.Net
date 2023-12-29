using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace WebApp.Models
{
    public class ApplicatonUser : IdentityUser
    {
       
        public string PunoIme { get; set; }
        public int Godine { get; set; }

        public string UrlSlike { get; set; }
        public List<Komentar> Komentari { get; set; }
    }
}
