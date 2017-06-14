using AppViralityTest.DAL.Core.Models;
using AppViralityTest.DAL.Persistance;
using AppViralityTest.DataModels;
using AutoMapper;
using System.Collections.Generic;
using System;

namespace AppViralityTest.BLL
{
    public class CategoryManager
    {
        public List<CategoryViewModel> GetCategories()
        {
            using (var unityofwork = new UnitOfWork())
            {
                var categories = unityofwork.Categories.GetAll();
                var c = Mapper.Map<List<CategoryViewModel>>(categories);
                return c;
            }
        }

    }
}
