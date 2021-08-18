using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace InternalProject1.Models
{
    public class Employee
    {
       
        
        public string Name{get;set;}
        public string Role{get;set;}
        public string Email{get;set;}
         [Key]
        public int Id{get;set;}
    }
}