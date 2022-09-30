using DDDTraining.lifeSession.Application.CommandHandler;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDDTraining.lifeSession.WEB.Controllers
{
    [Route("/adCommHand")]
    public class ClassifiedAdsCommandsHandlerApi : Controller
    {
        //private readonly IHandleCommand<Application.Contract.ClassifiedAds.V1.Create>
        //_createAdCommandHandler;

        private readonly Func<IHandleCommand<Application.Contract.ClassifiedAds.V1.Create>>
         _createAdCommandHandlerFactory;

        public ClassifiedAdsCommandsHandlerApi(
                Func<IHandleCommand<Application.Contract.ClassifiedAds.V1.Create>>
                 createAdCommandHandler
                ) =>
             _createAdCommandHandlerFactory = createAdCommandHandler;


        [HttpPost]
        public Task Post(Application.Contract.ClassifiedAds.V1.Create request) =>
       _createAdCommandHandlerFactory().Handle(request);
        public IActionResult Index()
        {
            return View();
        }
    }
}
