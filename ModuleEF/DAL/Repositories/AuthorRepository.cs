﻿using ModuleEF.BLL.Models;
using ModuleEF.DAL.Entities;
using ModuleEF.PLL.Helpers;

namespace ModuleEF.DAL.Repositories
{
    public class AuthorRepository : BaseRepository
    {
        public AuthorRepository() :base()
        {
            lookingDelegate = LookForElementById<Author>;
            creationDelegate = CreateItem;
        }

        protected override Author CreateItem()
        {
            Console.WriteLine("\t\tДобавление автора");
            var author = new Author();
            try
            {
                CreateItemNameMethod(author);
            }
            catch (Exception ex)
            {
                author = null;
                ErrorMessage.Print(ex.Message);
            }
            return author!;
        }

        public override void UpdateItemById()
        {
            Console.WriteLine("Изменение автора по Id!");
            var author = (Author)lookingDelegate.Invoke(default);

            if(author != null)
            {
                using (db = new())
                {
                    try
                    {
                        CreateItemNameMethod(author);
                        db.Authors.Update(author);
                        db.SaveChanges();
                    }
                    catch (Exception ex) 
                    {
                        ErrorMessage.Print(ex.Message);
                    }
                }
            }
        }

        public void AddAuthorToBookMethod(Book book)
        {
            using (db = new())
            {
                try
                {
                    var author = LookForElementById<Author>(true);

                    book.AuthorId = author.Id;
                }
                catch (Exception ex)
                {
                    ErrorMessage.Print(ex.Message);
                }
            }
        }
    }
}
