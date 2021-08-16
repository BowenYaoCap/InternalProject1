using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace InternalProject1.Models
{
    [Table("tablEmployees")]
    public class Employee
    {
        [Column("Name")]
        public string Name{get;set;}
        [Column("Role")]
        public string Role{get;set;}
        [Column("Email")]
        public string Email{get;set;}
    }
}