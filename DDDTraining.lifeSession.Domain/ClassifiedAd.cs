using DDDTraining.lifeSession.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DDDTraining.lifeSession.Domain
{
   public class ClassifiedAd : AggregateRoot<ClassifiedAdId>
    {
        public ClassifiedAdId Id { get; private set; }
        public UserId OwnerId { get; private set; }
        public ClassifiedAdTitle Title { get; private set; }

        public string Text { get; private set; }
        public Price Price { get; private set; }
        public UserId ApprovedBy { get; private set; }
        public ClassifiedAdState State { get; private set; }
        public List<Picture> Pictures { get; private set; }


        public ClassifiedAd(ClassifiedAdId id, UserId ownerId)
        {
            Pictures = new List<Picture>();
            Apply(new Events.ClassifiedAdCreated
            {
                Id = id,
                OwnerId = ownerId
            });
        }
        
        public void SetTitle(ClassifiedAdTitle title)
       => 
            Apply(new Events.ClassifiedAdTitleChanged
            {
                Id = Id,
                Title = title
            });
        
        public void UpdateText(string text)
        =>
            Apply(new Events.ClassifiedAdTextUpdated
            {
                Id = Id,
                AdText = text
            });
        
        public void UpdatePrice(Price price)
        =>  
            Apply(new Events.ClassifiedAdPriceUpdated
            {
                Id = Id,
                Price = Price.Amount,
                CurrencyCode = Price.Currency.CurrencyCode
            });        

        public void RequestToPublish()=>    
            Apply(new Events.ClassifiedAdSentForReview { Id = Id });

        public void AddPicture(Uri pictureUri, PictureSize size) =>
                Apply(new Events.PictureAddedToAClassifiedAd
                {
                    PictureId = new Guid(),
                    ClassifiedAdId = Id,
                    Url = pictureUri.ToString(),
                    Height = size.Height,
                    Width = size.Width
                });

        public void ResizePicture(PictureId pictureId, PictureSize newSize)
        {
            var picture = FindPicture(pictureId);
            if (picture == null)
                throw new InvalidOperationException(
                "Cannot resize a picture that I don't have");
            picture.Resize(newSize);
        }

        private Picture FindPicture(PictureId id)
                => Pictures.FirstOrDefault(x => x.Id == id);
        private Picture FirstPicture
        => Pictures.OrderBy(x => x.Order).FirstOrDefault();

        // contract 
        protected override void EnsureValidState()
        {
            var valid =
            Id != null &&
            OwnerId != null &&
            (State switch
            {
                ClassifiedAdState.PendingReview =>
                       Title != null
                       && Text != null
                       && Price?.Amount > 0
                       && FirstPicture.HasCorrectSize(),
                ClassifiedAdState.Active =>
                   Title != null
                    && Text != null
                    && Price?.Amount > 0
                    && ApprovedBy != null
                    && FirstPicture.HasCorrectSize(),
                                _ => true
              });
            if (!valid)
                throw new InvalidEntityStateException(
                this, $"Post-checks failed in state {State}");
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.ClassifiedAdCreated e:
                    Id = new ClassifiedAdId(e.Id);
                    OwnerId = new UserId(e.OwnerId);
                    State = ClassifiedAdState.Inactive;
                    break;
                case Events.ClassifiedAdTitleChanged e:
                    Title = new ClassifiedAdTitle(e.Title);
                    break;
                case Events.ClassifiedAdTextUpdated e:
                    Text = e.AdText;
                    break;
                case Events.ClassifiedAdPriceUpdated e:
                    Price = new Price(e.Price, e.CurrencyCode);
                    break;
                case Events.ClassifiedAdSentForReview e:
                    State = ClassifiedAdState.PendingReview;
                    break;
               
                    //handle of entity will called.. 
                    //handle will call when of entity 
                    // when will call handling event of picture entity.. 
                case Events.PictureAddedToAClassifiedAd e:
                    var picture = new Picture(Apply);
                    ApplyToEntity(picture, e);
                    Pictures.Add(picture);
                    break;
            }
        }

        public enum ClassifiedAdState
        {
            PendingReview,
            Active,
            Inactive,
            MarkedAsSold
        }

    }
}
