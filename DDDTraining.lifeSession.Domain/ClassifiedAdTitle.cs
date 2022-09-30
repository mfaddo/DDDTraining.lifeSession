using DDDTraining.lifeSession.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DDDTraining.lifeSession.Domain
{
   public class ClassifiedAdTitle : Value<ClassifiedAdTitle>
    {
        public static ClassifiedAdTitle FromString(string title) =>
                new ClassifiedAdTitle(title);
        public static ClassifiedAdTitle FromHtml(string htmlTitle)
        {
            var supportedTagsReplaced = htmlTitle
            .Replace("<i>", "*")
            .Replace("</i>", "*")
            .Replace("<b>", "**")
            .Replace("</b>", "**");
            return new ClassifiedAdTitle(Regex.Replace(
            supportedTagsReplaced, "<.*?>", string.Empty));
        }
        private readonly string _value;
        internal ClassifiedAdTitle(string value)
        {
            if (value.Length > 100)
                throw new ArgumentOutOfRangeException(
                "Title cannot be longer that 100 characters",
                nameof(value));
            _value = value;
        }

        public static implicit operator string(ClassifiedAdTitle self) =>
       self._value;
    }
}
