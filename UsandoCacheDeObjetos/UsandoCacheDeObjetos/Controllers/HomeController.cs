using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsandoCacheDeObjetos.Models;

namespace UsandoCacheDeObjetos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var clientes = RetornaClientes();
            return View(clientes);
        }

        private static IEnumerable<Cliente> RetornaClientes()
        {
            yield return new Cliente { Nome = "Zé das couve", Email = "zedascouve@ze.com.br"};
            yield return new Cliente { Nome = "Zé", Email = "ze@ze.com.br" };
            yield return new Cliente { Nome = "Teste", Email = "teste@teste.com.br" };
            yield return new Cliente { Nome = "Sem ideia", Email = "sem@ideia.com.br" };
            yield return new Cliente { Nome = "Sem criatividade", Email = "sem@criatividade.com.br" };
            yield return new Cliente { Nome = "Sem paciencia", Email = "sem@paciencia.com.br" };
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}