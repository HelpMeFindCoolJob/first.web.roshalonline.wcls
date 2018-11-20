﻿using AutoMapper;
using Roshalonline.Data.Models;
using Roshalonline.Logic.Interfaces;
using Roshalonline.Logic.MiddleEntities;
using Roshalonline.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roshalonline.Web.Controllers
{
    public class InternetController : Controller
    {
        private IEntry<PeriodicTarifME> _periodicTarifService;

        public InternetController(IEntry<PeriodicTarifME> periodicTarifService)
        {
            _periodicTarifService = periodicTarifService;
        }


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Tarifs(string targetAudence = "Individual", string technology = "Ethernet")
        {
            try
            {
                IList<PeriodicTarifME> items = null;
                var listTarifsForHelper = _periodicTarifService.GetAllItems();
                ViewBag.Tarifs = listTarifsForHelper;
                switch (technology)
                {
                    case "Ethernet":
                        items = _periodicTarifService.GetItems(t => t.Category == Relevance.Active & t.TarifTechnology == Data.Entities.PeriodicTarif.Technology.Ethernet);
                        break;
                    case "ADSL":
                        items = _periodicTarifService.GetItems(t => t.Category == Relevance.Active & t.TarifTechnology == Data.Entities.PeriodicTarif.Technology.ADSL);
                        break;
                }
                Mapper.Initialize(cfg => cfg.CreateMap<PeriodicTarifME, PeriodicTarifVM>());
                var tarifsVM = (from t in Mapper.Map<IList<PeriodicTarifME>, IList<PeriodicTarifVM>>(items) orderby t.Price select t);

                if (targetAudence == "Individual")
                {
                    var individualTarif = from t in tarifsVM where t.Audience == Data.Entities.PeriodicTarif.TargetAudience.Individual select t;
                    return View(individualTarif.ToList());
                }
                else if (targetAudence == "Corporation")
                {
                    var individualTarif = from t in tarifsVM where t.Audience == Data.Entities.PeriodicTarif.TargetAudience.Corporation select t;
                    return View("CorporationTarifs", individualTarif.ToList());
                }
                else
                {
                    return RedirectToAction("Error", "Home", new { message = "Нет тарифов для данной категории клиентов" });
                }
            }
            catch (Exception exc)
            {
                return RedirectToAction("Error", "Home", new { message = exc.Message });
            }
        }

        [HttpGet]
        public ActionResult PersonalTarif()
        {
            return View();
        }

        
    }
}