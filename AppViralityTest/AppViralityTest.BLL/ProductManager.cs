using AppViralityTest.DAL.Core.Models;
using AppViralityTest.DAL.Persistance;
using AppViralityTest.DataModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppViralityTest.BLL
{
    public class ProductManager
    {
        public List<ProductViewModel> GetProducts()
        {
            using (var unityofwork = new UnitOfWork())
            {
                var products = unityofwork.Products.GetAll();
                var c = Mapper.Map<List<ProductViewModel>>(products);
                return c;
            }
        }

        public List<ProductViewModel> GetProductsByCategory(int CategoryId)
        {
            using (var unityofwork = new UnitOfWork())
            {
                var products = unityofwork.Products.GetAll().Where(q => q.FK_CategoryId == CategoryId);
                var c = Mapper.Map<List<ProductViewModel>>(products);
                return c;
            }
        }

        public void AddProduct(ProductDTO obj)
        {
            using (var unityofwork = new UnitOfWork())
            {
                var product = Mapper.Map<Product>(obj);
                unityofwork.Products.Add(product);
                unityofwork.Complete();
            }
        }

        public int GetCountOfProductsByCategory(int categoryId)
        {
            using (var unityofwork = new UnitOfWork())
            {
                return unityofwork.Products.GetAll().Where(q => q.FK_CategoryId == categoryId).Count();
            }
        }

        public List<ProductViewModel> GetProductsByCategoryByPages(int categoryId, int pageSize, int currentPage)
        {
            using (var unityofwork = new UnitOfWork())
            {
                var products = unityofwork.Products.GetAll().Where(q => q.FK_CategoryId == categoryId).Skip(pageSize * (currentPage - 1)).Take(pageSize);
                var c = Mapper.Map<List<ProductViewModel>>(products);
                return c;
            }
        }

        public void UpdateProduct(ProductDTO obj)
        {
            using (var unityofwork = new UnitOfWork())
            {
                var product = unityofwork.Products.Get(obj.Id);
                Mapper.Map(obj, product);
                unityofwork.Products.Update(product);
                unityofwork.Complete();
            }
        }

        public ProductViewModel GetProduct(int Id)
        {
            using (var unityofwork = new UnitOfWork())
            {
                var product = unityofwork.Products.SingleOrDefault(q => q.Id == Id);
                var c = Mapper.Map<ProductViewModel>(product);
                return c;
            }
        }
    }
}
