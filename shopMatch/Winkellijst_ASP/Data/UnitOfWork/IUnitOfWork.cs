using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winkellijst_ASP.Repositories;
using Winkellijst_ASP.Models;

namespace Winkellijst_ASP.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Gebruiker> GebruikerRepo { get; }
        IRepository<Afdeling> AfdelingRepo { get; }
        IRepository<Product> ProductRepo { get; }
        IRepository<Winkel> WinkelRepo { get; }
        IRepository<WinkelLijst> WinkelLijstRepo { get; }
        int Save();
    }

}
