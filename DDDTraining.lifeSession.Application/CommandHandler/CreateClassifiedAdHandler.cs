using DDDTraining.lifeSession.Application.Contract;
using DDDTraining.lifeSession.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDTraining.lifeSession.Application.CommandHandler
{
    public class CreateClassifiedAdHandler :
           IHandleCommand<ClassifiedAds.V1.Create>
    {
        private readonly IEntityStore _store;
        public CreateClassifiedAdHandler(IEntityStore store)
        => _store = store;
        public Task Handle(ClassifiedAds.V1.Create command)
        {
            var classifiedAd = new ClassifiedAd(
            new ClassifiedAdId(command.Id),
            new UserId(command.OwnerId));
            return _store.Save(classifiedAd);
        }
    }
}
