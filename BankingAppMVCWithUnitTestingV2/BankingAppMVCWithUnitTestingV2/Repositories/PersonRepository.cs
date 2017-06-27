using BankingAppMVCWithUnitTestingV2.DataAccess;
using BankingAppMVCWithUnitTestingV2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BankingAppMVCWithUnitTestingV2.Repositories
{
    public class PersonRepository : IDisposable
    {
        public BankContext db = new BankContext();

        public IEnumerable<Person> Persons()
        {
            return db.Persons;
        }

        public Person Person(int? id)
        {
            var query = (from p in db.Persons
                        where p.ID == id
                        select p).FirstOrDefault();
            return query;
        }

        public void Add(Person person)
        {
                db.Persons.Add(person);
                db.SaveChanges();
        }

        public void Remove(Person person)
        {
            if (db.Persons.Contains(person))
            {
                db.Persons.Remove(person);
                db.SaveChanges();
            }
        }

        public void Edit(Person person)
        {
            if (db.Persons.Contains(person))
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public IEnumerable<Person> GetByFName(string Fname)
        {
            var query = from p in db.Persons
                        where p.Fname == Fname
                        select p;
            return query;
        }

        public IEnumerable<Person> GetByLName(string Lname)
        {
            var query = from p in db.Persons
                        where p.Lname == Lname
                        select p;
            return query;
        }

        public Person GetByPersonNum(string PersonNum)
        {
            var query = (from p in db.Persons
                         where p.PersonNum == PersonNum
                         select p).FirstOrDefault();
            return query;
        }

        public Person GetByEmail(string Email)
        {
            var query = (from p in db.Persons
                         where p.Email == Email
                         select p).FirstOrDefault();
            return query;
        }

        public IEnumerable<Person> GetByAddress(string Address)
        {
            var query = from p in db.Persons
                        where p.Address == Address
                        select p;
            return query;
        }

        #region IDisposable Support

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}