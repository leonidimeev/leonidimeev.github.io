using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using ToDo.Data;
using ToDo.Models;

namespace ToDo
{
    public class IPerson
    {
        public static Person LoginIn(ToDoContext db, string login, string password)
        {
            var user = (from person in db.Person where person.Login == login select person).FirstOrDefault<Person>();
            if (user != null && user.Password.CompareTo(password) == 0) return user;
            return null;
        }
        public static bool AddPerson(ToDoContext db, string fName, string sName, string tName, string login, string password, DateTime rDate, Level level)
        {
            Person New_Person = new Person
            {
                FirstName = fName,
                SecondName = sName,
                ThirdName = tName,
                Login = login,
                Password = password,
                RegistrationDate = rDate,
                Level = level
            };
            db.Person.Add(New_Person);
            db.SaveChanges();
            return true;
        }
        public static bool DeletePerson(ToDoContext db, Person user, int id)
        {
            if (user.Level == Level.Admin && user.ID != id)
            {
                var p = (from person in db.Person where person.ID == id select person).FirstOrDefault<Person>();
                db.Person.Remove(p);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
