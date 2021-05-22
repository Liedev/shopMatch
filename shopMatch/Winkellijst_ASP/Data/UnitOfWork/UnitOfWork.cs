using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winkellijst_ASP.Repositories;
using Winkellijst_ASP.Models;
using Winkellijst_ASP.Data;

namespace Winkellijst_ASP.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private IRepository<Gebruiker> _gebruikerRepo;
        private IRepository<Afdeling> _afdelingRepo;
        private IRepository<Product> _productRepo;
        private IRepository<Winkel> _winkelRepo;
        private IRepository<WinkelLijst> _winkelLijstRepo;


        public UnitOfWork(GebruikerContext gebruikerContext)
        {
            GebruikerContext = gebruikerContext;

        }
        private GebruikerContext GebruikerContext { get; }


        public IRepository<Gebruiker> GebruikerRepo
        {
            get
            {
                if (_gebruikerRepo == null)
                {
                    _gebruikerRepo = new Repository<Gebruiker>(GebruikerContext);
                }
                return _gebruikerRepo;
            }
        }

        

        public IRepository<Afdeling> AfdelingRepo
        {
            get
            {
                if (_afdelingRepo == null)
                {
                    _afdelingRepo = new Repository<Afdeling>(GebruikerContext);
                }
                return _afdelingRepo;
            }
        }
     
        public IRepository<Product> ProductRepo
        {
            get
            {
                if (_productRepo == null)
                {
                    _productRepo = new Repository<Product>(GebruikerContext);
                }
                return _productRepo;
            }
        }

        public IRepository<Winkel> WinkelRepo
        {
            get
            {
                if (_winkelRepo == null)
                {
                    _winkelRepo = new Repository<Winkel>(GebruikerContext);
                }
                return _winkelRepo;
            }
        }

        public IRepository<WinkelLijst> WinkelLijstRepo
        {
            get
            {
                if (_winkelLijstRepo == null)
                {
                    _winkelLijstRepo = new Repository<WinkelLijst>(this.GebruikerContext);
                }
                return _winkelLijstRepo;
            }
        }
        public void Dispose()
        {
            GebruikerContext.Dispose();
        }

        public int Save()
        {
            return GebruikerContext.SaveChanges();
        }
    }
}
