 using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_MVC.Models;

namespace WebAPI_MVC.ApiControllers
{
    public class BrandController : ApiController
    {
        public IEnumerable<Brand> Get()
        {
            StoreEntities db = new StoreEntities();
            List<Brand> brands = db.Brands.ToList();

            return brands;
        }

        public IEnumerable<Brand> Post(Brand brand)
        {
            StoreEntities db = new StoreEntities();
            db.Brands.Add(brand);
            db.SaveChanges();

            // response brand list to post method
            return db.Brands.ToList();
        }

        public IEnumerable<Brand> Put(Brand brand)
        {
            StoreEntities db = new StoreEntities();
            Brand oldBrand = db.Brands.Where(br => br.BrandID == brand.BrandID).FirstOrDefault();

            oldBrand.BrandName = brand.BrandName;

            db.SaveChanges();

            // Response
            return db.Brands.ToList();
        }

        public IEnumerable<Brand> Delete(long id)
        {
            StoreEntities db = new StoreEntities();
            Brand brand = db.Brands.Where(br => br.BrandID == id).FirstOrDefault();

            db.Brands.Remove(brand);
            db.SaveChanges();

            // Response
            return db.Brands.ToList();
        }
    }
}
