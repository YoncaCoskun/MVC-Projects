using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace BookyBook.MVC.Helper
{
    public static class HtmlHelper
    {
        public static MvcHtmlString RadioButtonListemFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression  )
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            var listOfValues = Enum.GetNames(metaData.ModelType);

            var sb = new StringBuilder();

            if (listOfValues.Length > 0)
            {
                sb = sb.AppendFormat("<ul  class='list-inline'>");

                // Create a radio button for each item in the list
                foreach (var name in listOfValues)
                {
                    var label = name;

                    var memInfo = metaData.ModelType.GetMember(name);

                    if (memInfo.Length > 0)
                    {
                        var attributes = memInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);

                        if (attributes.Length > 0)
                            label = ((DisplayAttribute)attributes[0]).Name;
                    }

                    var id = string.Format(
                        "{0}_{1}_{2}",
                        htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix,
                        metaData.PropertyName,
                        name
                    );

                    var radio = htmlHelper.RadioButtonFor(expression, name, new { id = id }).ToHtmlString();
                    sb.AppendFormat("<li>{0}{1}</li>", radio, HttpUtility.HtmlEncode(label));
                }

                sb = sb.AppendFormat("</ul>");
            }

            return MvcHtmlString.Create(sb.ToString());
        }
    }
}
