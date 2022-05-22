using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using YandexTranslator.Models;

namespace YandexTranslator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Index(TranslateText model)
        {
            
          
            string text = model.Text; 

            var translator = new YandexTranslate();
            string translateText = translator.GetTranslate(text);
            JObject json = JObject.Parse(translateText);
            var models = new TranslateText { TranslateTexts = (string)json["translations"][0]["text"], Language = (string)json["translations"][0]["detectedLanguageCode"] };
            return View(models);
        }

        
    }
}
