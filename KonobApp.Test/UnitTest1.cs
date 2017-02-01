using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KonobApp.Model.Models;
using Objektno.Models;
using DAL.Repositories;
using KonobApp.Controller;
using KonobApp.Model.Repositories;
using KonobApp.Interfaces;

namespace KonobApp.Test
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Provjera metode repozitorija za dohvat artikla preko njegovog jedinstvenog broja
        /// </summary>
        [TestMethod]
        public void ArticleRepository_FindArticleByID()
        {
            ArticleRepository _articleRepository = ArticleRepository.GetInstance();

            ArticleModel article1 = new ArticleModel();
            ArticleModel article2 = new ArticleModel();

            article1.IDArticle = 1;
            article1.Name = "Kratka s 'ladnim";

            article2.IDArticle = 2;
            article2.Name = "Medica";

            _articleRepository.Articles.Add(article1);
            _articleRepository.Articles.Add(article2);

            Assert.AreEqual(article2, _articleRepository.FindArticleByID(article2.IDArticle));
        }

        /// <summary>
        /// Provjera metode repozitorija za dohvat samo slobodnih stolova u kafiću preko caffeID-a
        /// </summary>
        [TestMethod]
        public void CaffeRepository_ListFreeTablesInCaffe()
        {
            CaffeRepository _caffeRepository = CaffeRepository.GetInstance();

            CaffeModel caffe = new CaffeModel();
            TableModel tableFree = new TableModel();
            TableModel tableTaken = new TableModel();

            caffe.IDCaffe = 1;
            tableFree.IDTable = 1;
            tableFree.IsOccupied = false;
            tableTaken.IDTable = 1;
            tableTaken.IsOccupied = true;

            caffe.Tables.Add(tableFree);
            caffe.Tables.Add(tableTaken);

            _caffeRepository.Caffes.Add(caffe);

            Assert.AreEqual(1, _caffeRepository.ListFreeTablesInCaffe(1).Count);
            
        }

        /// <summary>
        /// Provjera metode repozitorija za provjeru da li korisnik ima adminska prava
        /// </summary>
        [TestMethod]
        public void AccountRepository_IsUserAdmin()
        {
            AccountRepository _accountRepository = AccountRepository.GetInstance();

            UserModel user1 = new UserModel();
            UserModel user2 = new UserModel();

            user1.Email = "adminko@admin.hr";
            user1.Password = "Fmc58tOk811007";
            user1.IsAdmin = true;

            user2.Name = "Ne-Adminko@fer.hr";
            user2.Password = "user2";
            user2.IsAdmin = false;

            _accountRepository.Users.Add(user1);
            _accountRepository.Users.Add(user2);

            Assert.AreEqual(true, _accountRepository.IsUserAdmin(user1.Email, user1.Password)); //je admin
            Assert.AreEqual(false, _accountRepository.IsUserAdmin(user2.Email, user2.Password)); //nije admin
        }

        /// <summary>
        /// Provjera metode repozitorija za dohvat kafića po adresi
        /// </summary>
        [TestMethod]
        public void CaffeRepository_FindCaffeByAddress()
        {
            CaffeRepository _caffeRepository = CaffeRepository.GetInstance();

            CaffeModel caffe1 = new CaffeModel();
            CaffeModel caffe2 = new CaffeModel();
            CaffeModel caffe3 = new CaffeModel();

            caffe1.IDCaffe = 1;
            caffe1.Adress = "Unska 8";

            caffe2.IDCaffe = 2;
            caffe2.Adress = "Vukovarksa 6";

            caffe3.IDCaffe = 3;
            caffe3.Adress = "Tuđmanova ulica 92";

            string adresa1 = "Unska 8";
            string adresa2 = "Zmajevac 18";

            Assert.AreEqual(adresa1, _caffeRepository.FindCaffeByAddress(caffe1.Adress).Adress);
            Assert.AreNotEqual(adresa2, _caffeRepository.FindCaffeByAddress(caffe2.Adress).Adress);
            Assert.AreNotEqual(caffe3, _caffeRepository.FindCaffeByAddress(caffe1.Adress));
        }
    }
}
