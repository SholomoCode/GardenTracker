﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Tracker.Data;
using Tracker.Models;
using Tracker.ViewModels;
//using Microsoft.Software.Form;


namespace Tracker.Controllers
{
    public class WaterController : Controller
    {

        private TrackerDbContext Context;

        public WaterController(TrackerDbContext context)
        {
            Context = context;
        }


        public IActionResult Index()
        {

            List<Water> water = Context.Waters.ToList();
            //for (int i = 0; i < water.Count; i++)
            //{
            //    Seed theSeed = seed[i];

            //    if (theSeed.NeedsWater.Equals(DateTime.Now))
            //    {
            //        //put this i a viewbag and add message: DO THIS IN THE DOM IN JAVASCRIPT
            //    };
            //}

            return View(water);
        }



        [HttpPost]
        public IActionResult AddWaterSeedToBed(AddWaterSeedToBedViewModel viewModel)
        {
            //this is unfinished, im confused on how to connect seed and bed to the water id
            if (ModelState.IsValid)
            {

                int seedId = viewModel.SeedId;
                int bedId = viewModel.BedId;
                int waterId = viewModel.WaterId;


                Seed theSeed = context.Seed.Include(e => e.Water).Where(e => e.Id == seedId).First();
                Bed theBed = context.Bed.Where(t => t.Id == waterId).First();


                //Seed theSeed = context.Water.Include(b => b.Beds).Where(s => s.Id == seedId).First();
                //Bed theBed = context.Beds.Where(j => j.Id == bedId).First();



                theBed.Seeds.Add(theSeed);

                context.SaveChanges();

                return Redirect("/Bed/Detail/" + bedId);
            }
            return View("AddSeedToBed", viewModel);
        }

        [HttpGet]
        public IActionResult AddWaterSeedToBed(int id)
        {
            Bed theBed = context.Beds.Find(id);

            List<Seed> possibleSeeds = context.Seeds.ToList();

            AddSeedViewModel addSeedViewModel = new AddSeedViewModel(theBed, possibleSeeds);
            return View(addSeedViewModel);
        }
    }

}
