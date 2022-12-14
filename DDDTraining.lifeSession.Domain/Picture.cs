using DDDTraining.lifeSession.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDTraining.lifeSession.Domain
{
    public class Picture : Entity<PictureId>
    {
        internal Uri Location { get;  set; }
        internal PictureSize Size { get;  set; }
        internal int Order { get;  set; }
      

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.PictureAddedToAClassifiedAd e:
                    Id = new PictureId(e.PictureId);
                    Location = new Uri(e.Url);
                    Size = new PictureSize
                    { Height = e.Height, Width = e.Width };
                    Order = e.Order;
                    break;
                case Events.ClassifiedAdPictureResized e:
                    Size = new PictureSize { Height = e.Height, Width = e.Width };
                    break;
            }
        }

        public void Resize(PictureSize newSize)
                => Apply(new Events.ClassifiedAdPictureResized
                {
                    PictureId = Id.Value,
                    Height = newSize.Width,
                    Width = newSize.Width
                });
        public Picture(Action<object> applier) : base(applier) { }
    }
}
