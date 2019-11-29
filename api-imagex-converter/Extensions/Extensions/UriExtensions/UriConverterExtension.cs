using System;
using System.Linq;

namespace Extensions
{
    public static class UriConverterExtension
    {
        public static Uri ToCombineUrl(this Uri uri, params string[] combinePath) =>
            new Uri(combinePath.Aggregate(uri.AbsoluteUri, (first, last) => string.Format("{0}/{1}", first.TrimEnd('/'), last.TrimEnd('/'))));
    }
}
