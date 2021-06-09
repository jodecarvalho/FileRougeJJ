
namespace FR_ApiData.Controllers
{
using FR_DataAccessLayer.EF.AccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using FR_ApiData.Models;
    public class ReponseController : ApiController
    {

        private ReponseAccessLayer reponseAccessLayer = new ReponseAccessLayer();


        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = reponseAccessLayer.GetAll().Select(p => new Reponse
            {
                ReponseId = p.ReponseId,
                Libelle = p.Libelle,
                Vraie = p.Vraie
            });
            return this.Ok(result);
        }

        [HttpGet]
        public IHttpActionResult Get(int? id)
        {
            if (id == null)
            {
                return this.BadRequest();
            }
            var reponse = reponseAccessLayer.Get((int)id);
            if (reponse == null)
            {
                return this.NotFound();
            }
            var result = new Reponse
            {
                ReponseId = reponse.ReponseId,
                Libelle = reponse.Libelle,
                Vraie = reponse.Vraie
            };
            return this.Ok(result);
        }

        //[HttpPost]
        //public IHttpActionResult Create([FromBody] Reponse reponse)
        //{
        //    if (reponseAccessLayer.Get(reponse.ReponseId) == null) { return this.NotFound(); }
        //    var reponseToAdd = new FR_DataAccessLayer.Models.Reponse
        //    {
                
        //        Nom = pizza.Nom,
        //        PateId = pizza.Pate.Id,
        //    };
        //    pizzaToAdd.PizzaIngredients = pizza.Ingredients.Select(ip => new DAL.Models.PizzaIngredient { Pizza = pizzaToAdd, IngredientId = ip.Id }).ToList();

        //    db.Add(pizzaToAdd);
        //    return this.Ok("created");
        //}

        //[HttpPut]
        //public IHttpActionResult Update(int id, [FromBody] Pizza pizza)
        //{
        //    if (!pdb.Exists(pizza.Pate.Id))
        //    {
        //        return this.NotFound();
        //    }

        //    if (!idb.Exists(pizza.Ingredients.Select(i => i.Id).ToList()))
        //    {
        //        return this.NotFound();
        //    }

        //    var pizzaToUpdate = new DAL.Models.Pizza
        //    {
        //        Id = pizza.Id,
        //        Nom = pizza.Nom,
        //        PateId = pizza.Pate.Id,
        //        PizzaIngredients = pizza.Ingredients.Select(i => new DAL.Models.PizzaIngredient { IngredientId = i.Id, PizzaId = pizza.Id }).ToList()
        //    };

        //    db.Update(pizzaToUpdate);

        //    return this.Ok("updated");
        //}

        //[HttpDelete]
        //public IHttpActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return this.BadRequest();
        //    }
        //    var pizzaToDelete = db.Get((int)id);
        //    if (pizzaToDelete == null)
        //    {
        //        return this.NotFound();
        //    }

        //    db.Delete(pizzaToDelete.Id);
        //    return this.Ok("Delete");
        //}
        //// GET: Reponse
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}