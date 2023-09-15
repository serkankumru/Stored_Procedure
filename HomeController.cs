using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.EntityModel;
using DAL.Repository;
using Haberler.Filter;
using Haberler.Models;

namespace Haberler.Controllers
{
    public class HomeController : Controller
    {
        NewsRepository newsRepository;
        EditorRepository editorRepository;
        MessageRepository messageRepository;
        public HomeController(NewsRepository nRep, EditorRepository eRep, MessageRepository mRep)
        {
            newsRepository = nRep;
            editorRepository = eRep;
            messageRepository = mRep;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        public List<NewsEntitySP> ListCount(int count)
        {
            count = 3;
            var ctx = new NewsEntities();
            var rcparam = new SqlParameter("@rc", count);

            List<NewsEntitySP> resultSp = ctx.Database.SqlQuery<NewsEntitySP>("ReadCount @rc", rcparam).ToList();

            List<NewsEntitySP> result2 = (from n in ctx.NewsT
                                          join c in ctx.Catagory on n.CatId equals c.Id
                                          where n.ReadCount > count
                                          select new NewsEntitySP()
                                          {
                                              CatName = c.CatName,
                                              Title = n.Title,
                                              Spot = n.Spot,
                                              ReadCount = 5// Convert.ToInt32(n.ReadCount.Value.ToString())
                                          }).ToList();
            return resultSp;
        }
    }
}