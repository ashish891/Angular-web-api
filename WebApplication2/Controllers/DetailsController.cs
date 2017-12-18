using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApplication2.Models;


namespace WebApplication2.Controllers
{

    // [RoutePrefix("api/{controller}/{action}")]
    public class DetailsController : ApiController
    {
      
        private OurDbContext db = new OurDbContext();
        // GET: api/Details
    [HttpGet]
    [ActionName("Get")]
        public IEnumerable<ADetail> Get()
        {
           /* List<ViewData> usr = new List<ViewData>();

             var q = (from pd in db.Dbdetail
                   join od in db.Dbspecl on pd.Id equals od.DID
                       select new
                   {
                       pd.Id,
                       pd.Name,
                       pd.Phone,
                       pd.Address,
                       od.Spec,
                       od.SrNo
                   }); 

            //     var module = new List<ViewModule>();
             foreach (var t in q)
             {
                 usr.Add(new ViewData()
                 {
                     Id = t.Id,
                     Name = t.Name,
                     Phone = t.Phone,
                     Address = t.Address,
                     Spec = t.Spec,
                     SrNo=t.SrNo

                 });
             }
       
            return usr;*/

            return db.Dbdetail;
        }

        // GET: api/Details/5
        [HttpGet]
        [ActionName("GetId")]
    public IHttpActionResult GetId(int id)
        {
/*            List<ViewData> usr = new List<ViewData>();

            var q = (from pd in db.Dbdetail
                     join od in db.Dbspecl on pd.Id equals od.DID where pd.Id==id
                     select new
                     {
                         pd.Id,
                         pd.Name,
                         pd.Phone,
                         pd.Address,
                         od.Spec,
                         od.SrNo
                     });

            //     var module = new List<ViewModule>();
            foreach (var t in q)
            {
                usr.Add(new ViewData()
                {
                    Id = t.Id,
                    Name = t.Name,
                    Phone = t.Phone,
                    Address = t.Address,
                    Spec = t.Spec,
                    SrNo = t.SrNo

                });
            }

           return usr;*/


            ADetail aDetail = db.Dbdetail.Find(id);
                     
            if (aDetail == null)
            {
                return NotFound();
            }

            return Ok(aDetail);
        }

        // GET: api/Details/5
        [HttpGet]
        [ActionName("GetName")]
        public IEnumerable<ADetail> GetName(string id)
        {
           /* List<ViewData> usr = new List<ViewData>();

            var q = (from pd in db.Dbdetail
                     join od in db.Dbspecl on pd.Id equals od.DID
                     where pd.Name.Equals(id)
                     select new
                     {
                         pd.Id,
                         pd.Name,
                         pd.Phone,
                         pd.Address,
                         od.Spec
                     });

            //     var module = new List<ViewModule>();
            foreach (var t in q)
            {
                usr.Add(new ViewData()
                {Id=t.Id,
                    Name = t.Name,
                    Phone = t.Phone,
                    Address = t.Address,
                    Spec = t.Spec

                });
            }

            return usr;
           */

            List<ADetail> usr = new List<ADetail>();
            var res=(from pd in db.Dbdetail  where pd.Name.Equals(id)
                         select new
                     {
                         pd.Id,
                         pd.Name,
                         pd.Phone,
                         pd.Address,
                         pd.Spec
                     });

            if (res != null)
            {
                foreach (var t in res)
                {
                    usr.Add(new ADetail()
                    {
                        Id = t.Id,
                        Name = t.Name,
                        Phone = t.Phone,
                        Address = t.Address,
                        Spec = t.Spec

                    });
                }
                return usr;
            }

            return usr;
        }
       
        // POST: api/Details
        [HttpPost]
        [ActionName("PostData")]
        public void Post(ADetail aDetail)
        {
           /* if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }*/

            db.Dbdetail.Add(aDetail);
            db.SaveChanges();
        }

        // PUT: api/Details/5
        public HttpResponseMessage Put(int id, [FromBody]string value)
        {
            if(ModelState.IsValid)
            {
                db.Entry(value).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, value);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, value);
            }
        }

        // DELETE: api/Details/5
        [HttpPost]
        [AcceptVerbs("DELETE")]
        [ActionName("DeleteDetail")]
        public void Delete(int id)
        {
            ADetail spec = db.Dbdetail.Find(id);
            if (spec != null)
            {
                try
                {
                    db.Dbdetail.Remove(spec);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            } 
        }
      

    }
}
